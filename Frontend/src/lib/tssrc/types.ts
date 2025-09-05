export interface Profile{
    spotifyUri: string;
    userName: string;
    imageUrl: string;
}

export interface Track {
    spotifyUri: string;
    name: string;
    imageUrl: string;
    artists: Artist[];
}

export interface Artist {
    spotifyUri: string;
    name: string;
    imageUrl: string;
}

export interface Album {
    spotifyUri: string;
    name: string;
    imageUrl: string;
    artists: Artist[];
    tracks: Track[];
}

export interface Playlist {
    spotifyUri: string;
    name: string;
    imageUrl: string;
    tracks: Track[];
}

export interface SimplePlaylist {
    spotifyUri: string;
    name: string;
    imageUrl: string;
}
