using System;
using System.Collections.Generic;
using CdList;

namespace ArtistList
{
  public class Artist
  {
    private string _artistName;
    private static List<Artist> _instances = new List<Artist> {};
    private int Id;
    private List<Cd> _cds;

    public Artist(string artist)
    {
      _artistName = artist;
      _instances.Add(this);
      Id = _instances.Count;
      _cds = new List<Cd> {};
    }

    public string GetArtist()
    {
      return _artistName;
    }

    public int GetId()
    {
      return Id;
    }

    public List<Cd> GetCds()
    {
      return _cds;
    }

    public void AddCd(Cd cd)
    {
      _cds.Add(cd);
    }

    public static List<Artist> GetAll()
    {
      return _instances;
    }

    public static Artist Find(int searchId)
    {
      return _instances[searchId - 1];
    }
    public static List<Artist> SearchArtist(string artist)
    {
      List<Artist> results= new List<Artist> {};

      foreach(Artist matchingArtist in _instances)
      {

        if (matchingArtist.GetArtist().ToLower().Contains(artist.ToLower()))
        {
          results.Add(matchingArtist);
        }
      }
      return results;
    }
  }
}
