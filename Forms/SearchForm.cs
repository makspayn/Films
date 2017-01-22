using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Films.Forms
{
	public class Result
	{
		public string Title;
		public int Index;
	}

	public partial class SearchForm : Form
	{
		private MainForm frMain;
		private FilmsList films;
		private List<Result> arrayResult;

		public SearchForm()
		{
			InitializeComponent();
			frMain = MainForm.GetInstance();
			films = frMain.GetFilmsList();
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
				string russianTitle = film.russianTitle.ToLower();
				string originalTitle = film.originalTitle.ToLower();
				if (!russianTitle.Contains(searchText.ToLower()) && 
					!originalTitle.Contains(searchText.ToLower()))
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

		private void tbTitle_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == 0xD)
			{
				btnSearch.PerformClick();
			}
		}
	}
}