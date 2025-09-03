import type { Track } from '../tssrc/types';
import type { Artist } from '../tssrc/types';

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

export const spotifyBE = {fetchCurrentTrackInfo }