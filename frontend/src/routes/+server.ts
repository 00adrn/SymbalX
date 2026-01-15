import type { RequestHandler } from "@sveltejs/kit"
import { redirect } from "@sveltejs/kit"

export const GET: RequestHandler = async ({ locals }) => {

    const { session, user } = await locals.safeGetSession();
    redirect(308, "/home")
}