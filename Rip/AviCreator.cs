namespace Films.Rip
{
	public class AviCreator : RipCreator
	{
		public override FilmRip[] Create(Film film)
		{
			FilmRip[] rips = new FilmRip[2];
			rips[0] = new AviRip(film, "480p", 480, 0.200, 23.976, 64);
			rips[1] = new AviRip(film, "360p", 360, 0.200, 23.976, 64);
			return rips;
		}

		public override FilmRip[] Create(Film film, double qualityVideo, double fps, int qualityAudio)
		{
			FilmRip[] rips = new FilmRip[2];
			rips[0] = new AviRip(film, "480p", 480, qualityVideo, fps, qualityAudio);
			rips[1] = new AviRip(film, "360p", 360, qualityVideo, fps, qualityAudio);
			return rips;
		}
	}
}