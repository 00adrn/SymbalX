import type { Track } from '../tssrc/Track';
import type { Artist } from '../tssrc/Track'


async function startAuthentication() {
    window.location.href = "http://[::1]:5157/auth";
}

async function verifyLogin(){
    const response = await fetch('http://[::1]:5157/auth/validate', {
        credentials: 'include'
    });
    if (response.ok) return true;
    return false;
}

async function fetchCurrentTrackInfo(): Promise<Track> {
    const response = await fetch('http://[::1]:5157/api/current-track', {
        credentials: 'include'
    });

    if (!response.ok)
            throw new Error(`Failed to fetch track. Status: ${response.status}`);
    
    let data = await response.json();

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

export const spotifyBE = { startAuthentication, verifyLogin, fetchCurrentTrackInfo }