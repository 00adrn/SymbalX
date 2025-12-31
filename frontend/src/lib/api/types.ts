export interface Artist {
    spotifyUri: string;
    name: string;
    imageUrl: string | null;
}

export interface Track {
    spotifyUri: string;
    name: string;
    imageUrl: string | null;
    artists: Artist[];
}

export interface Album {
    spotifyUri: string;
    name: string;
    imageUrl: string | null;
    artists: Artist[];
    tracks: Track[];
}

export interface Playlist {
    spotifyUri: string;
    name: string;
    imageUrl: string | null;
    tracks: Track[];
}

export interface Profile {
    spotifyUri: string;
    name: string;
    imageUrl: string;
}