namespace Films.Rip
{
	public abstract class RipCreator
	{
		public abstract FilmRip[] Create(Film film);

		public abstract FilmRip[] Create(Film film, double qualityVideo, double fps, int qualityAudio);
	}
}