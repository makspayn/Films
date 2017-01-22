using System;
using System.IO;
using System.Net;
using System.Text;
using HtmlAgilityPack;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace Films.Services
{
	public class FilmInfo
	{
		public string russianTitle;
		public string originalTitle;
		public string year;
		public string country;
		public string genre;
		public string director;
		public string actors;
		public string worldPremiere;
		public string russianPremiere;
		public string discPremiere;
	}

	public static class ParsingService
	{
		private static string GetDate(string value)
		{
			DateTime dt = DateTime.Parse(value);
			return dt.ToShortDateString();
		}

		private static string DeletePoints(string str)
		{
			return str.EndsWith("...") ? str.Substring(0, str.Length - 5) : str;
		}

		private static string ValidateAndCorrect(string value)
		{
			return WebUtility.HtmlDecode(value);
		}

		private static string Trim(string text)
		{
			return text.Trim(' ', '\r', '\n');
		}

		private static string GetHtml(string id)
		{
			string baseUrl = "http://www.kinopoisk.ru/film/";
			WebRequest.DefaultWebProxy = new WebProxy();
			HttpWebRequest request = (HttpWebRequest) WebRequest.Create(baseUrl + id);
			request.Proxy = null;
			request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.103 Safari/537.36";
			request.Headers.Add("Accept-Language: ru-Ru,ru;q=0.5");
			request.Headers.Add("Accept-Charset: Windows-1251,utf-8;q=0.7,*;q=0.7");
			using (HttpWebResponse response = (HttpWebResponse) request.GetResponse())
			{
				string encoding = response.Headers["Content-Type"].Split(new[] { "charset=" }, StringSplitOptions.RemoveEmptyEntries)[1];
				StringBuilder sb = new StringBuilder();
				byte[] buf = new byte[8192];
				int b = 0;
				Stream resStream = response.GetResponseStream();
				do
				{
					if (resStream != null)
					{
						b = resStream.Read(buf, 0, buf.Length);
					}
					if (b != 0)
					{
						sb.Append(Encoding.GetEncoding(encoding).GetString(buf, 0, b));
					}
				} while (b > 0);
				return sb.ToString();
			}
		}

		public static FilmInfo GetFilmInfo(string id)
		{
			FilmInfo filmInfo = new FilmInfo
			{
				russianTitle = "",
				originalTitle = "",
				year = "",
				country = "",
				genre = "",
				director = "",
				actors = "",
				worldPremiere = "",
				russianPremiere = "",
				discPremiere = ""
			};
			string htmlCode = GetHtml(id);
			HtmlDocument doc = new HtmlDocument();
			doc.LoadHtml(htmlCode);
			HtmlNode headerFilm = doc.GetElementbyId("headerFilm");
			filmInfo.russianTitle = ValidateAndCorrect(Trim(headerFilm.SelectSingleNode("h1").InnerText));
			filmInfo.originalTitle = ValidateAndCorrect(Trim(headerFilm.SelectSingleNode("span").InnerText));
			HtmlNode actorList = doc.GetElementbyId("actorList");
			HtmlNodeCollection list = actorList.SelectSingleNode("ul").ChildNodes;
			StringBuilder sbActors = new StringBuilder();
			for (int i = 0; i < list.Count; i++)
			{
				sbActors.Append(ValidateAndCorrect(Trim(actorList.SelectSingleNode("ul/li[" + (i + 1) + "]").InnerText)));
				if (i != list.Count - 1)
				{
					sbActors.Append(", ");
				}
			}
			filmInfo.actors = DeletePoints(sbActors.ToString());
			HtmlNode infoTable = doc.GetElementbyId("infoTable");
			HtmlNodeCollection table = infoTable.SelectSingleNode("table").ChildNodes;
			string dvdRelease = "";
			string blurayRelease = "";
			for (int i = 0; i < table.Count / 2; i++)
			{
				if (ValidateAndCorrect(Trim(infoTable.SelectSingleNode($"table/tr[{i + 1}]/td[1]").InnerText)) == "год")
				{
					filmInfo.year = ValidateAndCorrect(Trim(infoTable.SelectSingleNode($"table/tr[{i + 1}]/td[2]").InnerText));
				}
				if (ValidateAndCorrect(Trim(infoTable.SelectSingleNode($"table/tr[{i + 1}]/td[1]").InnerText)) == "страна")
				{
					filmInfo.country = DeletePoints(ValidateAndCorrect(Trim(infoTable.SelectSingleNode($"table/tr[{i + 1}]/td[2]").InnerText)));
				}
				if (ValidateAndCorrect(Trim(infoTable.SelectSingleNode($"table/tr[{i + 1}]/td[1]").InnerText)) == "режиссер")
				{
					filmInfo.director = DeletePoints(ValidateAndCorrect(Trim(infoTable.SelectSingleNode($"table/tr[{i + 1}]/td[2]").InnerText)));
				}
				if (ValidateAndCorrect(Trim(infoTable.SelectSingleNode($"table/tr[{i + 1}]/td[1]").InnerText)) == "жанр")
				{
					filmInfo.genre = DeletePoints(ValidateAndCorrect(Trim(infoTable.SelectSingleNode($"table/tr[{i + 1}]/td[2]/span").InnerText)));
				}
				if (ValidateAndCorrect(Trim(infoTable.SelectSingleNode($"table/tr[{i + 1}]/td[1]").InnerText)) == "премьера (мир)")
				{
					filmInfo.worldPremiere = GetDate(ValidateAndCorrect(Trim(infoTable.SelectSingleNode($"table/tr[{i + 1}]/td[2]/div/a").InnerText)));
				}
				if (ValidateAndCorrect(Trim(infoTable.SelectSingleNode($"table/tr[{i + 1}]/td[1]").InnerText)) == "премьера (РФ)")
				{
					filmInfo.russianPremiere = GetDate(ValidateAndCorrect(Trim(infoTable.SelectSingleNode($"table/tr[{i + 1}]/td[2]/div/span/a").InnerText)));
				}
				if (ValidateAndCorrect(Trim(infoTable.SelectSingleNode($"table/tr[{i + 1}]/td[1]").InnerText)) == "релиз на DVD")
				{
					dvdRelease = GetDate(ValidateAndCorrect(Trim(infoTable.SelectSingleNode($"table/tr[{i + 1}]/td[2]/div/a").InnerText)));
				}
				if (ValidateAndCorrect(Trim(infoTable.SelectSingleNode($"table/tr[{i + 1}]/td[1]").InnerText)) == "релиз на Blu-Ray")
				{
					blurayRelease = GetDate(ValidateAndCorrect(Trim(infoTable.SelectSingleNode($"table/tr[{i + 1}]/td[2]/div/a").InnerText)));
				}
			}
			filmInfo.discPremiere = blurayRelease != "" ? blurayRelease : dvdRelease;
			return filmInfo;
		}
	}
}