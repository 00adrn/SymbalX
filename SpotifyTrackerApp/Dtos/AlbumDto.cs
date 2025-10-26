using System;
using SpotifyAPI.Web;

namespace SpotifyTrackerApp.Dtos;

public record class AlbumDto
{
    public string? spotifyUri { get; set;}
    public string? name { get; set;}
    public List<ArtistDto>? artist { get; set;}
    public List<TrackDto>? tracks { get; set; }
    public string? imageUrl { get; set;}


    public AlbumDto(FullAlbum album)
    {
        spotifyUri = album.Uri.AfterFinal(':');
        name = album.Name;
        imageUrl = album.Images.FirstOrDefault()?.Url;
        
        artist = album.Artists.Select(artist => new ArtistDto(artist)).ToList() ?? new List<ArtistDto>();

        tracks = album.Tracks.Items!.Select(track => new TrackDto(track)).ToList() ?? new List<TrackDto>();
    }
}
