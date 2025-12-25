import { PUBLIC_BACKENDURL } from "$env/static/public"
import type { Track } from "$lib/api/types";

async function getCurrentTrack() : Promise<Track> {
    const response = await fetch(`${PUBLIC_BACKENDURL}/api/current-track`, {
        method: "GET",
        credentials: "include"
    });
    const data = await response.json();
    console.log(data);
    return data;
}

export const api = {
    getCurrentTrack
}