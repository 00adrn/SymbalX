import type { Profile } from "$lib/api/types"

export const load = async ({ fetch, parent }) => {
    const resp = await fetch("/api/profile", {
        method: "GET",
        credentials: "include"
    })
    const data: Profile = await resp.json();

    return {
        profile: data
    };
};