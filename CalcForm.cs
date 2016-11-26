using System;
using System.Windows.Forms;
using System.Drawing;

namespace Films
{
  public partial class CalcForm : Form
  {
    Bitmap bmpOriginal;
    Bitmap bmp;
    bool analyzing;
    int left, up, right, down;
    public CalcForm()
    {
      InitializeComponent();
      bmpOriginal = null;
      bmp = null;
      analyzing = false;
      left = 0;
      up = 0;
      right = 0;
      down = 0;
    }

    private void btnCalc_Click(object sender, EventArgs e)
    {
      try {
        Film film = new Film();
        film.duration = dtDuration.Text;
        film.width = Convert.ToInt32(tbWidth.Text);
        film.height = Convert.ToInt32(tbHeight.Text);
        film.channels = Convert.ToInt32(tbChannels.Text);
        double qualityVideo = Convert.ToDouble(tbQualityVideo.Text);
        int qualityAudio = Convert.ToInt32(tbQualityAudio.Text);
        double fps = Convert.ToDouble(tbFPS.Text);
        FilmRip[] rip = new FilmRip[6];
        rip[0] = new FilmRip(film, "2160p", 2160, qualityVideo, fps, qualityAudio, film.channels);
        rip[1] = new FilmRip(film, "1080p", 1080, qualityVideo, fps, qualityAudio, film.channels);
        rip[2] = new FilmRip(film, "720p", 720, qualityVideo, fps, qualityAudio, film.channels);
        rip[3] = new FilmRip(film, "576p", 576, qualityVideo, fps, qualityAudio, film.channels);
        rip[4] = new FilmRip(film, "480p", 480, qualityVideo, fps, qualityAudio, 2);
        rip[5] = new FilmRip(film, "360p", 360, qualityVideo, fps, qualityAudio, 2);
        dgRips.Rows.Clear();
        for (int i = 0; i < 6; i++) {
          dgRips.Rows.Add();
          dgRips.Rows[i].Cells[0].Value = rip[i].GetTitle();
          dgRips.Rows[i].Cells[1].Value = rip[i].GetVideo();
          dgRips.Rows[i].Cells[2].Value = rip[i].GetAudio();
          dgRips.Rows[i].Cells[3].Value = rip[i].GetSize();
        }
        dgRips.ClearSelection();
        dgRips.AutoSize = true;
        tbVideoKbps.Text = ((int)Math.Round((Convert.ToDouble(tbWidth.Text) * Convert.ToDouble(tbHeight.Text) *
          Convert.ToDouble(tbFPS.Text) / 1000.0 * Convert.ToDouble(tbQualityVideo.Text)), 0)).ToString();
        tbAudioKbps.Text = (Convert.ToInt32(tbQualityAudio.Text) * Convert.ToInt32(tbChannels.Text)).ToString();
        tbTotalKbps.Text = (Convert.ToInt32(tbVideoKbps.Text) + Convert.ToInt32(tbAudioKbps.Text)).ToString();
        label21.Top = dgRips.Bottom; tbAdress.Top = dgRips.Bottom; btnLoad.Top = dgRips.Bottom;
        pbFrame.Width = 880; pbFrame.Height = 495; pbFrame.Top = label21.Bottom + 10; pbFrame.Left = (this.Width - pbFrame.Width) / 2;
        label14.Top = pbFrame.Bottom + 10; numLeft.Top = pbFrame.Bottom + 10;
        label15.Top = pbFrame.Bottom + 10; numUp.Top = pbFrame.Bottom + 10;
        label16.Top = pbFrame.Bottom + 10; numRight.Top = pbFrame.Bottom + 10;
        label17.Top = pbFrame.Bottom + 10; numDown.Top = pbFrame.Bottom + 10;
        btnAnalyse.Top = pbFrame.Bottom + 10; label18.Top = pbFrame.Bottom + 10;
      }
      catch {
        MessageBox.Show("Проверьте корректность заполнения всех полей!");
        return;
      }
    }

    private void btnLoad_Click(object sender, EventArgs e)
    {
      btnLoad.Enabled = false;
      var request = System.Net.WebRequest.Create(tbAdress.Text);
      var response = request.GetResponse();
      using  (var responseStream = response.GetResponseStream()) {
        bmpOriginal = new Bitmap(responseStream);
        bmp = new Bitmap((Image)bmpOriginal);
      }
      pbFrame.Image = (Image)bmp;
      pbFrame.SizeMode = PictureBoxSizeMode.Zoom;
      numLeft.Maximum = bmpOriginal.Width / 2;
      numUp.Maximum = bmpOriginal.Height / 2;
      numRight.Maximum = bmpOriginal.Width / 2;
      numDown.Maximum = bmpOriginal.Height / 2;
      numLeft.Value = 0;
      numUp.Value = 0;
      numRight.Value = 0;
      numDown.Value = 0;
      left = 0;
      up = 0;
      right = 0;
      down = 0;
      btnLoad.Enabled = true;
    }

    private bool IsBlack(Color c)
    {
      Color black = Color.Black;
      if (c.R - black.R > 10) {
        return false;
      }
      if (c.G - black.G > 10) {
        return false;
      }
      if (c.B - black.B > 10) {
        return false;
      }
      return true;
    }

    private void CalcForm_Shown(object sender, EventArgs e)
    {
      label21.Top = dgRips.Bottom; tbAdress.Top = dgRips.Bottom; btnLoad.Top = dgRips.Bottom;
      pbFrame.Width = 880; pbFrame.Height = 495; pbFrame.Top = label21.Bottom + 10; pbFrame.Left = (this.Width - pbFrame.Width) / 2;
      label14.Top = pbFrame.Bottom + 10; numLeft.Top = pbFrame.Bottom + 10;
      label15.Top = pbFrame.Bottom + 10; numUp.Top = pbFrame.Bottom + 10;
      label16.Top = pbFrame.Bottom + 10; numRight.Top = pbFrame.Bottom + 10;
      label17.Top = pbFrame.Bottom + 10; numDown.Top = pbFrame.Bottom + 10;
      btnAnalyse.Top = pbFrame.Bottom + 10; label18.Top = pbFrame.Bottom + 10;
    }

    private void ResizeBMP()
    {
      if (left < numLeft.Value) {
        for (int i = left; i < numLeft.Value; i++) {
          for (int j = up; j < bmp.Height - down; j++) {
            bmp.SetPixel(i, j, Color.White);
          }
        }
      }
      else {
        for (int i = left; i > numLeft.Value; i--) {
          for (int j = up; j < bmp.Height - down; j++) {
            bmp.SetPixel(i, j, bmpOriginal.GetPixel(i, j));
          }
        }
      }
      if (up < numUp.Value) {
        for (int j = up; j < numUp.Value; j++) {
          for (int i = left; i < bmp.Width - right; i++) {
            bmp.SetPixel(i, j, Color.White);
          }
        }
      }
      else {
        for (int j = up; j > numUp.Value; j--) {
          for (int i = left; i < bmp.Width - right; i++) {
            bmp.SetPixel(i, j, bmpOriginal.GetPixel(i, j));
          }
        }
      }
      if (right < numRight.Value) {
        for (int i = bmp.Width - 1 - right; i > bmp.Width - 1 - numRight.Value; i--) {
          for (int j = up; j < bmp.Height - down; j++) {
            bmp.SetPixel(i, j, Color.White);
          }
        }
      }
      else {
        for (int i = bmp.Width - 1 - right; i < bmp.Width - 1 - numRight.Value; i++) {
          for (int j = up; j < bmp.Height - down; j++) {
            bmp.SetPixel(i, j, bmpOriginal.GetPixel(i, j));
          }
        }
      }
      if (down < numDown.Value) {
        for (int j = bmp.Height - 1 - down; j > bmp.Height - 1 - numDown.Value; j--) {
          for (int i = left; i < bmp.Width - right; i++) {
            bmp.SetPixel(i, j, Color.White);
          }
        }
      }
      else {
        for (int j = bmp.Height - 1 - down; j < bmp.Height - 1 - numDown.Value; j++) {
          for (int i = left; i < bmp.Width - right; i++) {
            bmp.SetPixel(i, j, bmpOriginal.GetPixel(i, j));
          }
        }
      }
      left = (int)numLeft.Value;
      up = (int)numUp.Value;
      right = (int)numRight.Value;
      down = (int)numDown.Value;
      pbFrame.Image = (Image)bmp;
      label18.Text = bmp.Width.ToString() + " x " + bmp.Height.ToString() + " -> " +
        (bmp.Width - numLeft.Value - numRight.Value).ToString() + " x " + (bmp.Height - numUp.Value - numDown.Value).ToString();
    }

    private void btnAnalyse_Click(object sender, EventArgs e)
    {
      numLeft.Value = 0;
      numUp.Value = 0;
      numRight.Value = 0;
      numDown.Value = 0;
      left = 0;
      up = 0;
      right = 0;
      down = 0;
      btnAnalyse.Enabled = false;
      Application.DoEvents();
      analyzing = true;
      for (int i = 0; i < bmp.Width; i++) {
        for (int j = 0; j < bmp.Height; j++) {
          bmp.SetPixel(i, j, bmpOriginal.GetPixel(i, j));
        }
      }
      bool flag = false;
      for (int i = 0; i < bmp.Width / 2; i++) {
        flag = false;
        for (int j = 0; j < bmp.Height; j++) {
          if (!IsBlack(bmp.GetPixel(i, j))) {
            flag = true;
            break;
          }
        }
        if (flag) {
          numLeft.Value = i;
          break;
        }
      }
      for (int i = bmp.Width - 1; i > bmp.Width / 2; i--) {
        flag = false;
        for (int j = 0; j < bmp.Height; j++) {
          if (!IsBlack(bmp.GetPixel(i, j))) {
            flag = true;
            break;
          }
        }
        if (flag){
          numRight.Value = bmp.Width - 1 - i;
          break;
        }
      }
      for (int j = 0; j < bmp.Height / 2; j++) {
        flag = false;
        for (int i = 0; i < bmp.Width; i++) {
          if (!IsBlack(bmp.GetPixel(i, j))) {
            flag = true;
            break;
          }
        }
        if (flag) {
          numUp.Value = j;
          break;
        }
      }
      for (int j = bmp.Height - 1; j > bmp.Height / 2; j--) {
        flag = false;
        for (int i = 0; i < bmp.Width; i++) {
          if (!IsBlack(bmp.GetPixel(i, j))) {
            flag = true;
            break;
          }
        }
        if (flag) {
          numDown.Value = bmp.Height - 1 - j;
          break;
        }
      }
      ResizeBMP();
      analyzing = false;
      btnAnalyse.Enabled = true;
    }

    private void num_ValueChanged(object sender, EventArgs e)
    {
      if (analyzing) {
        return;
      }
      ResizeBMP();
    }
  }
}