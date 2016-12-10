using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Films.Forms;

namespace Films.Services
{
	public struct LogUnit
	{
		public FilmInfo filmInfo;
		public int filmIndex;
	}

	public struct UpdateStatus
	{
		public int countChecked;
		public int countChanged;
		public string title;
	}

	class UpdateService : IObservable
	{
		private static UpdateService instance;
		private List<IObserver> observers;
		private ArrayList log;
		private Thread threadUpdate;
		private MainForm frMain;
		private FilmsList films;
		private int countChecked;
		private string title;

		private UpdateService()
		{
			observers = new List<IObserver>();
			log = ArrayList.Synchronized(new ArrayList());
			frMain = MainForm.GetInstance();
		}

		public static UpdateService GetInstance()
		{
			return instance ?? (instance = new UpdateService());
		}

		public void AddObserver(IObserver observer)
		{
			if (!observers.Contains(observer))
			{
				observers.Add(observer);
			}
		}

		public void RemoveObserver(IObserver observer)
		{
			if (observers.Contains(observer))
			{
				observers.Remove(observer);
			}
		}

		public void NotifyObservers()
		{
			foreach (IObserver observer in observers)
			{
				observer.UpdateEvent();
			}
		}

		public void Start()
		{
			films = frMain.GetFilmsList();
			if (threadUpdate != null)
				return;
			threadUpdate = new Thread(Update);
			log.Clear();
			threadUpdate.Start();
		}

		public void Stop()
		{
			if (threadUpdate == null)
				return;
			threadUpdate.Abort();
			threadUpdate = null;
		}

		public ArrayList GetLog()
		{
			return log;
		}

		public UpdateStatus GetStatus()
		{
			UpdateStatus status = new UpdateStatus();
			status.countChecked = countChecked;
			status.countChanged = log.Count;
			status.title = title;
			return status;
		}

		private void Update()
		{
			countChecked = 0;
			for (int i = films.Length - 1; i > -1; i--)
			{
				Film film = films.GetFilm(i);
				title = films.GetFilmDisplayedName(i);
				NotifyObservers();
				if (film.code == "")
				{
					continue;
				}
				DateTime dtPremiere = Convert.ToDateTime(films.GetFilmReleaseDate(i));
				DateTime dtNow = DateTime.Now;
				DateTime dtCheck = Convert.ToDateTime(film.dataCheck);
				TimeSpan ts1 = dtNow - dtPremiere;
				TimeSpan ts2 = dtNow - dtCheck;
				if ((ts1.TotalDays / 10.0) > ts2.TotalDays)
				{
					continue;
				}
				countChecked++;
				bool flag = false;
				FilmInfo filmInfo = ParsingService.GetInstance().GetFilmInfo(film.code);
				if (filmInfo.originalTitle != film.originalTitle)
				{
					flag = true;
				}
				if (filmInfo.year != film.year)
				{
					flag = true;
				}
				if (filmInfo.country != film.country)
				{
					flag = true;
				}
				if (filmInfo.director != film.director)
				{
					flag = true;
				}
				if (filmInfo.genre != film.genre)
				{
					flag = true;
				}
				if (filmInfo.actors != film.actors)
				{
					flag = true;
				}
				if (filmInfo.worldPremiere != film.worldDate)
				{
					flag = true;
				}
				if (filmInfo.russianPremiere != film.russianDate)
				{
					flag = true;
				}
				if (filmInfo.discPremiere != film.discDate)
				{
					flag = true;
				}
				if (flag)
				{
					LogUnit logUnit = new LogUnit
					{
						filmInfo = filmInfo,
						filmIndex = i
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
			NotifyObservers();
		}
	}
}