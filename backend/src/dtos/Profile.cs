using System;
using SpotifyAPI.Web;

namespace backend.src.dtos;

public record class Profile
{
    public string spotifyUri {get; set;}
    public string name {get; set;}
    public string imageUrl {get; set;}


    public Profile()
    {
        spotifyUri = "null";
        name = "null";
        imageUrl = "null";
    }

    public Profile (PrivateUser profile)
    {
        spotifyUri = profile.Uri;
        name = profile.DisplayName;
        imageUrl = profile.Images[0].Url;
    }
}
