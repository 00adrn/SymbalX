import type { RequestHandler } from "@sveltejs/kit"
import { json } from "@sveltejs/kit"
import { PUBLIC_SPOTIFYAPI } from "$env/static/public"


export const GET: RequestHandler = async ({ cookies, fetch }) => {
    const accessToken = cookies.get("accessToken");

    const response = await fetch(PUBLIC_SPOTIFYAPI + `/me`, {
        method: "GET",
        headers: {
            Authorization : "Bearer " + accessToken
        }
    });
    const data = await response.json();

    return json(data);
}