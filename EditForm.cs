using System;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using HtmlAgilityPack;
using System.Threading;

namespace Films
{
  public partial class EditForm : Form
  {
    frMain frMain;
    Film f;
    int index;
    bool changed;
    bool loaded;
    public EditForm(frMain fr, int i)
    {
      InitializeComponent();
      frMain = fr;
      index = i;
      f = frMain.films.GetFilm(index);
    }

    private string GetDate(string value)
    {
      DateTime dt = DateTime.Parse(value);
      return dt.ToShortDateString();
    }
    private string ValidateAndCorrect(string value)
    {
      return WebUtility.HtmlDecode(value);
    }

    private string Trim(string text)
    {
      return text.Trim(new char[] { ' ', '\r', '\n' });
    }
    private string GetHtml(string id)
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

    private void EditForm_Shown(object sender, EventArgs e)
    {
      btnClear.PerformClick();
      tbRussianTitle.Text = f.russianTitle;
      tbOriginalTitle.Text = f.originalTitle;
      tbYear.Text = f.year;
      tbCountry.Text = f.country;
      tbGenre.Text = f.genre;
      tbDirector.Text = f.director;
      rtbActors.Text = f.actors;
      tbWorldDate.Text = f.worldDate;
      tbRussianDate.Text = f.russianDate;
      tbDiscDate.Text = f.discDate;
      rtbDescription.Text = f.description;
      tbLink.Text = f.link;
      tbCode.Text = f.code;
      tbWidth.Text = f.width.ToString();
      tbHeight.Text = f.height.ToString();
      tbDuration.Text = f.duration;
      cbQualityTitle.Text = f.qualityTitle;
      cbQualityPixel.Text = f.qualityPixel;
      cbTranslateTitle.Text = f.translateTitle;
      cbTranslateComment.Text = f.translateComment;
      cbColor.Text = f.Color;
      cbVideoCodec.Text = f.videoCodec;
      tbOriginalWidth.Text = f.originalWidth.ToString();
      tbOriginalHeight.Text = f.originalHeight.ToString();
      tbVideoKbps.Text = f.videoKbps.ToString();
      tbFramePerSec.Text = f.fps.ToString();
      cbAudioCodec.Text = f.audioCodec;
      tbChannels.Text = f.channels.ToString();
      tbAudioKbps.Text = f.audioKbps.ToString();
      changed = true;
      loaded = false;
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
      tbRussianTitle.Clear();
      tbOriginalTitle.Clear();
      tbYear.Clear();
      tbCountry.Clear();
      tbGenre.Clear();
      tbDirector.Clear();
      rtbActors.Clear();
      tbWorldDate.Clear();
      tbRussianDate.Clear();
      tbDiscDate.Clear();
      rtbDescription.Clear();
      tbLink.Clear();
      tbCode.Clear();
      tbWidth.Text = "0";
      tbHeight.Text = "0";
      tbDuration.Clear();
      cbQualityTitle.SelectedIndex = -1;
      cbQualityPixel.SelectedIndex = -1;
      cbTranslateTitle.SelectedIndex = -1;
      cbTranslateComment.SelectedIndex = -1;
      cbColor.SelectedIndex = -1;
      cbVideoCodec.SelectedIndex = -1;
      tbOriginalWidth.Text = "0";
      tbOriginalHeight.Text = "0";
      tbVideoKbps.Text = "0";
      tbFramePerSec.Text = "0";
      cbAudioCodec.SelectedIndex = -1;
      tbChannels.Text = "0";
      tbAudioKbps.Text = "0";
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      try {
        f.russianTitle = tbRussianTitle.Text;
        f.originalTitle = tbOriginalTitle.Text;
        f.year = tbYear.Text;
        f.country = tbCountry.Text;
        f.genre = tbGenre.Text;
        f.director = tbDirector.Text;
        f.actors = rtbActors.Text;
        f.worldDate = tbWorldDate.Text;
        f.russianDate = tbRussianDate.Text;
        f.discDate = tbDiscDate.Text;
        f.description = rtbDescription.Text;
        f.link = tbLink.Text;
        f.code = tbCode.Text;
        f.width = Convert.ToInt32(tbWidth.Text);
        f.height = Convert.ToInt32(tbHeight.Text);
        f.duration = tbDuration.Text;
        f.qualityTitle = cbQualityTitle.Text;
        f.qualityPixel = cbQualityPixel.Text;
        f.translateTitle = cbTranslateTitle.Text;
        f.translateComment = cbTranslateComment.Text;
        f.Color = cbColor.Text;
        f.videoCodec = cbVideoCodec.Text;
        f.originalWidth = Convert.ToInt32(tbOriginalWidth.Text);
        f.originalHeight = Convert.ToInt32(tbOriginalHeight.Text);
        f.videoKbps = Convert.ToInt32(tbVideoKbps.Text);
        f.fps = Convert.ToDouble(tbFramePerSec.Text);
        f.audioCodec = cbAudioCodec.Text;
        f.channels = Convert.ToInt32(tbChannels.Text);
        f.audioKbps = Convert.ToInt32(tbAudioKbps.Text);
        if (f.dataCheck == "") {
          f.dataCheck = "10.08.1994 0:00:00";
        }
        if (loaded) {
          f.dataCheck = DateTime.Now.ToString();
        }
      }
      catch {
        MessageBox.Show("Проверьте корректность заполнения всех полей!");
        return;
      }
      frMain.films.Edit(f, index);
      changed = false;
      loaded = false;
      Close();
    }

    private void EditForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (changed) {
        if (MessageBox.Show("Отменить сохранения?", "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) {
          e.Cancel = true;
          return;
        }
      }
    }

    private string DeletePoints(string str)
    {
      if (str.Substring(str.Length - 3, 3) == "...") {
        return str.Substring(0, str.Length - 5);
      }
      return str;
    }
    private void Loading()
    {
      btnLoad.Enabled = false;
      btnClear.Enabled = false;
      btnOK.Enabled = false;
      if (tbCode.Text == "") {
        btnLoad.Enabled = true;
        btnClear.Enabled = true;
        btnOK.Enabled = true;
        return;
      }
      string rusTitle = "";
      string origTitle = "";
      string year = "";
      string country = "";
      string director = "";
      string genre = "";
      string worldPremiere = "";
      string russianPremiere = "";
      string dvdRelease = "";
      string blurayRelease = "";
      string actors = "";
      try {
        string htmlCode = GetHtml(tbCode.Text);
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

      }
      tbRussianTitle.Text = rusTitle;
      tbOriginalTitle.Text = origTitle;
      tbYear.Text = year;
      tbCountry.Text = country;
      tbDirector.Text = director;
      tbGenre.Text = genre;
      rtbActors.Text = actors;
      tbWorldDate.Text = worldPremiere;
      tbRussianDate.Text = russianPremiere;
      if (blurayRelease != "") {
        tbDiscDate.Text = blurayRelease;
      }
      else {
        tbDiscDate.Text = dvdRelease;
      }
      btnLoad.Enabled = true;
      btnClear.Enabled = true;
      btnOK.Enabled = true;
    }
    private void btnLoad_Click(object sender, EventArgs e)
    {
      Thread threadLoading = new Thread(new ThreadStart(this.Loading));
      threadLoading.Start();
      loaded = true;
    }

    private void EditForm_Load(object sender, EventArgs e)
    {

    }

    private void tbDirector_TextChanged(object sender, EventArgs e)
    {

    }

    private void tbGenre_TextChanged(object sender, EventArgs e)
    {

    }

    private void tbCountry_TextChanged(object sender, EventArgs e)
    {

    }

    private void tbYear_TextChanged(object sender, EventArgs e)
    {

    }

    private void tbOriginalTitle_TextChanged(object sender, EventArgs e)
    {

    }

    private void tbRussianTitle_TextChanged(object sender, EventArgs e)
    {

    }

    private void label7_Click(object sender, EventArgs e)
    {

    }

    private void label6_Click(object sender, EventArgs e)
    {

    }

    private void label5_Click(object sender, EventArgs e)
    {

    }

    private void label4_Click(object sender, EventArgs e)
    {

    }

    private void label3_Click(object sender, EventArgs e)
    {

    }

    private void label2_Click(object sender, EventArgs e)
    {

    }

    private void rtbActors_TextChanged(object sender, EventArgs e)
    {

    }

    private void label9_Click(object sender, EventArgs e)
    {

    }

    private void tbDiscDate_TextChanged(object sender, EventArgs e)
    {

    }

    private void tbRussianDate_TextChanged(object sender, EventArgs e)
    {

    }

    private void tbWorldDate_TextChanged(object sender, EventArgs e)
    {

    }

    private void label11_Click(object sender, EventArgs e)
    {

    }

    private void label10_Click(object sender, EventArgs e)
    {

    }

    private void label1_Click(object sender, EventArgs e)
    {

    }

    private void btnCalc_Click(object sender, EventArgs e)
    {
      CalcForm frCalc = new CalcForm();
      frCalc.ShowDialog();
    }
  }
}