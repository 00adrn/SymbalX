import type { RequestHandler } from "@sveltejs/kit"
import { json } from "@sveltejs/kit"
import { PUBLIC_SPOTIFYAPI } from "$env/static/public"

export const GET: RequestHandler = async ({ request, fetch, }) => {
    const accessToken = request.headers.get("Authorization")?.split(" ")[1];

    if (accessToken == null)
        return json({Error: "No access token provided"});

    let resp = await fetch("/api/user/get-profile", {
        method: "GET",
        credentials: "include"
    });
    
    const user = await resp.json();

    resp = await fetch(PUBLIC_SPOTIFYAPI + `/users/${user.id}/playlists`, {
        method: "GET",
        headers: {
            Authorization : "Bearer " + accessToken
        }
    });
    const data = await resp.json();

    return json(data);
}