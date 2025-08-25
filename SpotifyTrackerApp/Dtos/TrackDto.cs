using System;

namespace SpotifyTrackerApp.Dtos;

public record class TrackDto
{
    public string? spotifyUri;
    public string? name;
    public ArtistDto? artist;
}
