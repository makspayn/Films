using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using HtmlAgilityPack;
using System.Net;
using System.Text;
using System.Collections;

namespace Films
{
  public struct Info
  {
    public String russianTitle;
    public String originalTitle;
    public String year;
    public String country;
    public String genre;
    public String director;
    public String actors;
    public String worldDate;
    public String russianDate;
    public String discDate;
    public Film film;
  }
  public partial class frMain : Form
  {
    public FilmsList films;
    public ArrayList arrayInfo;
    bool changed;
    Thread threadSearch;
    public frMain()
    {
      InitializeComponent();
      films = new FilmsList();
      changed = false;
      arrayInfo = new ArrayList();
      System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
    }

    private String GetDate(String value)
    {
      DateTime dt = DateTime.Parse(value);
      return dt.ToShortDateString();
    }
    private String ValidateAndCorrect(String value)
    {
      return WebUtility.HtmlDecode(value);
    }

    private String Trim(String text)
    {
      return text.Trim(new char[] { ' ', '\r', '\n' });
    }
    private String GetHtml(String id)
    {
      string BaseUrl = "http://www.kinopoisk.ru/film/";
      WebRequest.DefaultWebProxy = new WebProxy();
      HttpWebRequest request = (HttpWebRequest)WebRequest.Create(BaseUrl + id);
      request.Proxy = null;
      request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.103 Safari/537.36";
      request.Headers.Add("Accept-Language: ru-Ru,ru;q=0.5");
      request.Headers.Add("Accept-Charset: Windows-1251,utf-8;q=0.7,*;q=0.7");
      using (HttpWebResponse response = (HttpWebResponse)request.GetResponse()) {
        string encoding = response.Headers["Content-Type"].ToString().Split(new string[] { "charset=" }, StringSplitOptions.RemoveEmptyEntries)[1];
        StringBuilder sb = new StringBuilder();
        byte[] buf = new byte[8192];
        int b = 0;
        Stream resStream = response.GetResponseStream();
        do {
          b = resStream.Read(buf, 0, buf.Length);
          if (b != 0) {
            sb.Append(Encoding.GetEncoding(encoding).GetString(buf, 0, b));
          }
        } while (b > 0);
        return sb.ToString();
      }
    }

    private String DeletePoints(String str)
    {
      if (str.Substring(str.Length - 3, 3) == "...") {
        return str.Substring(0, str.Length - 5);
      }
      return str;
    }

    private void SearchUpdate()
    {
      changed = true;
      int check = 0;
      int change = 0;
      lblFilms.Text = "Проверено: 0 Изменения: 0";
      lblFilm.Text = "Проверяется:";
      for (int j = dgFilms.Rows.Count - 1; j > -1; j--) {
        Film f = films.GetFilm(j);
        lblFilm.Text = "Проверяется: " + dgFilms.Rows[j].Cells[0].Value.ToString();
        if (f.code == "") {
          continue;
        }
        DateTime dtPremiere = Convert.ToDateTime(dgFilms.Rows[j].Cells[1].Value.ToString());
        DateTime dtNow = DateTime.Now;
        DateTime dtCheck = Convert.ToDateTime(f.dataCheck);
        TimeSpan ts1 = dtNow - dtPremiere;
        TimeSpan ts2 = dtNow - dtCheck;
        if ((double)(ts1.TotalDays / 10.0) > ts2.TotalDays) {
          continue;
        }
        String rusTitle = "";
        String origTitle = "";
        String year = "";
        String country = "";
        String director = "";
        String genre = "";
        String worldPremiere = "";
        String russianPremiere = "";
        String dvdRelease = "";
        String blurayRelease = "";
        String actors = "";
        try {
          String htmlCode = GetHtml(f.code);
          HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
          doc.LoadHtml(htmlCode);
          var headerFilm = doc.GetElementbyId("headerFilm");
          rusTitle = ValidateAndCorrect(Trim(headerFilm.SelectSingleNode("h1").InnerText));
          origTitle = ValidateAndCorrect(Trim(headerFilm.SelectSingleNode("span").InnerText));
          var actorList = doc.GetElementbyId("actorList");
          HtmlNodeCollection list = actorList.SelectSingleNode("ul").ChildNodes;
          for (int i = 0; i < list.Count; i++) {
            actors += ValidateAndCorrect(Trim(actorList.SelectSingleNode("ul/li[" + (i + 1).ToString() + "]").InnerText));
            if (i != list.Count - 1) {
              actors += ", ";
            }
          }
          actors = DeletePoints(actors);
          var infoTable = doc.GetElementbyId("infoTable");
          HtmlNodeCollection table = infoTable.SelectSingleNode("table").ChildNodes;
          for (int i = 0; i < table.Count / 2; i++) {
            if (ValidateAndCorrect(Trim(infoTable.SelectSingleNode("table/tr[" + (i + 1).ToString() + "]/td[1]").InnerText)) == "год") {
              year = ValidateAndCorrect(Trim(infoTable.SelectSingleNode("table/tr[" + (i + 1).ToString() + "]/td[2]").InnerText));
            }
            if (ValidateAndCorrect(Trim(infoTable.SelectSingleNode("table/tr[" + (i + 1).ToString() + "]/td[1]").InnerText)) == "страна") {
              country = ValidateAndCorrect(Trim(infoTable.SelectSingleNode("table/tr[" + (i + 1).ToString() + "]/td[2]").InnerText));
              country = DeletePoints(country);
            }
            if (ValidateAndCorrect(Trim(infoTable.SelectSingleNode("table/tr[" + (i + 1).ToString() + "]/td[1]").InnerText)) == "режиссер") {
              director = ValidateAndCorrect(Trim(infoTable.SelectSingleNode("table/tr[" + (i + 1).ToString() + "]/td[2]").InnerText));
              director = DeletePoints(director);
            }
            if (ValidateAndCorrect(Trim(infoTable.SelectSingleNode("table/tr[" + (i + 1).ToString() + "]/td[1]").InnerText)) == "жанр") {
              genre = ValidateAndCorrect(Trim(infoTable.SelectSingleNode("table/tr[" + (i + 1).ToString() + "]/td[2]/span").InnerText));
              genre = DeletePoints(genre);
            }
            if (ValidateAndCorrect(Trim(infoTable.SelectSingleNode("table/tr[" + (i + 1).ToString() + "]/td[1]").InnerText)) == "премьера (мир)") {
              worldPremiere = GetDate(ValidateAndCorrect(Trim(infoTable.SelectSingleNode("table/tr[" + (i + 1).ToString() + "]/td[2]/div/a").InnerText)));
            }
            if (ValidateAndCorrect(Trim(infoTable.SelectSingleNode("table/tr[" + (i + 1).ToString() + "]/td[1]").InnerText)) == "премьера (РФ)") {
              russianPremiere = GetDate(ValidateAndCorrect(Trim(infoTable.SelectSingleNode("table/tr[" + (i + 1).ToString() + "]/td[2]/div/span/a").InnerText)));
            }
            if (ValidateAndCorrect(Trim(infoTable.SelectSingleNode("table/tr[" + (i + 1).ToString() + "]/td[1]").InnerText)) == "релиз на DVD") {
              dvdRelease = GetDate(ValidateAndCorrect(Trim(infoTable.SelectSingleNode("table/tr[" + (i + 1).ToString() + "]/td[2]/div/a").InnerText)));
            }
            if (ValidateAndCorrect(Trim(infoTable.SelectSingleNode("table/tr[" + (i + 1).ToString() + "]/td[1]").InnerText)) == "релиз на Blu-Ray") {
              blurayRelease = GetDate(ValidateAndCorrect(Trim(infoTable.SelectSingleNode("table/tr[" + (i + 1).ToString() + "]/td[2]/div/a").InnerText)));
            }
          }
        }
        catch {
          continue;
        }
        check++;
        bool flag = false;
        if (origTitle != f.originalTitle) {
          flag = true;
        }
        if (year != f.year) {
          flag = true;
        }
        if (country != f.country) {
          flag = true;
        }
        if (director != f.director) {
          flag = true;
        }
        if (genre != f.genre) {
          flag = true;
        }
        if (actors != f.actors) {
          flag = true;
        }
        if (worldPremiere != f.worldDate) {
          flag = true;
        }
        if (russianPremiere != f.russianDate) {
          flag = true;
        }
        String discDate = "";
        if (blurayRelease != "") {
          discDate = blurayRelease;
        }
        else {
          discDate = dvdRelease;
        }
        if (discDate != f.discDate) {
          flag = true;
        }
        if (flag) {
          change++;
          Info info = new Info();
          info.russianTitle = rusTitle;
          info.originalTitle = origTitle;
          info.year = year;
          info.country = country;
          info.genre = genre;
          info.director = director;
          info.actors = actors;
          info.worldDate = worldPremiere;
          info.russianDate = russianPremiere;
          info.discDate = discDate;
          info.film = films.GetFilm(j);
          arrayInfo.Add(info);
        }
        else {
          f.dataCheck = DateTime.Now.ToString();
          films.Edit(f, j);
        }
        lblFilms.Text = "Проверено: " + check.ToString() + " Изменения: " + change.ToString();
      }
      lblFilm.Text = "Проверяется:";
    }

    private void FormToFilm(int index)
    {
      Film f = films.GetFilm(index);
      String str = "";
      if (f.originalTitle == "") {
        str = f.russianTitle + " (" + f.year + ")";
      }
      else {
        str = f.russianTitle + " / " + f.originalTitle + " (" + f.year + ")";
      }
      dgFilms.Rows[index].Cells[0].Value = str;
      if (f.russianDate == "") {
        dgFilms.Rows[index].Cells[1].Value = f.worldDate;
      }
      else {
        dgFilms.Rows[index].Cells[1].Value = f.russianDate;
      }
      dgFilms.Rows[index].Cells[2].Value = f.discDate;
      dgFilms.Rows[index].Cells[3].Value = f.qualityTitle + " " + f.qualityPixel + " " +
        f.videoKbps.ToString() + " Kbps, " + f.audioCodec + " " + f.channels.ToString() + " ch " +
        f.audioKbps.ToString() + " Kbps - " + f.translateTitle + " " + f.translateComment;
      if (f.Color == "Хороший") {
          dgFilms.Rows[index].Cells[3].Style.BackColor = Color.LightGreen;
        }
      if (f.Color == "Нейтральный") {
        dgFilms.Rows[index].Cells[3].Style.BackColor = Color.Yellow;
      }
      if (f.Color == "Плохой") {
        dgFilms.Rows[index].Cells[3].Style.BackColor = Color.IndianRed;
      }
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
      Film f = new Film();
      dgFilms.Rows.Add();
      films.Add(f);
      EditForm frEdit = new EditForm(this, dgFilms.Rows.Count - 1);
      frEdit.ShowDialog();
      FormToFilm(dgFilms.Rows.Count - 1);
      changed = true;
    }

    private void btnInsert_Click(object sender, EventArgs e)
    {
      if (dgFilms.CurrentRow != null) {
        Film f = new Film();
        dgFilms.Rows.Insert(dgFilms.CurrentRow.Index, 1);
        films.Insert(f, dgFilms.CurrentRow.Index - 1);
        EditForm frEdit = new EditForm(this, dgFilms.CurrentRow.Index - 1);
        frEdit.ShowDialog();
        FormToFilm(dgFilms.CurrentRow.Index - 1);
        changed = true;
      }
      else {
        btnAdd.PerformClick();
      }
    }

    private void btnEdit_Click(object sender, EventArgs e)
    {
      if (dgFilms.CurrentRow != null) {
        EditForm frEdit = new EditForm(this, dgFilms.CurrentRow.Index);
        frEdit.ShowDialog();
        Film f = films.GetFilm(dgFilms.CurrentRow.Index);
        FormToFilm(dgFilms.CurrentRow.Index);
        changed = true;
      }
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
      if (dgFilms.CurrentRow != null) {
        films.Delete(dgFilms.CurrentRow.Index);
        dgFilms.Rows.RemoveAt(dgFilms.CurrentRow.Index);
        changed = true;
      }
    }

    private void btnOpen_Click(object sender, EventArgs e)
    {
      if (changed) {
        if (MessageBox.Show("Отменить сохранения?", "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) {
          return;
        }
      }
      if (!File.Exists("Фильмы.xml")) {
        MessageBox.Show("Файл 'Фильмы.xml' не был найден!");
        return;
      }
      if (threadSearch != null) {
        threadSearch.Abort();
        threadSearch = null;
      }
      btnOpen.Enabled = false;
      dgFilms.Rows.Clear();
      films = null;
      films = new FilmsList();
      FileStream fileFilms = File.Open("Фильмы.xml", FileMode.Open);
      System.Xml.Serialization.XmlSerializer readerFilm = new System.Xml.Serialization.XmlSerializer(typeof(Film[]));
      Film[] arrayFilms = (Film[])readerFilm.Deserialize(fileFilms);
      for (int i = 0; i < arrayFilms.Length; i++) {
        Film f = arrayFilms[i];
        String str = "";
        if (f.originalTitle == "") {
          str = f.russianTitle + " (" + f.year + ")";
        }
        else {
          str = f.russianTitle + " / " + f.originalTitle + " (" + f.year + ")";
        }
        dgFilms.Rows.Add();
        dgFilms.Rows[i].Cells[0].Value = str;
        if (f.russianDate == "") {
          dgFilms.Rows[i].Cells[1].Value = f.worldDate;
        }
        else {
          dgFilms.Rows[i].Cells[1].Value = f.russianDate;
        }
        dgFilms.Rows[i].Cells[2].Value = f.discDate;
        dgFilms.Rows[i].Cells[3].Value = f.qualityTitle + " " + f.qualityPixel + " " +
          f.videoKbps.ToString() + " Kbps, " + f.audioCodec + " " + f.channels.ToString() + " ch " +
          f.audioKbps.ToString() + " Kbps - " + f.translateTitle + " " + f.translateComment;
        if (f.Color == "Хороший"){
          dgFilms.Rows[i].Cells[3].Style.BackColor = Color.LightGreen;
        }
        if (f.Color == "Нейтральный"){
          dgFilms.Rows[i].Cells[3].Style.BackColor = Color.Yellow;
        }
        if (f.Color == "Плохой"){
          dgFilms.Rows[i].Cells[3].Style.BackColor = Color.IndianRed;
        }
        films.Add(f);
      }
      fileFilms.Close();
      changed = false;
      btnOpen.Enabled = true;
      threadSearch = new Thread(new ThreadStart(this.SearchUpdate));
      threadSearch.Start();
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show("Сохранить текущий список?", "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) {
        return;
      }
      FileStream fileFilms = File.Open("Фильмы.xml", FileMode.Create);
      System.Xml.Serialization.XmlSerializer writerFilm = new System.Xml.Serialization.XmlSerializer(typeof(Film[]));
      writerFilm.Serialize(fileFilms, films.GetArray());
      fileFilms.Close();
      changed = false;
    }

    private void dgFilms_DoubleClick(object sender, EventArgs e)
    {
      if (dgFilms.Rows.Count != 0) {
        CardForm frCard = new CardForm(films.GetFilm(dgFilms.CurrentRow.Index));
        frCard.ShowDialog();
      }
    }

    private void btnFind_Click(object sender, EventArgs e)
    {
      SearchForm frSearch = new SearchForm(this, films);
      frSearch.ShowDialog();
    }

    private void btnUp_Click(object sender, EventArgs e)
    {
      if (dgFilms.Rows.Count == 0) {
        return;
      }
      if (dgFilms.CurrentRow.Index == 0) {
        return;
      }
      int i = dgFilms.CurrentRow.Index;
      Film f = new Film();
      Film temp = films.GetFilm(i);
      f = films.CopyTo(f, temp);
      films.Delete(i);
      dgFilms.Rows.RemoveAt(i);
      dgFilms.Rows.Insert(i - 1, 1);
      films.Insert(f, i - 1);
      FormToFilm(i - 1);
      dgFilms.CurrentCell = dgFilms.Rows[i - 1].Cells[0];
      dgFilms.Rows[i - 1].Selected = true;
      changed = true;
    }

    private void btnDown_Click(object sender, EventArgs e)
    {
      if (dgFilms.Rows.Count == 0) {
        return;
      }
      if (dgFilms.CurrentRow.Index == dgFilms.Rows.Count - 1) {
        return;
      }
      int i = dgFilms.CurrentRow.Index;
      Film f = new Film();
      Film temp = films.GetFilm(i);
      f = films.CopyTo(f, temp);
      films.Delete(i);
      dgFilms.Rows.RemoveAt(i);
      dgFilms.Rows.Insert(i + 1, 1);
      films.Insert(f, i + 1);
      FormToFilm(i + 1);
      dgFilms.CurrentCell = dgFilms.Rows[i + 1].Cells[0];
      dgFilms.Rows[i + 1].Selected = true;
      changed = true;
    }

    private void frMain_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (changed) {
        if (MessageBox.Show("Отменить сохранения?", "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) {
          e.Cancel = true;
          return;
        }
      }
      if (threadSearch != null) {
        threadSearch.Abort();
        threadSearch = null;
      }
    }

    private void btnCoding_Click(object sender, EventArgs e)
    {
      CalcForm frCalc = new CalcForm();
      frCalc.ShowDialog();
    }

    private void btnLog_Click(object sender, EventArgs e)
    {
      LogForm frLog = new LogForm(this);
      frLog.ShowDialog();
    }
  }
}