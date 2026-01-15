import type { LayoutServerLoad } from './$types.js';

export const load: LayoutServerLoad = async ({ fetch, locals: { safeGetSession }, cookies }) => {

    const { session, user } = await safeGetSession();

    const colors = ["#252530", "#2e2d38", "#232323"];

    return {
        colors: colors,
        cookies: cookies.getAll(), 
        session,
        user,
    }
}