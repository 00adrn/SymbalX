using System;
using SpotifyAPI.Web;

namespace backend.src.dtos;

public record class Artist
{
    public string spotifyUri {get; set;}
    public string name {get; set;}
    public string? imageUrl {get; set;}

    public Artist()
    {
        spotifyUri = "null";
        name = "null";
        imageUrl = "null";
    }
    public Artist(FullArtist artist)
    {
        spotifyUri = artist.Uri;
        name = artist.Name;
        imageUrl = artist.Images[0].Url;
    }
    public Artist(SimpleArtist artist)
    {
        spotifyUri = artist.Uri;
        name = artist.Name;
        imageUrl = null;
    }
}
