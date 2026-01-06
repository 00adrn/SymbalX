import { PRIVATE_CLIENTID, PRIVATE_REDIRECTURI } from "$env/static/private"
import { redirect } from "@sveltejs/kit"
import type { RequestHandler } from "./$types"

export const GET: RequestHandler = async ({ cookies }) => {
    const state = createRandomString(64);
    const scope = "user-read-currently-playing playlist-read-private playlist-read-collaborative user-follow-read user-read-private";
    
    const params = new URLSearchParams();
    params.append("response_type", "code");
    params.append("client_id", PRIVATE_CLIENTID);
    params.append("scope", scope);
    params.append("redirect_uri", PRIVATE_REDIRECTURI);
    params.append("state", state);

    cookies.set("state", state, {
        path: "/auth/spotify",
        httpOnly: true,
        sameSite: "lax",
        maxAge: 60 * 5
    });

    redirect(302, "https://accounts.spotify.com/authorize?" + params.toString());
}

const createRandomString = (length: number) => {
    const chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
    let result = "";
    for (let i = length; i > 0; --i)
        result += chars[Math.floor(Math.random() * chars.length)];
    
    return result;
}