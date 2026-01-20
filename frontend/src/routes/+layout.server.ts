import type { LayoutServerLoad } from './$types.js';
import { supabase } from '$lib/supabaseClient';

export const load: LayoutServerLoad = async ({ fetch, locals: { safeGetSession }, cookies }) => {

    const { session, user } = await safeGetSession();

    let userData = null;

    if (session) {
        let userResp = await supabase.from("user_profile_info").select().eq("user_id", session?.user.id);
        userData = userResp.data![0];
        console.log("user data loaded successfully");
    }

    const colors = ["#252530", "#2e2d38", "#232323", "#505052"];

    return {
        colors: colors,
        cookies: cookies.getAll(), 
        session,
        user,
        userData,
    }
}

