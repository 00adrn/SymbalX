export const load = async ({ fetch }) => {
    const resp = await fetch("/auth/status", {
        method: "GET",
        credentials: "include"
    });

    const data = await resp.json();
    const colors = ["#252530", "#2e2d38", "#232323"];

    return {
        isLoggedIn: data.res == "true",
        colors: colors
    }
}