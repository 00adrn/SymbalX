import { PUBLIC_BACKENDURL } from "$env/static/public"
import type { Track } from "$lib/api/types";

async function 

async function getCurrentTrack() : Promise<Track> {
    const response = await fetch(`${PUBLIC_BACKENDURL}/api/current-track`, {
        credentials: "include"
    });
    const data = await response.json();
    return data;
}

export const api = {
    getCurrentTrack
}