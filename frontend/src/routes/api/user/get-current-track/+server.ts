import type { RequestHandler } from "@sveltejs/kit"
import { json } from "@sveltejs/kit"
import { PUBLIC_SPOTIFYAPI } from "$env/static/public"


export const GET: RequestHandler = async ({ fetch, request }) => {
    const accessToken = request.headers.get("Authorization")?.split(" ")[1];

    const response = await fetch(PUBLIC_SPOTIFYAPI + "/me/player/currently-playing", {
        method: "GET",
        headers: {
            Authorization : "Bearer " + accessToken
        }
    });
    
    const data = await response.json();

    return json(data);
}