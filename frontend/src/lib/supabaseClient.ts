import { createServerClient } from "@supabase/ssr"
import { PUBLIC_SUPABASE_URL, PUBLIC_SUPABASE_PUBLISHABLE_KEY } from "$env/static/public" 

export const supabase = createClient(PUBLIC_SUPABASE_URL, PUBLIC_SUPABASE_PUBLISHABLE_KEY);

async function register(username: string, email: string, password: string) {
    const resp = await supabase.auth.signUp({
        email: email,
        password: password,
        options: {
            data: {
                username: username
            }
        }
    });

    return resp;
}

async function login(email: string, password: string) {
    const resp = await supabase.auth.signInWithPassword({
        email: email,
        password: password
    });

    return resp;
}

export const auth = {
    register,
    login,
}