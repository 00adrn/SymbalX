using System;
using SpotifyAPI.Web;

namespace SpotifyTrackerApp.Dtos;

public record class TrackDto
{
    public string? spotifyUri { get; set; }
    public string? name { get; set; }
    public string? imageUrl { get; set; }
    public List<ArtistDto>? artists { get; set; }

    public TrackDto(FullTrack? track)
    {
        spotifyUri = track is null ? null : track.Uri.AfterFinal(':');
        name = track is null ? null : track.Name;
        if (track is not null && track.Album.Images.Count > 0)
            imageUrl = track.Album.Images.FirstOrDefault()!.Url;
        else
            imageUrl = null;

        artists = track is null ? null : track.Artists.Select(artist => new ArtistDto(artist)).ToList();
    }

    public TrackDto(SimpleTrack track)
    {
        spotifyUri = track.Uri;
        name = track.Name;
        imageUrl = null;
        artists = null;
    }
    
}
