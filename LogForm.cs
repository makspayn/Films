using System;
using System.Windows.Forms;

namespace Films
{
  public partial class LogForm : Form
  {
    frMain frMain;
    public LogForm(frMain fr)
    {
      InitializeComponent();
      frMain = fr;
    }

    private void LogForm_Shown(object sender, EventArgs e)
    {
      lbInfo.Items.Clear();
      foreach (Info info in frMain.arrayInfo) {
        String str = "";
        if (info.film.originalTitle == "") {
          str = info.film.russianTitle + " (" + info.film.year + ")";
        }
        else {
          str = info.film.russianTitle + " / " + info.film.originalTitle + " (" + info.film.year + ")";
        }
        lbInfo.Items.Add(str);
      }
    }

    private void lbInfo_Click(object sender, EventArgs e)
    {
      if (lbInfo.SelectedIndex != -1) {
        Info info = (Info)frMain.arrayInfo[lbInfo.SelectedIndex];
        tbRussianTitle.Text = info.film.russianTitle;
        tbOriginalTitle.Text = info.film.originalTitle;
        tbYear.Text = info.film.year;
        tbCountry.Text = info.film.country;
        tbGenre.Text = info.film.genre;
        tbDirector.Text = info.film.director;
        rtbActors.Text = info.film.actors;
        tbWorldDate.Text = info.film.worldDate;
        tbRussianDate.Text = info.film.russianDate;
        tbDiscDate.Text = info.film.discDate;
        tbRusTitle.Text = info.russianTitle;
        tbOrigTitle.Text = info.originalTitle;
        tbY.Text = info.year;
        tbC.Text = info.country;
        tbG.Text = info.genre;
        tbD.Text = info.director;
        rtbA.Text = info.actors;
        tbWDate.Text = info.worldDate;
        tbRDate.Text = info.russianDate;
        tbDDate.Text = info.discDate;
      }
    }

    private void btnEnter_Click(object sender, EventArgs e)
    {
      if (lbInfo.SelectedIndex != -1) {
        Info info = (Info)frMain.arrayInfo[lbInfo.SelectedIndex];
        int index = 0;
        for (int i = 0; i < frMain.dgFilms.Rows.Count; i++) {
          Film f = frMain.films.GetFilm(i);
          if ((f.russianTitle == info.film.russianTitle) && (f.originalTitle == info.film.originalTitle)) {
            index = i;
            break;
          }
        }
        info.film.russianTitle = tbRusTitle.Text;
        info.film.originalTitle = tbOrigTitle.Text;
        info.film.year = tbY.Text;
        info.film.country = tbC.Text;
        info.film.genre = tbG.Text;
        info.film.director = tbD.Text;
        info.film.actors = rtbA.Text;
        info.film.worldDate = tbWDate.Text;
        info.film.russianDate = tbRDate.Text;
        info.film.discDate = tbDDate.Text;
        info.film.dataCheck = DateTime.Now.ToString();     
        frMain.films.Edit(info.film, index);
        frMain.arrayInfo.RemoveAt(lbInfo.SelectedIndex);
        lbInfo.Items.RemoveAt(lbInfo.SelectedIndex);
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
        tbRusTitle.Clear();
        tbOrigTitle.Clear();
        tbY.Clear();
        tbC.Clear();
        tbG.Clear();
        tbD.Clear();
        rtbA.Clear();
        tbWDate.Clear();
        tbRDate.Clear();
        tbDDate.Clear();
      }
    }
  }
}