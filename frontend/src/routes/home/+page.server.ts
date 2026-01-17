import type { Profile } from "$lib/api/types"
import { supabase } from "$lib/supabaseClient"

export const load = async ({ fetch, parent }) => {
    const { session }  = await parent();
    const sp_access_token = await supabase.from("user_profile_info").select("sp_access_token").eq("user_id", session?.user.id);


    let playlists = null;

    if (sp_access_token != null) {
        const resp = await fetch("/api/user/get-all-playlists", {
            method: "GET",
            headers: {
                "Authorization": "Bearer " + sp_access_token.data![0].sp_access_token
            }
        });

        playlists = await resp.json();
    }

    return {
        playlists
    };
}