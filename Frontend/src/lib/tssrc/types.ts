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
    uri: string;
    name: string;
    imageUrl: string;
}

export interface Album {
    uri: string;
    name: string;
    imageUrl: string;
    artists: Artist[];
    tracks: Track[];
}

export interface Playlist {
    uri: string;
    name: string;
    imageUrl: string;
    tracks: Track[];
}
