import type { Profile } from "$lib/api/types"

export const load = async ({ fetch, parent }) => {
    const resp = await fetch("/api/profile-playlists", {
        method: "GET",
        credentials: "include"
    });

    const playlists = await resp.json();

    return {
        playlists: playlists
    };
}