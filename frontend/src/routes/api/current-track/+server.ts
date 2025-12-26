import type { RequestHandler } from '@sveltejs/kit';
import type { Track } from "$lib/api/types";
import { json } from '@sveltejs/kit';
import { PUBLIC_BACKENDURL } from "$env/static/public"

export const GET: RequestHandler = async ({ cookies }) => {
    const accessToken = cookies.get("accessToken");

    const response = await fetch(PUBLIC_BACKENDURL + "/api/current-track", {
        method: "GET",
        headers: {
            Authorization: "Bearer " + accessToken
        }
    })

    const track : Track = await response.json();

    return json(track);;
}