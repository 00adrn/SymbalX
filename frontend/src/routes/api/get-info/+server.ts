import type { RequestHandler } from '@sveltejs/kit';
import type { Track, Album, Artist, Playlist } from "$lib/api/types";
import { json } from '@sveltejs/kit';
import { PUBLIC_BACKENDURL } from "$env/static/public"

export const GET: RequestHandler = async ({ url, cookies }) => {
    const accessToken = cookies.get("accessToken");

    const type = url.searchParams.get("type");
    const uri = url.searchParams.get("uri");

    const params = new URLSearchParams();
    params.append("uri", `spotify:${type}:${uri}`);

    const response = await fetch(PUBLIC_BACKENDURL + "/api/get-info?" + params.toString(), {
        method: "GET",
        headers: {
            Authorization: "Bearer " + accessToken
        }
    });

    const data: Track | Playlist | Album | Artist = await response.json();

    return json(data);

}