using Nancy;
using System.Collections.Generic;
using CdList;
using ArtistList;

namespace Cdlist
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        List<Cd> allCds = Cd.GetAll();
        return View["index.cshtml", allCds];
      };
      Get["/cds"] = _ => {
        List<Cd> allCds = Cd.GetAll();
        return View["index.cshtml", allCds];
      };
      Get["/cds/new"] = _ => {
        return View["cd_form.cshtml"];
      };
      Post["/"] = _ => {
        Cd newCd = new Cd(Request.Form["new-title"]);
        Artist newArtist = new Artist(Request.Form["new-artist"]);
        List<Artist> allArtist = Artist.GetAll();
        List<Cd> allCds = Cd.GetAll();
        return View["index.cshtml", allCds];
      };
      Get["/cds/{id}"] = parameters => {
        Artist artist = Artist.Find(parameters.id);
        return View["/cd.cshtml", artist];
      };
      Get["/search_artist"] = _ => View["search_artist.cshtml"];
      Post["view_result"] = _ =>
      {
        string artist = Request.Form["artist"];
        List<Artist> results = Artist.SearchArtist(artist);
        return View["view_result.cshtml", results];
      };
      Get["/search_artist/{id}"] = parameters =>
      {
        Dictionary<string, object> bank = new Dictionary<string, object>();
        var selectedArtist = Artist.Find(parameters.id);
        var artistTitles = selectedArtist.GetCds();
        bank.Add("artist", selectedArtist);
        bank.Add("title", artistTitles);
        return View["artist_title_form.cshtml", bank];
      };
      Post["/view_title"] = _ =>
      {
        string artist = Request.Form["artist"];
        List<Artist> results = Artist.SearchArtist(artist);
        return View["view_title.cshtml", results];
      };
    }
  }
}
