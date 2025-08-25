using System;
using SpotifyAPI.Web;

namespace SpotifyTrackerApp.Dtos;

public record class TrackDto
{
    public string? spotifyUri { get; set;}
    public string? name { get; set;}
    public string? imageUrl { get; set;}
    public ArtistDto? artist { get; set;}

    public TrackDto(FullTrack track)
    {
        spotifyUri = track.Uri;
        name = track.Name;
        if (track.Album.Images.Count > 0)
        {
            imageUrl = track.Album.Images.FirstOrDefault()!.Url;
        }
        artist = new ArtistDto(track.Artists.FirstOrDefault()!);
    }

    public TrackDto(SimpleTrack track)
    {
        spotifyUri = track.Uri;
        name = track.Name;
        imageUrl = null;
        artist = null;
    }
}
