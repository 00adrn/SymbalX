import type { Profile } from "$lib/api/types"
import { supabase } from "$lib/supabaseClient.js"

export const load = async ({ fetch, parent }) => {
    const resp = await fetch("/api/profile-playlists", {
        method: "GET",
        credentials: "include"
    });

    const { data } = await supabase.from("test").select();
    
    const playlists = await resp.json(); 

    return {
        playlists: playlists,
        test: data ?? []
    };
}