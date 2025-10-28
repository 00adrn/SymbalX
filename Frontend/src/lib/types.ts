export interface Artist {
    spotifyUri: string;
    name: string;
    imageUrl: string | null;
};
export interface Album {
    spotifyUri: string;
    name: string;
    artists: Artist[];
    tracks: Track[];
    imageUrl: string | null;
};
export interface Track {
    spotifyUri: string;
    name: string;
    artists: Artist[];
    imageUrl: string | null;
};
export interface Playlist {
    spotifyUri: string;
    name: string;
    tracks: Track[];
    imageUrl: string | null;
};