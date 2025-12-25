import type { RequestHandler } from './$types';

export const GET: RequestHandler = async ({ cookies }) => {
    const accessToken = cookies.get("accessToken");
    const refreshToken = cookies.get("refreshToken");

}