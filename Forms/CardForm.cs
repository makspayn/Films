using System;
using System.Drawing;
using System.Windows.Forms;
using Films.Rip;

namespace Films.Forms
{
	public partial class CardForm : Form
	{
		private static CardForm instance;
		private Film film;
		private RipCreator creator;

		private CardForm()
		{
			InitializeComponent();
		}

		public static CardForm GetInstance(Film film)
		{
			if (instance == null)
			{
				instance = new CardForm();
			}
			instance.film = film;
			return instance;
		}

		private void Render()
		{
			lblTitle.Text = MainForm.GetInstance().GetFilmsList().GetFilmDisplayedName(film);
			lblTitle.Left = (int)((Size.Width - lblTitle.Size.Width) / 2.0);
			pbPoster.Top = lblTitle.Bottom + 10;
			if (pbPoster.Image != null && pbRating.Image != null)
			{
				pbPoster.ClientSize = new Size(400, (int) (pbPoster.Image.Height / (double) pbPoster.Image.Width * 400.0));
				pbPoster.SizeMode = PictureBoxSizeMode.StretchImage;
				pbRating.Top = pbPoster.Bottom + 10;
			}
			lblLink.Top = pbRating.Bottom + 10;
			lblCountry.Text = film.country; label1.Top = lblTitle.Bottom + 10; lblCountry.Top = lblTitle.Bottom + 10;
			lblGenre.Text = film.genre; label2.Top = lblCountry.Bottom; lblGenre.Top = lblCountry.Bottom;
			lblDirector.Text = film.director; label3.Top = lblGenre.Bottom; lblDirector.Top = lblGenre.Bottom;
			lblActors.Text = film.actors; label4.Top = lblDirector.Bottom; lblActors.Top = lblDirector.Bottom;
			lblDescription.Text = film.description; label5.Top = lblActors.Bottom; lblDescription.Top = lblActors.Bottom;
			lblWorldDate.Text = film.worldDate; label6.Top = lblDescription.Bottom; lblWorldDate.Top = lblDescription.Bottom;
			lblRussianDate.Text = film.russianDate; label7.Top = lblWorldDate.Bottom; lblRussianDate.Top = lblWorldDate.Bottom;
			lblDiscDate.Text = film.discDate; label8.Top = lblRussianDate.Bottom; lblDiscDate.Top = lblRussianDate.Bottom;
			lblDuration.Text = film.duration; label9.Top = lblDiscDate.Bottom; lblDuration.Top = lblDiscDate.Bottom;
			lblQuality.Text = $"{film.qualityTitle} {film.qualityPixel}"; label10.Top = lblDuration.Bottom; lblQuality.Top = lblDuration.Bottom;
			lblTranslate.Text = $"{film.translateTitle} ({film.translateComment})"; label11.Top = lblQuality.Bottom; lblTranslate.Top = lblQuality.Bottom;
			lblVideo.Text = $"{film.videoCodec}, {film.originalWidth}x{film.originalHeight}, {film.videoKbps} Kbps, {film.fps} fps";
			label12.Top = lblTranslate.Bottom; lblVideo.Top = lblTranslate.Bottom;
			lblAudio.Text = $"{film.audioCodec}, {film.channels} ch, {film.audioKbps} Kbps";
			label13.Top = lblVideo.Bottom; lblAudio.Top = lblVideo.Bottom;
			lblSize.Text = FilmRip.GetRipSize(film.duration, film.videoKbps, film.audioKbps, film.originalWidth, film.originalHeight, film.fps);
			label14.Top = lblAudio.Bottom; lblSize.Top = lblAudio.Bottom;
			int point = label14.Bottom;
			if (lblLink.Bottom > point)
			{
				point = lblLink.Bottom;
			}
			label15.Left = (int)((Size.Width - label15.Size.Width) / 2.0); label15.Top = point + 10;
			cbFormat.Left = label15.Right + 10; cbFormat.Top = point + 12; cbFormat.SelectedIndex = 0;
			dgRips.Top = label15.Bottom + 10;
			DoRips();
			AutoScrollPosition = new Point(0, 0);
		}

		private void DoRips()
		{
			dgRips.Rows.Clear();
			switch (cbFormat.SelectedIndex)
			{
				case 0: creator = new MkvCreator(); break;
				case 1: creator = new AviCreator(); break;
				default: creator = new MkvCreator(); break;
			}
			FilmRip[] rips = creator.Create(film);
			for (int i = 0; i < rips.Length; i++)
			{
				dgRips.Rows.Add();
				dgRips.Rows[i].Cells[0].Value = rips[i].GetTitle();
				dgRips.Rows[i].Cells[1].Value = rips[i].GetVideo();
				dgRips.Rows[i].Cells[2].Value = rips[i].GetAudio();
				dgRips.Rows[i].Cells[3].Value = rips[i].GetSize();
			}
			dgRips.ClearSelection();
			dgRips.AutoSize = true;
		}

		private void CardForm_Shown(object sender, EventArgs e)
		{
			pbPoster.Image = null;
			pbRating.Image = null;
			Render();
			if (film.code == "") return;
			string poster = $"http://www.kinopoisk.ru/images/film_big/{film.code}.jpg";
			pbPoster.LoadAsync(poster);
			pbPoster.LoadCompleted += ((senderLoad, eLoad) =>
			{
				Render();
			});
			string rating = $"http://rating.kinopoisk.ru/{film.code}.gif";
			pbRating.LoadAsync(rating);
			pbRating.LoadCompleted += ((senderLoad, eLoad) =>
			{
				Render();
			});

		}

		private void lblLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try
			{
				if (film.link != "")
				{
					System.Diagnostics.Process.Start(film.link);
				}
			}
			catch
			{
				MessageBox.Show($"Невозможно перейти по ссылке: {film.link}");
			}
		}

		private void cbFormat_SelectedIndexChanged(object sender, EventArgs e)
		{
			DoRips();
		}
	}
}