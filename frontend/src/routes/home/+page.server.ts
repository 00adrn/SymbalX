
export const load = async ({ fetch, parent }) => {
    const { userData }  = await parent();
    let playlists = null;
    let profile = null;

    if (userData) {

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
    } 

    return {
        playlists,
        profile,
    };
}