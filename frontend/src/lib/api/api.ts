import { BACKENDURL } from "$env/static/private"
import type { Track } from "$lib/api/types";


export const getCurrentTrack = async (): Promise<Track> => {
    const response = await fetch(`${BACKENDURL}/api/current-track`);
    const data = await response.json();
    return data;
}