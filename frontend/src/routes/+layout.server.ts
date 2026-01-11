
export const load = async ({ fetch, locals: { safeGetSession }, cookies }) => {
    const { session, user } = await safeGetSession();

    let resp = await fetch("/auth/spotify/status", {
        method: "GET",
        credentials: "include"
    });

    const loginStatus = await resp.json();

    resp = await fetch("/api/user/get-profile", {
        method: "GET",
        credentials: "include"
    });

    const profile = await resp.json(); 

    const colors = ["#252530", "#2e2d38", "#232323"];


    return {
        isLoggedIn: loginStatus.res == "true",
        profile: profile,
        colors: colors,
        session, 
        user, 
        cookies: cookies.getAll(), 
    }
}