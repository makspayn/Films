using System;

namespace Films
{
  class FilmRip
  {
    Film film;
    String title;
    int maxHeight;
    double qualityVideo;
    double fps;
    int qualityAudio;
    int maxChannels;
    int width, height;
    int videoKbps, audioKbps;
    int channels;
    public FilmRip(Film f, String t, int maxH, double qualityV, double FPS, int qualityA, int maxCh)
    {
      film = f;
      title = t;
      maxHeight = maxH;
      qualityVideo = qualityV;
      fps = FPS;
      qualityAudio = qualityA;
      maxChannels = maxCh;
    }

    public String GetTitle()
    {
      return title;
    }

    public String GetVideo()
    {
      double aspect = (double)film.width / (double)film.height;
      if (aspect < 1.777) {
        if (film.height < maxHeight) {
          height = film.height;
        }
        else {
          height = maxHeight;
        }
        width = (int)((double)height / (double)film.height * (double)film.width);
        if ((width % 2) != 0) {
          width++;
        }
      }
      else {
        width = (int)(1.778 * (double)maxHeight);
        if ((width % 2) != 0) {
          width++;
        }
        if (width >= film.width) {
          width = film.width;
        }
        height = (int)((double)width / (double)film.width * (double)film.height);
        if ((height % 2) != 0) {
          height++;
        }
      }
      videoKbps = (int)Math.Round(((double)width * (double)height * fps / 1000.0 * qualityVideo), 0);
      String video = width.ToString() + "x" + height.ToString() + ", " + videoKbps.ToString() + " Kbps, " + fps.ToString() + " fps";
      return video;
    }

    public String GetAudio()
    {
      if (film.channels < maxChannels) {
        channels = film.channels;
      }
      else {
        channels = maxChannels;
      }
      audioKbps = qualityAudio * channels;
      String audio = channels.ToString() + " ch, " + audioKbps.ToString() + " Kbps";
      return audio;
    }

    public String GetSize()
    {
      return CardForm.GetSize(film.duration, videoKbps, audioKbps, width, height, fps);
    }
  }
}