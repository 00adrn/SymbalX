import type { RequestHandler } from './$types';
import { json } from '@sveltejs/kit';


export const GET: RequestHandler = async ({ cookies }) => {
    const accessToken = cookies.get("accessToken");
    if (accessToken)
        return json({res: "true"})
    
    return json({res: "false"});
}