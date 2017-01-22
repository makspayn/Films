using System;
using System.Windows.Forms;
using Films.Services;

namespace Films.Forms
{
	public partial class LogForm : Form
	{
		private MainForm frMain;
		private FilmsList films;
		private UpdateService updateService;

		public LogForm()
		{
			InitializeComponent();
			frMain = MainForm.GetInstance();
			updateService = UpdateService.GetInstance();
			films = frMain.GetFilmsList();
		}

		private void LogForm_Shown(object sender, EventArgs e)
		{
			lbInfo.Items.Clear();
			foreach (LogUnit logUnit in updateService.GetLog()) {
				lbInfo.Items.Add(films.GetFilmDisplayedName(logUnit.film));
			}
		}

		private void lbInfo_Click(object sender, EventArgs e)
		{
			if (lbInfo.SelectedIndex == -1)
				return;
			LogUnit logUnit = (LogUnit) updateService.GetLog()[lbInfo.SelectedIndex];
			Film film = logUnit.film;
			FilmInfo filmInfo = logUnit.filmInfo;
			tbRussianTitle.Text = film.russianTitle;
			tbOriginalTitle.Text = film.originalTitle;
			tbYear.Text = film.year;
			tbCountry.Text = film.country;
			tbGenre.Text = film.genre;
			tbDirector.Text = film.director;
			rtbActors.Text = film.actors;
			tbWorldDate.Text = film.worldDate;
			tbRussianDate.Text = film.russianDate;
			tbDiscDate.Text = film.discDate;
			tbRusTitle.Text = filmInfo.russianTitle;
			tbOrigTitle.Text = filmInfo.originalTitle;
			tbY.Text = filmInfo.year;
			tbC.Text = filmInfo.country;
			tbG.Text = filmInfo.genre;
			tbD.Text = filmInfo.director;
			rtbA.Text = filmInfo.actors;
			tbWDate.Text = filmInfo.worldPremiere;
			tbRDate.Text = filmInfo.russianPremiere;
			tbDDate.Text = filmInfo.discPremiere;
		}

		private void btnEnter_Click(object sender, EventArgs e)
		{
			if (lbInfo.SelectedIndex == -1)
				return;
			LogUnit logUnit = (LogUnit) updateService.GetLog()[lbInfo.SelectedIndex];
			Film film = logUnit.film;
			int index = films.GetFilmIndex(film);
			if (index == -1)
			{
				MessageBox.Show(@"Данный фильм не найден в базе!");
				return;
			}
			film.russianTitle = tbRusTitle.Text;
			film.originalTitle = tbOrigTitle.Text;
			film.year = tbY.Text;
			film.country = tbC.Text;
			film.genre = tbG.Text;
			film.director = tbD.Text;
			film.actors = rtbA.Text;
			film.worldDate = tbWDate.Text;
			film.russianDate = tbRDate.Text;
			film.discDate = tbDDate.Text;
			film.dataCheck = DateTime.Now.ToString();     
			films.Edit(film, index);
			updateService.GetLog().RemoveAt(lbInfo.SelectedIndex);
			frMain.UpdateEvent();
			frMain.FilmUpdateEvent(index);
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