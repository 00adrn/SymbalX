using System;
using SpotifyAPI.Web;

namespace SpotifyTrackerApp.Dtos;

public class PlaylsitDto
{
    public string? spotifyUri { get; set; }
    public string? name { get; set; }
    public string? imageUrl { get; set; }
    public List<TrackDto>? tracks { get;  set; }

    public PlaylsitDto(FullPlaylist playlist)
    {
        spotifyUri = playlist.Uri;
        name = playlist.Name;
        imageUrl = playlist.Images!.FirstOrDefault()!.Url;
        tracks = new List<TrackDto>();

        foreach (PlaylistTrack<IPlayableItem> item in playlist.Tracks!.Items!)
            if (item.Track is FullTrack track) tracks!.Add(new TrackDto(track));
    }

}