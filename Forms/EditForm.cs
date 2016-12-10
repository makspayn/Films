using System;
using System.Windows.Forms;
using System.Threading;
using Films.Services;

namespace Films.Forms
{
	public partial class EditForm : Form
	{
		private static EditForm instance;
		private Film film;
		private int index;
		private MainForm frMain;
		private bool changed;
		private bool loaded;

		private EditForm()
		{
			InitializeComponent();
			frMain = MainForm.GetInstance();
		}

		public static EditForm GetInstance(int index)
		{
			if (instance == null)
			{
				instance = new EditForm();
			}
			instance.index = index;
			instance.film = instance.frMain.GetFilmsList().GetFilm(index);
			return instance;
		}

		private void EditForm_Shown(object sender, EventArgs e)
		{
			btnClear.PerformClick();
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
			rtbDescription.Text = film.description;
			tbLink.Text = film.link;
			tbCode.Text = film.code;
			tbWidth.Text = film.width.ToString();
			tbHeight.Text = film.height.ToString();
			tbDuration.Text = film.duration;
			cbQualityTitle.Text = film.qualityTitle;
			cbQualityPixel.Text = film.qualityPixel;
			cbTranslateTitle.Text = film.translateTitle;
			cbTranslateComment.Text = film.translateComment;
			cbColor.Text = film.Color;
			cbVideoCodec.Text = film.videoCodec;
			tbOriginalWidth.Text = film.originalWidth.ToString();
			tbOriginalHeight.Text = film.originalHeight.ToString();
			tbVideoKbps.Text = film.videoKbps.ToString();
			tbFramePerSec.Text = film.fps.ToString();
			cbAudioCodec.Text = film.audioCodec;
			tbChannels.Text = film.channels.ToString();
			tbAudioKbps.Text = film.audioKbps.ToString();
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
			tbWidth.Text = @"0";
			tbHeight.Text = @"0";
			tbDuration.Clear();
			cbQualityTitle.SelectedIndex = -1;
			cbQualityPixel.SelectedIndex = -1;
			cbTranslateTitle.SelectedIndex = -1;
			cbTranslateComment.SelectedIndex = -1;
			cbColor.SelectedIndex = -1;
			cbVideoCodec.SelectedIndex = -1;
			tbOriginalWidth.Text = @"0";
			tbOriginalHeight.Text = @"0";
			tbVideoKbps.Text = @"0";
			tbFramePerSec.Text = @"0";
			cbAudioCodec.SelectedIndex = -1;
			tbChannels.Text = @"0";
			tbAudioKbps.Text = @"0";
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			try {
				Film newFilm = new Film
				{
					russianTitle = tbRussianTitle.Text,
					originalTitle = tbOriginalTitle.Text,
					year = tbYear.Text,
					country = tbCountry.Text,
					genre = tbGenre.Text,
					director = tbDirector.Text,
					actors = rtbActors.Text,
					worldDate = tbWorldDate.Text,
					russianDate = tbRussianDate.Text,
					discDate = tbDiscDate.Text,
					description = rtbDescription.Text,
					link = tbLink.Text,
					code = tbCode.Text,
					width = Convert.ToInt32(tbWidth.Text),
					height = Convert.ToInt32(tbHeight.Text),
					duration = tbDuration.Text,
					qualityTitle = cbQualityTitle.Text,
					qualityPixel = cbQualityPixel.Text,
					translateTitle = cbTranslateTitle.Text,
					translateComment = cbTranslateComment.Text,
					Color = cbColor.Text,
					videoCodec = cbVideoCodec.Text,
					originalWidth = Convert.ToInt32(tbOriginalWidth.Text),
					originalHeight = Convert.ToInt32(tbOriginalHeight.Text),
					videoKbps = Convert.ToInt32(tbVideoKbps.Text),
					fps = Convert.ToDouble(tbFramePerSec.Text),
					audioCodec = cbAudioCodec.Text,
					channels = Convert.ToInt32(tbChannels.Text),
					audioKbps = Convert.ToInt32(tbAudioKbps.Text)
				};
				if (newFilm.dataCheck == "") {
					newFilm.dataCheck = "10.08.1994 0:00:00";
				}
				if (loaded) {
					newFilm.dataCheck = DateTime.Now.ToString();
				}
				frMain.GetFilmsList().Edit(newFilm, index);
				changed = false;
				loaded = false;
				Close();
			}
			catch {
				MessageBox.Show(@"Проверьте корректность заполнения всех полей!");
			}
		}

		private void EditForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!changed)
				return;
			if (MessageBox.Show(@"Отменить сохранения?", @"Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
				return;
			e.Cancel = true;
		}

		private void FilmInfoToForm(FilmInfo filmInfo)
		{
			tbRussianTitle.BeginInvoke(new Action<string>(s => tbRussianTitle.Text = s), filmInfo.russianTitle);
			tbOriginalTitle.BeginInvoke(new Action<string>(s => tbOriginalTitle.Text = s), filmInfo.originalTitle);
			tbYear.BeginInvoke(new Action<string>(s => tbYear.Text = s), filmInfo.year);
			tbCountry.BeginInvoke(new Action<string>(s => tbCountry.Text = s), filmInfo.country);
			tbGenre.BeginInvoke(new Action<string>(s => tbGenre.Text = s), filmInfo.genre);
			tbDirector.BeginInvoke(new Action<string>(s => tbDirector.Text = s), filmInfo.director);
			rtbActors.BeginInvoke(new Action<string>(s => rtbActors.Text = s), filmInfo.actors);
			tbWorldDate.BeginInvoke(new Action<string>(s => tbWorldDate.Text = s), filmInfo.worldPremiere);
			tbRussianDate.BeginInvoke(new Action<string>(s => tbRussianDate.Text = s), filmInfo.russianPremiere);
			tbDiscDate.BeginInvoke(new Action<string>(s => tbDiscDate.Text = s), filmInfo.discPremiere);
		}

		private void Loading()
		{
			if (tbCode.Text == "")
				return;
			btnLoad.BeginInvoke(new Action<bool>(s => btnLoad.Enabled = s), false);
			btnClear.BeginInvoke(new Action<bool>(s => btnClear.Enabled = s), false);
			btnOK.BeginInvoke(new Action<bool>(s => btnOK.Enabled = s), false);
			FilmInfoToForm(ParsingService.GetInstance().GetFilmInfo(tbCode.Text));
			btnLoad.BeginInvoke(new Action<bool>(s => btnLoad.Enabled = s), true);
			btnClear.BeginInvoke(new Action<bool>(s => btnClear.Enabled = s), true);
			btnOK.BeginInvoke(new Action<bool>(s => btnOK.Enabled = s), true);
		}

		private void btnLoad_Click(object sender, EventArgs e)
		{
			new Thread(Loading).Start();
			Loading();
			loaded = true;
		}

		private void btnCalc_Click(object sender, EventArgs e)
		{
			CalcForm.GetInstance().ShowDialog();
		}
	}
}