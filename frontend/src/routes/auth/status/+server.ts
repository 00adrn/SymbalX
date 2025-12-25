import type { RequestHandler } from './$types';
import { json } from '@sveltejs/kit';


export const GET: RequestHandler = async ({ cookies }) => {
    const accessToken = cookies.get("accessToken");
    
    return json(accessToken);
}