import type { Profile } from "$lib/api/types"

export const load = async ({ fetch, parent }) => {
    const { isLoggedIn } = await parent();

    if (!isLoggedIn)
        return {
            profile: null
        }
        
    const resp = await fetch("/api/profile", {
        method: "GET",
        credentials: "include"
    })
    const data: Profile = await resp.json();

    return {
        profile: data
    };
};