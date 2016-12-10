using System;

namespace Films.Rip
{
	public class AviRip : FilmRip
	{
		private Film film;
		private string title;
		private int maxHeight;
		private double qualityVideo;
		private double fps;
		private int qualityAudio;
		private int width, height;
		private int videoKbps, audioKbps;

		public AviRip(Film film, string title, int maxHeight, double qualityVideo, double fps, int qualityAudio)
		{
			this.film = film;
			this.title = title;
			this.maxHeight = maxHeight;
			this.qualityVideo = qualityVideo;
			this.fps = fps;
			this.qualityAudio = qualityAudio;
		}

		public override string GetTitle()
		{
			return title;
		}

		public override string GetVideo()
		{
			double aspect = film.width / (double) film.height;
			if (aspect < 1.777)
			{
				height = film.height < maxHeight ? film.height : maxHeight;
				width = (int) (height / (double) film.height * film.width);
				if (width % 2 != 0)
				{
					width++;
				}
			}
			else
			{
				width = (int) (1.778 * maxHeight);
				if (width % 2 != 0)
				{
					width++;
				}
				if (width >= film.width)
				{
					width = film.width;
				}
				height = (int) (width / (double) film.width * film.height);
				if (height % 2 != 0)
				{
					height++;
				}
			}
			videoKbps = (int)Math.Round(width * (double) height * fps / 1000.0 * qualityVideo, 0);
			return $"{width}x{height}, {videoKbps} Kbps, {fps} fps";
		}

		public override string GetAudio()
		{
			audioKbps = qualityAudio * 2;
			return $"{2} ch, {audioKbps} Kbps";
		}

		public override string GetSize()
		{
			return GetRipSize(film.duration, videoKbps, audioKbps, width, height, fps);
		}
	}
}