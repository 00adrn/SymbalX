import { redirect } from "@sveltejs/kit";


export const load = async ({ fetch, parent }) => {
    const { session, userData }  = await parent();

    if (!session)
        redirect(308, "/");

    let playlists = null;
    let profile = null;

    const accessToken = userData.sp_access_token;

    if (accessToken) {
        let resp = await fetch("/api/user/get-all-playlists", {
            method: "GET",
            headers: {
                "Authorization": "Bearer " + accessToken
            }
        });

        playlists = await resp.json();

        resp = await fetch("/api/user/get-profile", {
            method: "GET",
            headers: {
                "Authorization": "Bearer " + accessToken
            }
        });
        profile = await resp.json();
    }

    return {
        playlists,
        profile,
    };
}