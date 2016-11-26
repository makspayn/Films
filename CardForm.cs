using System;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;

namespace Films
{
  public partial class CardForm : Form
  {
    public Film film;
    public CardForm(Film f)
    {
      InitializeComponent();
      film = f;
    }

    static public String GetSize(String duration, int videoKbps, int audioKbps, int width, int height, double fps)
    {
      try {
        DateTime time = Convert.ToDateTime(duration);
        double bpp = (double)videoKbps / (double)((double)width * (double)height * (double)fps) * 1000.0;
        double Kb = Math.Round((double)(videoKbps + audioKbps) * 125.0 * (double)(time.Hour * 3600 + time.Minute * 60 + time.Second) / 1024.0, 0);
        double Mb = Math.Round(Kb / 1024.0, 2);
        double Gb = Math.Round(Mb / 1024.0, 2);
        return Gb.ToString("N", CultureInfo.CreateSpecificCulture("fr-CA")) + " Gb (" +
          Mb.ToString("N", CultureInfo.CreateSpecificCulture("fr-CA")) + " Mb) (" +
          Kb.ToString("N", CultureInfo.CreateSpecificCulture("fr-CA")) + " Kb) " + bpp.ToString("0.000") + " bpp";
      }
      catch {
        return "";
      }
    }

    private void CardForm_Shown(object sender, EventArgs e)
    {
      String str = "";
      if (film.originalTitle == "") {
        str = film.russianTitle + " (" + film.year + ")";
      }
      else {
        str = film.russianTitle + " / " + film.originalTitle + " (" + film.year + ")";
      }
      lblTitle.Text = str; lblTitle.Left = (int)((this.Size.Width - lblTitle.Size.Width) / 2.0);
      if (film.code != "") {
        try {
          String poster = "http://www.kinopoisk.ru/images/film_big/" + film.code + ".jpg";
          pbPoster.Top = lblTitle.Bottom + 10;
          pbPoster.Load(poster);
          pbPoster.ClientSize = new Size(400, (int)((double)(pbPoster.Image.Height) / (double)(pbPoster.Image.Width) * 400.0));
          pbPoster.SizeMode = PictureBoxSizeMode.StretchImage;
          String rating = "http://rating.kinopoisk.ru/" + film.code + ".gif";
          pbRating.Top = pbPoster.Bottom + 10;
          pbRating.Load(rating);
        }
        catch {

        }
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
      lblQuality.Text = film.qualityTitle + " " + film.qualityPixel; label10.Top = lblDuration.Bottom; lblQuality.Top = lblDuration.Bottom;
      lblTranslate.Text = film.translateTitle + " (" + film.translateComment + ")"; label11.Top = lblQuality.Bottom; lblTranslate.Top = lblQuality.Bottom;
      lblVideo.Text = film.videoCodec + ", " + film.originalWidth.ToString() + "x" + film.originalHeight.ToString() + ", " + 
        film.videoKbps.ToString() + " Kbps, " + film.fps.ToString() + " fps"; label12.Top = lblTranslate.Bottom; lblVideo.Top = lblTranslate.Bottom;
      lblAudio.Text = film.audioCodec + ", " + film.channels.ToString() + " ch, " + 
        film.audioKbps.ToString() + " Kbps"; label13.Top = lblVideo.Bottom; lblAudio.Top = lblVideo.Bottom;
      lblSize.Text = GetSize(film.duration, film.videoKbps, film.audioKbps, film.originalWidth, film.originalHeight, film.fps);
      label14.Top = lblAudio.Bottom; lblSize.Top = lblAudio.Bottom;
      int point = label14.Bottom;
      if (lblLink.Bottom > point) {
        point = lblLink.Bottom;
      }
      label15.Left = (int)((this.Size.Width - label15.Size.Width) / 2.0); label15.Top = point + 10;
      dgRips.Top = label15.Bottom + 10;
      FilmRip[] rip = new FilmRip[6];
      rip[0] = new FilmRip(film, "2160p", 2160, 0.100, 23.976, 64, film.channels);
      rip[1] = new FilmRip(film, "1080p", 1080, 0.100, 23.976, 64, film.channels);
      rip[2] = new FilmRip(film, "720p", 720, 0.100, 23.976, 64, film.channels);
      rip[3] = new FilmRip(film, "576p", 576, 0.100, 23.976, 64, film.channels);
      rip[4] = new FilmRip(film, "480p", 480, 0.100, 23.976, 64, 2);
      rip[5] = new FilmRip(film, "360p", 360, 0.100, 23.976, 64, 2);
      for (int i = 0; i < 6; i++) {
        dgRips.Rows.Add();
        dgRips.Rows[i].Cells[0].Value = rip[i].GetTitle();
        dgRips.Rows[i].Cells[1].Value = rip[i].GetVideo();
        dgRips.Rows[i].Cells[2].Value = rip[i].GetAudio();
        dgRips.Rows[i].Cells[3].Value = rip[i].GetSize();
      }
      dgRips.ClearSelection();
      dgRips.AutoSize = true;
      this.AutoScrollPosition = new System.Drawing.Point(0, 0);
    }

    private void lblLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      if (film.link != "") {
        System.Diagnostics.Process.Start(film.link);
      }
    }
  }
}