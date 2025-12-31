import type { RequestHandler } from "@sveltejs/kit"
import type { Profile } from "$lib/api/types"
import { json } from "@sveltejs/kit"
import { PUBLIC_BACKENDURL } from "$env/static/public"

export const GET: RequestHandler = async ({ cookies }) => {
    const accessToken = cookies.get("accessToken");

    const response = await fetch(PUBLIC_BACKENDURL + "/api/profile-info", {
        method: "GET",
        headers: {
            Authorization : "Bearer " + accessToken
        }
    });

    const data : Profile = await response.json();
    return json(data);
}