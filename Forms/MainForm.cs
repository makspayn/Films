using System;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using Films.Services;

namespace Films.Forms
{
	public partial class MainForm : Form
	{
		private static MainForm instance;
		private FilmsList films;
		private UpdateService updateService;
		private bool changed;

		private MainForm()
		{
			InitializeComponent();
			films = new FilmsList();
			changed = false;
			CheckForIllegalCrossThreadCalls = false;
		}

		public static MainForm GetInstance()
		{
			return instance ?? (instance = new MainForm());
		}

		public void UpdateEvent()
		{
			UpdateStatus status = updateService.GetStatus();
			lblFilm.Text = $"Проверяется: {status.title}";
			lblFilms.Text = $"Проверено: {status.countChecked} " +
			                $"Изменения: {status.countChanged}";
		}

		public void SearchEvent(int index)
		{
			dgFilms.CurrentCell = dgFilms.Rows[index].Cells[0];
			dgFilms.Rows[index].Selected = true;
		}

		public void FilmUpdateEvent(int index)
		{
			FilmToForm(index);
		}

		public FilmsList GetFilmsList()
		{
			return films;
		}

		private void FilmToForm(int index)
		{
			Film film = films.GetFilm(index);
			dgFilms.Rows[index].Cells[0].Value = films.GetFilmDisplayedName(index);
			dgFilms.Rows[index].Cells[1].Value = films.GetFilmReleaseDate(index);
			dgFilms.Rows[index].Cells[2].Value = film.discDate;
			dgFilms.Rows[index].Cells[3].Value = films.GetFilmQuality(index);
			dgFilms.Rows[index].Cells[3].Style.BackColor = films.GetFilmColor(index);
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			dgFilms.Rows.Add();
			films.Add(new Film());
			new EditForm(dgFilms.Rows.Count - 1).ShowDialog();
			FilmToForm(dgFilms.Rows.Count - 1);
			changed = true;
		}

		private void btnInsert_Click(object sender, EventArgs e)
		{
			if (dgFilms.CurrentRow != null)
			{
				Film film = new Film();
				dgFilms.Rows.Insert(dgFilms.CurrentRow.Index, 1);
				films.Insert(film, dgFilms.CurrentRow.Index - 1);
				new EditForm(dgFilms.CurrentRow.Index - 1).ShowDialog();
				FilmToForm(dgFilms.CurrentRow.Index - 1);
				changed = true;
			}
			else
			{
				btnAdd.PerformClick();
			}
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			if (dgFilms.CurrentRow == null)
				return;
			new EditForm(dgFilms.CurrentRow.Index).ShowDialog();
			FilmToForm(dgFilms.CurrentRow.Index);
			changed = true;
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			if (dgFilms.CurrentRow == null)
				return;
			films.Delete(dgFilms.CurrentRow.Index);
			dgFilms.Rows.RemoveAt(dgFilms.CurrentRow.Index);
			changed = true;
		}

		private void btnOpen_Click(object sender, EventArgs e)
		{
			if (changed)
			{
				if (MessageBox.Show(@"Отменить сохранения?", @"Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
				{
					return;
				}
			}
			if (!File.Exists("Фильмы.xml"))
			{
				MessageBox.Show(@"Файл 'Фильмы.xml' не был найден!");
				return;
			}
			updateService = UpdateService.GetInstance();
			updateService.Stop();
			btnOpen.Enabled = false;
			dgFilms.Rows.Clear();
			films = new FilmsList();
			FileStream fileFilms = File.Open("Фильмы.xml", FileMode.Open);
			XmlSerializer readerFilm = new XmlSerializer(typeof(Film[]));
			Film[] arrayFilms = (Film[]) readerFilm.Deserialize(fileFilms);
			foreach (Film film in arrayFilms)
			{
				films.Add(film);
			}
			dgFilms.Rows.Add(arrayFilms.Length);
			for (int i = 0; i < arrayFilms.Length; i++)
			{
				FilmToForm(i);
			}
			fileFilms.Close();
			btnOpen.Enabled = true;
			updateService.Start();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show(@"Сохранить текущий список?", @"Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
			{
				return;
			}
			FileStream fileFilms = File.Open("Фильмы.xml", FileMode.Create);
			XmlSerializer writerFilm = new XmlSerializer(typeof(Film[]));
			writerFilm.Serialize(fileFilms, films.GetArray());
			fileFilms.Close();
			changed = false;
		}

		private void dgFilms_DoubleClick(object sender, EventArgs e)
		{
			if (dgFilms.Rows.Count != 0 && dgFilms.CurrentRow != null) {
				new CardForm(films.GetFilm(dgFilms.CurrentRow.Index)).ShowDialog();
			}
		}

		private void btnUp_Click(object sender, EventArgs e)
		{
			if (dgFilms.Rows.Count == 0 || dgFilms.CurrentRow == null || dgFilms.CurrentRow.Index == 0)
			{
				return;
			}
			int index = dgFilms.CurrentRow.Index;
			Film film = films.GetCopyFilm(index);
			films.Delete(index);
			dgFilms.Rows.RemoveAt(index);
			dgFilms.Rows.Insert(index - 1, 1);
			films.Insert(film, index - 1);
			FilmToForm(index - 1);
			dgFilms.CurrentCell = dgFilms.Rows[index - 1].Cells[0];
			dgFilms.Rows[index - 1].Selected = true;
			changed = true;
		}

		private void btnDown_Click(object sender, EventArgs e)
		{
			if (dgFilms.Rows.Count == 0 || dgFilms.CurrentRow == null || dgFilms.CurrentRow.Index == 0)
			{
				return;
			}
			int index = dgFilms.CurrentRow.Index;
			Film film = films.GetCopyFilm(index);
			films.Delete(index);
			dgFilms.Rows.RemoveAt(index);
			dgFilms.Rows.Insert(index + 1, 1);
			films.Insert(film, index + 1);
			FilmToForm(index + 1);
			dgFilms.CurrentCell = dgFilms.Rows[index + 1].Cells[0];
			dgFilms.Rows[index + 1].Selected = true;
			changed = true;
		}

		private void frMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (changed) {
				if (MessageBox.Show(@"Отменить сохранения?", @"Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) {
					e.Cancel = true;
					return;
				}
			}
			updateService?.Stop();
		}

		private void btnFind_Click(object sender, EventArgs e)
		{
			new SearchForm().ShowDialog();
		}

		private void btnCoding_Click(object sender, EventArgs e)
		{
			new CalcForm().ShowDialog();
		}

		private void btnLog_Click(object sender, EventArgs e)
		{
			new LogForm().ShowDialog();
		}

		private void dgFilms_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == (Keys.Control | Keys.B))
			{
				if (dgFilms.CurrentRow != null)
				{
					Clipboard.Clear();
					Clipboard.SetText(films.GetFilm(dgFilms.CurrentRow.Index).russianTitle);
				}
			}
		}
	}
}