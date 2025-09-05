import type { Track, Artist, Playlist, Profile, SimplePlaylist } from '../tssrc/types';

async function fetchProfileInfo(): Promise<Profile> {
    const response = await fetch('http://[::1]:5157/api/profile-info', {
        credentials: 'include'
    });

    if (!response.ok)
        throw new Error(`Failed to fetch profile. Status: ${response.status}`);

    let data = await response.json();

    return {
        spotifyUri: data.spotifyUri,
        userName: data.userName,
        imageUrl: data.imageUrl
    }
}

async function fetchCurrentTrackInfo(): Promise<Track|null> {
    const response = await fetch("http://[::1]:5157/api/current-track", {
        credentials: "include"
    });

    if (!response.ok)
            throw new Error(`Failed to fetch track. Status: ${response.status}`);
    
    let data = await response.json();

    if (data.spotifyUri == null)
        return null;

    const artists: Artist[] = data.artists.map((artist: any) => ({
        name: artist.name,
        spotifyUri: artist.spotifyUri,
    }));

    return { 
        spotifyUri: data.spotifyUri, 
        name: data.name, 
        imageUrl: data.imageUrl, 
        artists: artists};
}

async function fetchPlaylistInfo(): Promise<Playlist|null> {
    const response = await fetch("http://[::1]:5157/api/spotify:playlist:6nKZcY1q0No74GLbxYfxSt", {
        credentials: "include"
    });

    if(!response.ok)
        throw new Error("Failed to fetch playlist");

    let data = await response.json();

    const tracks: Track[] = data.tracks.map((track: any) => ({
        spotifyUri: track.spotifyUri,
        name: track.name,
        imageUrl: track.imageUrl,
        artists: track.artists.map((artist: any) => ({
            name: artist.name,
            spotifyUri: artist.spotifyUri
        }))
    }));

    return {
        spotifyUri: data.spotifyUri,
        name: data.name,
        imageUrl: data.imageUrl,
        tracks: tracks
    }
}

async function fetchAllUserPlaylists(): Promise<SimplePlaylist[]> {
    const response = await fetch("http://[::1]:5157/api/all-playlists", {
        credentials: "include"
    });
    
    if(!response.ok)
        throw new Error("Failed to fetch playlists");

    const data: any[] = await response.json();

    const playlists: SimplePlaylist[] = data.map((playlist: any) => ({
        spotifyUri: playlist.spotifyUri,
        name: playlist.name,
        imageUrl: playlist.imageUrl
    }));

    return playlists;

}

export const spotifyApi = {fetchCurrentTrackInfo, fetchProfileInfo, fetchPlaylistInfo, fetchAllUserPlaylists}