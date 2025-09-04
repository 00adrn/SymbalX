import type { Track, Artist, Profile } from '../tssrc/types';


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
    const response = await fetch('http://[::1]:5157/api/current-track', {
        credentials: 'include'
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
        name: data.name, imageUrl: 
        data.imageUrl, 
        artists: artists};
}

export const spotifyBE = {fetchCurrentTrackInfo, fetchProfileInfo}