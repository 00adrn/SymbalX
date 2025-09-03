using System;
using SpotifyAPI.Web;

namespace SpotifyTrackerApp.Dtos;

public class ProfileDto
{
    public string? spotifyUri { get; set; }
    public string? userName { get; set; }
    public string? imageUrl { get; set;}

    public ProfileDto(PrivateUser? user)
    {
        spotifyUri = user is not null ? user.Uri : null;
        userName = user is not null ? user.DisplayName : null;
        imageUrl = user is not null ? user.Images[0].Url : null;
    }
}
