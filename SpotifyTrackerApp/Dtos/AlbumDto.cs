using System;

namespace SpotifyTrackerApp.Dtos;

public record class AlbumDto
{
    public string? spotifyUri;
    public string? name;
    public LinkedList<TrackDto>? tracks;
    public ArtistDto? artist;

}
