import { PRIVATE_CLIENTID, PRIVATE_CLIENTSECRET, PRIVATE_REDIRECTURI } from "$env/static/private"
import { PUBLIC_FRONTENDURL } from "$env/static/public"
import { redirect, error } from "@sveltejs/kit"
import type { RequestHandler } from "./$types"

export const GET: RequestHandler = async ({ url, cookies, locals: { supabase } }) => {
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

    if (data.error || !data.access_token) {
        throw error(400, "Failed to authenticate with Spotify");
    }

    const { data: { user } } = await supabase.auth.getUser();

    if (user) {
        const { error: dbError } = await supabase.from("user_profile_info").update({ sp_access_token: data.access_token, sp_refresh_token: data.refresh_token }).eq("user_id", user.id);
        if (dbError)
            console.log("Failed to save spotify tokens to db", dbError);
    } else 
        console.log("User not authenticated!")

    console.log("Cookie expires in : " + data.expires_in);

    redirect(302, PUBLIC_FRONTENDURL);
}
