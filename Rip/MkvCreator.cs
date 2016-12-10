namespace Films.Rip
{
	public class MkvCreator : RipCreator
	{
		public override FilmRip[] Create(Film film)
		{
			FilmRip[] rips = new FilmRip[6];
			rips[0] = new MkvRip(film, "2160p", 2160, 0.100, 23.976, 64, film.channels);
			rips[1] = new MkvRip(film, "1080p", 1080, 0.100, 23.976, 64, film.channels);
			rips[2] = new MkvRip(film, "720p", 720, 0.100, 23.976, 64, film.channels);
			rips[3] = new MkvRip(film, "576p", 576, 0.100, 23.976, 64, film.channels);
			rips[4] = new MkvRip(film, "480p", 480, 0.100, 23.976, 64, 2);
			rips[5] = new MkvRip(film, "360p", 360, 0.100, 23.976, 64, 2);
			return rips;
		}

		public override FilmRip[] Create(Film film, double qualityVideo, double fps, int qualityAudio)
		{
			FilmRip[] rips = new FilmRip[6];
			rips[0] = new MkvRip(film, "2160p", 2160, qualityVideo, fps, qualityAudio, film.channels);
			rips[1] = new MkvRip(film, "1080p", 1080, qualityVideo, fps, qualityAudio, film.channels);
			rips[2] = new MkvRip(film, "720p", 720, qualityVideo, fps, qualityAudio, film.channels);
			rips[3] = new MkvRip(film, "576p", 576, qualityVideo, fps, qualityAudio, film.channels);
			rips[4] = new MkvRip(film, "480p", 480, qualityVideo, fps, qualityAudio, 2);
			rips[5] = new MkvRip(film, "360p", 360, qualityVideo, fps, qualityAudio, 2);
			return rips;
		}
	}
}