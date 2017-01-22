using System;
using System.Collections;
using System.Threading;
using Films.Forms;

namespace Films.Services
{
	public class LogUnit
	{
		public FilmInfo filmInfo;
		public Film film;
	}

	public class UpdateStatus
	{
		public int countChecked;
		public int countChanged;
		public string title;
	}

	public class UpdateService
	{
		private static UpdateService instance;
		private ArrayList log;
		private Thread threadUpdate;
		private MainForm frMain;
		private FilmsList films;
		private int countChecked;
		private string title;

		private UpdateService()
		{
			log = ArrayList.Synchronized(new ArrayList());
			frMain = MainForm.GetInstance();
		}

		public static UpdateService GetInstance()
		{
			return instance ?? (instance = new UpdateService());
		}

		public void UpdateStatus()
		{
			frMain.UpdateEvent();
		}

		public void Start()
		{
			if (threadUpdate != null)
				return;
			log.Clear();
			films = frMain.GetFilmsList();
			threadUpdate = new Thread(Update);
			threadUpdate.IsBackground = true;
			threadUpdate.Start();
		}

		public void Stop()
		{
			threadUpdate?.Abort();
			threadUpdate = null;
		}

		public ArrayList GetLog()
		{
			return log;
		}

		public UpdateStatus GetStatus()
		{
			UpdateStatus status = new UpdateStatus
			{
				countChecked = countChecked,
				countChanged = log.Count,
				title = title
			};
			return status;
		}

		private void Update()
		{
			countChecked = 0;
			for (int i = films.Length - 1; i > -1; i--)
			{
				Film film = films.GetFilm(i);
				title = films.GetFilmDisplayedName(i);
				UpdateStatus();
				if (film.code == "")
				{
					continue;
				}
				DateTime dtPremiere = Convert.ToDateTime(films.GetFilmReleaseDate(i));
				DateTime dtNow = DateTime.Now;
				DateTime dtCheck = Convert.ToDateTime(film.dataCheck);
				TimeSpan ts1 = dtNow - dtPremiere;
				TimeSpan ts2 = dtNow - dtCheck;
				if (ts1.TotalDays / 10.0 > ts2.TotalDays)
				{
					continue;
				}
				countChecked++;
				FilmInfo filmInfo;
				try
				{
					filmInfo = ParsingService.GetFilmInfo(film.code);
				}
				catch
				{
					continue;
				}
				if (filmInfo.originalTitle != film.originalTitle || 
					filmInfo.year != film.year || 
					filmInfo.country != film.country || 
					filmInfo.director != film.director || 
					filmInfo.genre != film.genre || 
					filmInfo.actors != film.actors || 
					filmInfo.worldPremiere != film.worldDate || 
					filmInfo.russianPremiere != film.russianDate || 
					filmInfo.discPremiere != film.discDate)
				{
					LogUnit logUnit = new LogUnit
					{
						filmInfo = filmInfo,
						film = film
					};
					log.Add(logUnit);
				}
				else
				{
					film.dataCheck = DateTime.Now.ToString();
					films.Edit(film, i);
				}
			}
			title = "";
			UpdateStatus();
		}
	}
}