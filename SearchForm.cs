using System;
using System.Windows.Forms;
using System.Collections;

namespace Films
{
  public struct Result
  {
    public String title;
    public int index;
  }
  public partial class SearchForm : Form
  {
    frMain frMain;
    FilmsList filmList;
    ArrayList arrayResult;
    public SearchForm(frMain fr, FilmsList fl)
    {
      InitializeComponent();
      frMain = fr;
      filmList = fl;
    }

    private void btnSearch_Click(object sender, EventArgs e)
    {
      lbResults.Items.Clear();
      String srch = tbTitle.Text;
      if (srch == "") {
        MessageBox.Show("Некорректный запрос!");
        return;
      }
      arrayResult = new ArrayList();
      for (int i = 0; i < frMain.dgFilms.Rows.Count; i++) {
        Film f = filmList.GetFilm(i);
        if ((f.russianTitle.Contains(srch)) || (f.originalTitle.Contains(srch))) {
          Result result = new Result();
          String str = "";
          if (f.originalTitle == "") {
            str = f.russianTitle + " (" + f.year + ")";
          }
          else {
            str = f.russianTitle + " / " + f.originalTitle + " (" + f.year + ")";
          }
          result.index = i;
          result.title = str;
          arrayResult.Add(result);
          lbResults.Items.Add(str);
        }
      }
      MessageBox.Show("Поиск окончен!");
    }

    private void lbResults_DoubleClick(object sender, EventArgs e)
    {
      if (lbResults.SelectedIndex != -1) {
        Result result = (Result)(arrayResult[lbResults.SelectedIndex]);
        frMain.dgFilms.CurrentCell = frMain.dgFilms.Rows[result.index].Cells[0];
        frMain.dgFilms.Rows[result.index].Selected = true;
        Close();
      }
    }
  }
}
