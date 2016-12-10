using System;
using System.Globalization;

namespace Films.Rip
{
	public abstract class FilmRip
	{
		public abstract string GetTitle();

		public abstract string GetVideo();

		public abstract string GetAudio();

		public abstract string GetSize();

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