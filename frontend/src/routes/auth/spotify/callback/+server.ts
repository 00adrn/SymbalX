import { PRIVATE_CLIENTID, PRIVATE_CLIENTSECRET, PRIVATE_REDIRECTURI } from "$env/static/private"
import { redirect } from "@sveltejs/kit"
import type { RequestHandler } from "./$types"

export const GET: RequestHandler = async ({ url, cookies }) => {
    const userState = cookies.get("state");

    const code = url.searchParams.get("code");
    const state = url.searchParams.get("state");
    
    if (userState != state)
        redirect(302, "/auth/spotify/login");

    const params = new URLSearchParams();
    params.append("grant_type", "authorization_code");
    params.append("code", code || "");
    params.append("redirect_uri", PRIVATE_REDIRECTURI);
    
    const response = await fetch("https://accounts.spotify.com/api/token", {
        method: "POST",
        headers: {
            "Content-Type": "application/x-www-form-urlencoded",
            "Authorization": "Basic " + btoa(PRIVATE_CLIENTID + ":" + PRIVATE_CLIENTSECRET)
        },
        body: params
    });

    const data = await response.json();

    cookies.set("accessToken", data.access_token, { path: "/", httpOnly: true, maxAge: data.expires_in });
    cookies.set("refreshToken", data.refresh_token, { path: "/", httpOnly: true, maxAge: data.expires_in});

    console.log("Cookie expires in : " + data.expires_in);

    redirect(302, "/");
}
