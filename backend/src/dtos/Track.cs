using SpotifyAPI.Web;

namespace backend.src.dtos;

public record class Track
{
    public string spotifyUri {get; set;}
    public string name {get; set;}
    public string imageUrl {get; set;}
    public List<Artist> artists {get; set;}

    public Track()
    {
        spotifyUri = "null";
        name = "null";
        imageUrl = "null";
        artists = new List<Artist>();
    }
    public Track(FullTrack track)
    {
        spotifyUri = track.Uri;
        name = track.Name;
        imageUrl = track.Album.Images[0].Url;
        artists = new List<Artist>();
        foreach (var artist in track.Artists)
            artists.Add(new Artist(artist));
    }
    public Track(SimpleTrack track)
    {
        spotifyUri = track.Uri;
        name = track.Name;
        imageUrl = "null";
        artists = new List<Artist>();
    }
    
}
