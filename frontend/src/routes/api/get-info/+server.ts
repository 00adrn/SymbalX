import type { RequestHandler } from '@sveltejs/kit';
import { json } from '@sveltejs/kit';
import { PUBLIC_SPOTIFYAPI } from "$env/static/public"

export const GET: RequestHandler = async ({ url, cookies }) => {
    const accessToken = cookies.get("accessToken");

    const type = url.searchParams.get("type");
    const uri = url.searchParams.get("uri");

    const response = await fetch(PUBLIC_SPOTIFYAPI + `/${type}/${uri}`, {
        method: "GET",
        headers: {
            Authorization: "Bearer " + accessToken
        }
    });

    const data = await response.json();

    return json(data);
}