using SpotifyAPI.Web;

namespace backend.src.dtos;

public record class Playlist
{
    public string spotifyUri {get; set;}
    public string name {get; set;}
    public string imageUrl {get; set;}
    public List<Track> tracks {get; set;}

    public Playlist()
    {
        spotifyUri = "null";
        name = "null";
        imageUrl = "null";
        tracks = new List<Track>();
    }
    public Playlist(FullPlaylist playlist, bool readTracks = true)
    {
        spotifyUri = playlist.Uri!;
        name = playlist.Name!;
        imageUrl = playlist.Images![0].Url;
        tracks = new List<Track>();
        if (readTracks)
            foreach (var playableItem in playlist.Tracks!.Items!)
            {
                if (playableItem.Track is FullTrack track)
                    tracks.Add(new Track(track));
            }
        else
            tracks = new List<Track>();
    }
}
