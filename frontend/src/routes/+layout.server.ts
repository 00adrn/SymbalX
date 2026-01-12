import type { LayoutServerLoad } from './$types.js';

export const load: LayoutServerLoad = async ({ fetch, locals: { safeGetSession }, cookies }) => {

    const { session, user } = await safeGetSession();


    const colors = ["#252530", "#2e2d38", "#232323"];

    if (!session)
        console.log("Session was undefined");
    if (user)
        console.log("User was undefined");


    return {
        colors: colors,
        session, 
        user, 
        cookies: cookies.getAll(), 
    }
}