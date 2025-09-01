export interface Track{
        spotifyUri: string;
        name: string;
        imageUrl: string;
    }

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

    return { spotifyUri: data.spotifyUri, name: data.name, imageUrl: data.imageUrl };
}

export const spotifyBE = { startAuthentication, verifyLogin, fetchCurrentTrackInfo }