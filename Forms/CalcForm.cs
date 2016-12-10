using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Net;
using Films.Rip;

namespace Films.Forms
{
	public partial class CalcForm : Form
	{
		private static CalcForm instance;
		private Bitmap bmpOriginal;
		private Bitmap bmp;
		private bool analyzing;
		private int left, up, right, down;
		private int sensetivity;

		private CalcForm()
		{
			InitializeComponent();
			bmpOriginal = null;
			bmp = null;
			analyzing = false;
			left = 0;
			up = 0;
			right = 0;
			down = 0;
			sensetivity = (int) numSensitivity.Value;
		}

		public static CalcForm GetInstance()
		{
			return instance ?? (instance = new CalcForm());
		}

		private void btnCalc_Click(object sender, EventArgs e)
		{
			try {
				Film film = new Film
				{
					duration = dtDuration.Text,
					width = Convert.ToInt32(tbWidth.Text),
					height = Convert.ToInt32(tbHeight.Text),
					channels = Convert.ToInt32(tbChannels.Text)
				};
				double qualityVideo = Convert.ToDouble(tbQualityVideo.Text);
				double fps = Convert.ToDouble(tbFPS.Text);
				int qualityAudio = Convert.ToInt32(tbQualityAudio.Text);
				dgRips.Rows.Clear();
				RipCreator creator = new MkvCreator();
				FilmRip[] rips = creator.Create(film, qualityVideo, fps, qualityAudio);
				for (int i = 0; i < rips.Length; i++) {
					dgRips.Rows.Add();
					dgRips.Rows[i].Cells[0].Value = rips[i].GetTitle();
					dgRips.Rows[i].Cells[1].Value = rips[i].GetVideo();
					dgRips.Rows[i].Cells[2].Value = rips[i].GetAudio();
					dgRips.Rows[i].Cells[3].Value = rips[i].GetSize();
				}
				dgRips.ClearSelection();
				dgRips.AutoSize = true;
				tbVideoKbps.Text = ((int) Math.Round((Convert.ToDouble(tbWidth.Text) * Convert.ToDouble(tbHeight.Text) *
					Convert.ToDouble(tbFPS.Text) / 1000.0 * Convert.ToDouble(tbQualityVideo.Text)), 0)).ToString();
				tbAudioKbps.Text = (Convert.ToInt32(tbQualityAudio.Text) * Convert.ToInt32(tbChannels.Text)).ToString();
				tbTotalKbps.Text = (Convert.ToInt32(tbVideoKbps.Text) + Convert.ToInt32(tbAudioKbps.Text)).ToString();
				label21.Top = dgRips.Bottom; tbAdress.Top = dgRips.Bottom; btnLoad.Top = dgRips.Bottom;
				pbFrame.Width = 880; pbFrame.Height = 495; pbFrame.Top = label21.Bottom + 10; pbFrame.Left = (Width - pbFrame.Width) / 2;
				label14.Top = pbFrame.Bottom + 10; numLeft.Top = pbFrame.Bottom + 10;
				label15.Top = pbFrame.Bottom + 10; numUp.Top = pbFrame.Bottom + 10;
				label16.Top = pbFrame.Bottom + 10; numRight.Top = pbFrame.Bottom + 10;
				label17.Top = pbFrame.Bottom + 10; numDown.Top = pbFrame.Bottom + 10;
				label19.Top = label17.Bottom + 10; numSensitivity.Top = label17.Bottom + 10;
				btnAnalyse.Top = pbFrame.Bottom + 10; label18.Top = pbFrame.Bottom + 10;
			}
			catch {
				MessageBox.Show(@"Проверьте корректность заполнения всех полей!");
			}
		}

		private void btnLoad_Click(object sender, EventArgs e)
		{
			WebRequest request;
			try
			{
				request = WebRequest.Create(tbAdress.Text);
			}
			catch
			{
				MessageBox.Show(@"Проверьте корректность заполнения всех полей!");
				return;
			}
			btnLoad.Enabled = false;
			try
			{
				WebResponse response = request.GetResponse();
				using (Stream responseStream = response.GetResponseStream())
				{
					if (responseStream == null)
					{
						throw new Exception();
					}
					bmpOriginal = new Bitmap(responseStream);
					bmp = new Bitmap(bmpOriginal);
				}
			}
			catch
			{
				MessageBox.Show(@"Невозможо загрузить изображение!");
				btnLoad.Enabled = true;
				return;
			}
			pbFrame.Image = bmp;
			pbFrame.SizeMode = PictureBoxSizeMode.Zoom;
			numLeft.Maximum = bmpOriginal.Width / 2;
			numUp.Maximum = bmpOriginal.Height / 2;
			numRight.Maximum = bmpOriginal.Width / 2;
			numDown.Maximum = bmpOriginal.Height / 2;
			numLeft.Value = 0;
			numUp.Value = 0;
			numRight.Value = 0;
			numDown.Value = 0;
			numSensitivity.Value = 20;
			left = 0;
			up = 0;
			right = 0;
			down = 0;
			sensetivity = (int) numSensitivity.Value;
			btnLoad.Enabled = true;
		}

		private bool IsBlack(Color color)
		{
			Color black = Color.Black;
			if (color.R - black.R > sensetivity) {
				return false;
			}
			if (color.G - black.G > sensetivity) {
				return false;
			}
			return color.B - black.B <= sensetivity;
		}

		private void CalcForm_Shown(object sender, EventArgs e)
		{
			label21.Top = dgRips.Bottom; tbAdress.Top = dgRips.Bottom; btnLoad.Top = dgRips.Bottom;
			pbFrame.Width = 880; pbFrame.Height = 495; pbFrame.Top = label21.Bottom + 10; pbFrame.Left = (Width - pbFrame.Width) / 2;
			label14.Top = pbFrame.Bottom + 10; numLeft.Top = pbFrame.Bottom + 10;
			label15.Top = pbFrame.Bottom + 10; numUp.Top = pbFrame.Bottom + 10;
			label16.Top = pbFrame.Bottom + 10; numRight.Top = pbFrame.Bottom + 10;
			label17.Top = pbFrame.Bottom + 10; numDown.Top = pbFrame.Bottom + 10;
			label19.Top = label17.Bottom + 10; numSensitivity.Top = label17.Bottom + 10;
			btnAnalyse.Top = pbFrame.Bottom + 10; label18.Top = pbFrame.Bottom + 10;
		}

		private void ResizeBitMap()
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
			left = (int) numLeft.Value;
			up = (int) numUp.Value;
			right = (int) numRight.Value;
			down = (int) numDown.Value;
			pbFrame.Image = bmp;
			label18.Text = $"{bmp.Width} x {bmp.Height} -> {bmp.Width - numLeft.Value - numRight.Value} x {bmp.Height - numUp.Value - numDown.Value}";
		}

		private void btnAnalyse_Click(object sender, EventArgs e)
		{
			if (bmp == null || bmpOriginal == null)
			{
				MessageBox.Show(@"Невозможно анализировать данное изображение! Попробуйте загрузить его еще раз!");
				return;
			}
			numLeft.Value = 0;
			numUp.Value = 0;
			numRight.Value = 0;
			numDown.Value = 0;
			left = 0;
			up = 0;
			right = 0;
			down = 0;
			sensetivity = (int) numSensitivity.Value;
			btnAnalyse.Enabled = false;
			Application.DoEvents();
			analyzing = true;
			for (int i = 0; i < bmp.Width; i++) {
				for (int j = 0; j < bmp.Height; j++) {
					bmp.SetPixel(i, j, bmpOriginal.GetPixel(i, j));
				}
			}
			bool flag;
			for (int i = 0; i < bmp.Width / 2; i++) {
				flag = false;
				for (int j = 0; j < bmp.Height; j++) {
					if (IsBlack(bmp.GetPixel(i, j))) continue;
					flag = true;
					break;
				}
				if (!flag) continue;
				numLeft.Value = i;
				break;
			}
			for (int i = bmp.Width - 1; i > bmp.Width / 2; i--) {
				flag = false;
				for (int j = 0; j < bmp.Height; j++) {
					if (IsBlack(bmp.GetPixel(i, j))) continue;
					flag = true;
					break;
				}
				if (!flag) continue;
				numRight.Value = bmp.Width - 1 - i;
				break;
			}
			for (int j = 0; j < bmp.Height / 2; j++) {
				flag = false;
				for (int i = 0; i < bmp.Width; i++) {
					if (IsBlack(bmp.GetPixel(i, j))) continue;
					flag = true;
					break;
				}
				if (!flag) continue;
				numUp.Value = j;
				break;
			}
			for (int j = bmp.Height - 1; j > bmp.Height / 2; j--) {
				flag = false;
				for (int i = 0; i < bmp.Width; i++) {
					if (IsBlack(bmp.GetPixel(i, j))) continue;
					flag = true;
					break;
				}
				if (!flag) continue;
				numDown.Value = bmp.Height - 1 - j;
				break;
			}
			ResizeBitMap();
			analyzing = false;
			btnAnalyse.Enabled = true;
		}

		private void num_ValueChanged(object sender, EventArgs e)
		{
			if (!analyzing) {
				ResizeBitMap();
			}
		}
	}
}