export const load = async ({ fetch }) => {
    const resp = await fetch("/auth/status", {
        method: "GET",
        credentials: "include"
    });

    const data = await resp.json();

    return {
        isLoggedIn: data.res == "true"
    }
}