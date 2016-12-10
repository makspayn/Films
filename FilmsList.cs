using System;
using System.Collections.Generic;
using System.Drawing;

namespace Films
{
	public struct Film
	{
		public string russianTitle;
		public string originalTitle;
		public string year;
		public string country;
		public string genre;
		public string director;
		public string actors;
		public string worldDate;
		public string russianDate;
		public string discDate;
		public string description;
		public string link;
		public string code;
		public int width;
		public int height;
		public string duration;
		public string qualityTitle;
		public string qualityPixel;
		public string translateTitle;
		public string translateComment;
		public string Color;
		public string videoCodec;
		public int originalWidth;
		public int originalHeight;
		public int videoKbps;
		public double fps;
		public string audioCodec;
		public int channels;
		public int audioKbps;
		public string dataCheck;
	}

	public class FilmsList
	{
		private List<Film> films;

		public FilmsList()
		{
			films = new List<Film>();
		}

		public void Add(Film film)
		{
			films.Add(film);
		}

		public void Insert(Film film, int index)
		{
			films.Insert(index, film);
		}

		public void Edit(Film film, int index)
		{
			films[index] = film;
		}

		public void Delete(int index)
		{
			films.RemoveAt(index);
		}

		public Film GetFilm(int index)
		{
			return films[index];
		}

		public string GetFilmDisplayedName(int index)
		{
			return GetFilmDisplayedName(films[index]);
		}

		public string GetFilmDisplayedName(Film film)
		{
			return film.originalTitle == "" ? $"{film.russianTitle} ({film.year})" :
				$"{film.russianTitle} / {film.originalTitle} ({film.year})";
		}

		public string GetFilmReleaseDate(int index)
		{
			Film film = films[index];
			if (film.worldDate == "" && film.russianDate == "")
			{
				return DateTime.Now.ToShortDateString();
			}
			return film.russianDate == "" ? film.worldDate : film.russianDate;
		}

		public string GetFilmQuality(int index)
		{
			Film film = films[index];
			string quality = $"{film.qualityTitle} {film.qualityPixel} {film.videoKbps} Kbps, {film.audioCodec} {film.channels} ch {film.audioKbps} Kbps - {film.translateTitle} {film.translateComment}";
			return quality;
		}

		public Color GetFilmColor(int index)
		{
			Film film = films[index];
			switch (film.Color)
			{
				case "Хороший":
					return Color.LightGreen;
				case "Нейтральный":
					return Color.Yellow;
				case "Плохой":
					return Color.IndianRed;
				default:
					return Color.White;
			}
		}

		public Film GetCopyFilm(Film film)
		{
			Film newFilm = new Film
			{
				russianTitle = film.russianTitle,
				originalTitle = film.originalTitle,
				year = film.year,
				country = film.country,
				genre = film.genre,
				director = film.director,
				actors = film.actors,
				worldDate = film.worldDate,
				russianDate = film.russianDate,
				discDate = film.discDate,
				description = film.description,
				link = film.link,
				code = film.code,
				width = film.width,
				height = film.height,
				duration = film.duration,
				qualityTitle = film.qualityTitle,
				qualityPixel = film.qualityPixel,
				translateTitle = film.translateTitle,
				translateComment = film.translateComment,
				Color = film.Color,
				videoCodec = film.videoCodec,
				originalWidth = film.originalWidth,
				originalHeight = film.originalHeight,
				videoKbps = film.videoKbps,
				fps = film.fps,
				audioCodec = film.audioCodec,
				channels = film.channels,
				audioKbps = film.audioKbps,
				dataCheck = film.dataCheck
			};
			return newFilm;
		}

		public Film GetCopyFilm(int index)
		{
			return GetCopyFilm(films[index]);
		}

		public Film[] GetArray()
		{
			return films.ToArray();
		}

		public int Length => films.Count;
	}
}