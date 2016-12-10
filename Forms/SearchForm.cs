using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Films.Forms
{
	public struct Result
	{
		public string Title;
		public int Index;
	}

	public partial class SearchForm : Form
	{
		private static SearchForm instance;
		private MainForm frMain;
		private FilmsList films;
		private List<Result> arrayResult;

		private SearchForm()
		{
			InitializeComponent();
			frMain = MainForm.GetInstance();
		}

		public static SearchForm GetInstance()
		{
			if (instance == null)
			{
				instance = new SearchForm();
			}
			instance.films = instance.frMain.GetFilmsList();
			return instance;
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			lbResults.Items.Clear();
			string searchText = tbTitle.Text;
			if (searchText == "") {
				MessageBox.Show(@"Некорректный запрос!");
				return;
			}
			arrayResult = new List<Result>();
			for (int i = 0; i < films.Length; i++) {
				Film film = films.GetFilm(i);
				if (!film.russianTitle.Contains(searchText) && !film.originalTitle.Contains(searchText))
					continue;
				Result result = new Result
				{
					Index = i,
					Title = films.GetFilmDisplayedName(i)
				};
				arrayResult.Add(result);
				lbResults.Items.Add(result.Title);
			}
			MessageBox.Show(@"Поиск окончен!");
		}

		private void lbResults_DoubleClick(object sender, EventArgs e)
		{
			if (lbResults.SelectedIndex == -1)
				return;
			Result result = arrayResult[lbResults.SelectedIndex];
			frMain.SearchEvent(result.Index);
			Close();
		}
	}
}