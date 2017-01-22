using System;
using System.Globalization;
using Films.Services;

namespace Films
{
	public class FilmRip
	{
		private Film film;
		private string title;
		private int maxHeight;
		private double qualityVideo;
		private double fps;
		private int qualityAudio;
		private int maxChannels;
		private int width, height;
		private int videoKbps, audioKbps;
		private int channels;

		public FilmRip(Film film, string title, int maxHeight, double qualityVideo, double fps, int qualityAudio, int maxChannels)
		{
			this.film = film;
			this.title = title;
			this.maxHeight = maxHeight;
			this.qualityVideo = qualityVideo;
			this.fps = fps;
			this.qualityAudio = qualityAudio;
			this.maxChannels = maxChannels;
		}

		public string GetTitle()
		{
			return title;
		}

		public string GetVideo()
		{
			double aspect = film.width / (double) film.height;
			if (aspect < 1.777) {
				height = film.height < maxHeight ? film.height : maxHeight;
				width = (int) (height / (double) film.height * film.width);
				if (width % 2 != 0) {
					width++;
				}
			}
			else {
				width = (int) (1.778 * maxHeight);
				if (width % 2 != 0) {
					width++;
				}
				if (width >= film.width) {
					width = film.width;
				}
				height = (int) (width / (double) film.width * film.height);
				if (height % 2 != 0) {
					height++;
				}
			}
			videoKbps = (int) Math.Round(width * (double) height * fps / 1000.0 * qualityVideo, 0);
			return $"{width}x{height}, {videoKbps} Kbps, {fps} fps";
		}

		public string GetAudio()
		{
			channels = film.channels < maxChannels ? film.channels : maxChannels;
			audioKbps = qualityAudio * channels;
			return $"{channels} ch, {audioKbps} Kbps";
		}

		public string GetSize()
		{
			return RipService.GetRipSize(film.duration, videoKbps, audioKbps, width, height, fps);
		}
	}
}