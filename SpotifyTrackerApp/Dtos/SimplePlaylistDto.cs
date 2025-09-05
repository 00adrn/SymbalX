using SpotifyAPI.Web;

namespace SpotifyTrackerApp.Dtos;

public class SimplePlaylistDto
{
    public string? spotifyUri { get; set; }
    public string? name { get; set; }
    public string? imageUrl { get; set; }

    public SimplePlaylistDto(FullPlaylist playlist)
    {
        spotifyUri = playlist.Uri!.AfterFinal(':');
        name = playlist.Name;
        imageUrl = playlist.Images!.FirstOrDefault()!.Url;
    }
}
