namespace Films.Services
{
	interface IObservable
	{
		void AddObserver(IObserver observer);

		void RemoveObserver(IObserver observer);

		void NotifyObservers();
	}
}