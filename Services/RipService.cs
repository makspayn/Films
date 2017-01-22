using System;
using System.Globalization;

namespace Films.Services
{
	public static class RipService
	{
		public static FilmRip[] CreateRip(Film film)
		{
			FilmRip[] rips = new FilmRip[6];
			rips[0] = new FilmRip(film, "2160p", 2160, 0.100, 23.976, 64, film.channels);
			rips[1] = new FilmRip(film, "1080p", 1080, 0.100, 23.976, 64, film.channels);
			rips[2] = new FilmRip(film, "720p", 720, 0.100, 23.976, 64, film.channels);
			rips[3] = new FilmRip(film, "576p", 576, 0.100, 23.976, 64, film.channels);
			rips[4] = new FilmRip(film, "480p", 480, 0.100, 23.976, 64, 2);
			rips[5] = new FilmRip(film, "360p", 360, 0.100, 23.976, 64, 2);
			return rips;
		}

		public static FilmRip[] CreateRip(Film film, double qualityVideo, double fps, int qualityAudio)
		{
			FilmRip[] rips = new FilmRip[6];
			rips[0] = new FilmRip(film, "2160p", 2160, qualityVideo, fps, qualityAudio, film.channels);
			rips[1] = new FilmRip(film, "1080p", 1080, qualityVideo, fps, qualityAudio, film.channels);
			rips[2] = new FilmRip(film, "720p", 720, qualityVideo, fps, qualityAudio, film.channels);
			rips[3] = new FilmRip(film, "576p", 576, qualityVideo, fps, qualityAudio, film.channels);
			rips[4] = new FilmRip(film, "480p", 480, qualityVideo, fps, qualityAudio, 2);
			rips[5] = new FilmRip(film, "360p", 360, qualityVideo, fps, qualityAudio, 2);
			return rips;
		}

		public static string GetRipSize(string duration, int videoKbps, int audioKbps, int width, int height, double fps)
		{
			try
			{
				DateTime time = Convert.ToDateTime(duration);
				double bpp = videoKbps / (width * (double)height * fps) * 1000.0;
				double kb = Math.Round((videoKbps + audioKbps) * 125.0 * (time.Hour * 3600 + time.Minute * 60 + time.Second) / 1024.0, 0);
				double mb = Math.Round(kb / 1024.0, 2);
				double gb = Math.Round(mb / 1024.0, 2);
				return gb.ToString("N", CultureInfo.CreateSpecificCulture("fr-CA")) + " Gb (" +
					mb.ToString("N", CultureInfo.CreateSpecificCulture("fr-CA")) + " Mb) (" +
					kb.ToString("N", CultureInfo.CreateSpecificCulture("fr-CA")) + " Kb) " + bpp.ToString("0.000") + " bpp";
			}
			catch
			{
				return "";
			}
		}
	}
}