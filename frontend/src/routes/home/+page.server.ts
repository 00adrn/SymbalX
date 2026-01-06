import type { Profile } from "$lib/api/types"
import { supabase } from "$lib/supabaseClient"

export const load = async ({ fetch }) => {
    const resp = await fetch("/api/user/get-all-playlists", {
        method: "GET",
        credentials: "include"
    });

    const playlists = await resp.json();

    return {
        playlists: playlists
    };
}