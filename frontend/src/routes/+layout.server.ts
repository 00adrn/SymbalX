import type { LayoutServerLoad } from './$types.js';

export const load: LayoutServerLoad = async ({ fetch, locals: { safeGetSession }, cookies }) => {

    const { session, user } = await safeGetSession();

    const colors = ["#252530", "#2e2d38", "#232323"];

    const resp = await fetch("/api/user/get-profile", {
        method: "GET",
        credentials: "include"
    })

    const profile = await resp.json();

    if (!session)
        console.log("Session was undefined");
    if (user)
        console.log("User was undefined");


    return {
        colors: colors,
        profile: profile,
        session, 
        user, 
        cookies: cookies.getAll(), 
    }
}