using System;
using SpotifyAPI.Web;

namespace backend.src.dtos;

public record class Profile
{
    required public string spotifyUri {get; set;}
    required public string name {get; set;}
    required public string imageUrl {get; set;}

    public Profile()
    {
        
    }
}
