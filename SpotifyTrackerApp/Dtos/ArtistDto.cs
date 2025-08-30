using System;
using SpotifyAPI.Web;

namespace SpotifyTrackerApp.Dtos;

public record class ArtistDto
{
    public string? spotifyUri { get; set;}
    public string? name { get; set;}
    public string? imageUrl { get; set;}

    public ArtistDto(FullArtist artist)
    {
        spotifyUri = artist.Uri.AfterFinal(':');
        name = artist.Name;
        imageUrl = artist.Images.FirstOrDefault()!.Url;
    }

    public ArtistDto(SimpleArtist artist)
    {
        spotifyUri = artist.Uri;
        name = artist.Name;
        imageUrl = null;
    }
}
