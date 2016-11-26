using System;
using System.Collections;

namespace Films
{
  public struct Film
  {
    public String russianTitle;
    public String originalTitle;
    public String year;
    public String country;
    public String genre;
    public String director;
    public String actors;
    public String worldDate;
    public String russianDate;
    public String discDate;
    public String description;
    public String link;
    public String code;
    public int width;
    public int height;
    public String duration;
    public String qualityTitle;
    public String qualityPixel;
    public String translateTitle;
    public String translateComment;
    public String Color;
    public String videoCodec;
    public int originalWidth;
    public int originalHeight;
    public int videoKbps;
    public double fps;
    public String audioCodec;
    public int channels;
    public int audioKbps;
    public String dataCheck;
  }

  public class FilmsList
  {
    ArrayList arrayFilms;

    public FilmsList()
    {
      arrayFilms = new ArrayList();
    }

    public void Add(Film f)
    {
      arrayFilms.Add(f);
    }

    public void Insert(Film f, int i)
    {
      arrayFilms.Insert(i, f);
    }

    public void Edit(Film f, int i)
    {
      arrayFilms[i] = f;
    }

    public void Delete(int i)
    {
      arrayFilms.RemoveAt(i);
    }
    public Film GetFilm(int index)
    {
      return (Film)arrayFilms[index];
    }

    public Film CopyTo(Film f, Film temp)
    {
      f.russianTitle = temp.russianTitle;
      f.originalTitle = temp.originalTitle;
      f.year = temp.year;
      f.country = temp.country;
      f.genre = temp.genre;
      f.director = temp.director;
      f.actors = temp.actors;
      f.worldDate = temp.worldDate;
      f.russianDate = temp.russianDate;
      f.discDate = temp.discDate;
      f.description = temp.description;
      f.link = temp.link;
      f.code = temp.code;
      f.width = temp.width;
      f.height = temp.height;
      f.duration = temp.duration;
      f.qualityTitle = temp.qualityTitle;
      f.qualityPixel = temp.qualityPixel;
      f.translateTitle = temp.translateTitle;
      f.translateComment = temp.translateComment;
      f.Color = temp.Color;
      f.videoCodec = temp.videoCodec;
      f.originalWidth = temp.originalWidth;
      f.originalHeight = temp.originalHeight;
      f.videoKbps = temp.videoKbps;
      f.fps = temp.fps;
      f.audioCodec = temp.audioCodec;
      f.channels = temp.channels;
      f.audioKbps = temp.audioKbps;
      f.dataCheck = temp.dataCheck;
      return f;
    }

    public Film[] GetArray()
    {
      Film[] aFilms = new Film[arrayFilms.Count];
      for (int i = 0; i < arrayFilms.Count; i++) {
        aFilms[i] = this.GetFilm(i);
      }
      return aFilms;
    }
  }
}