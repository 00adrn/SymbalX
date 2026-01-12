import { createBrowserClient } from "@supabase/ssr"
import { PUBLIC_SUPABASE_URL, PUBLIC_SUPABASE_PUBLISHABLE_KEY, PUBLIC_FRONTENDURL } from "$env/static/public"

export const supabase = createBrowserClient(PUBLIC_SUPABASE_URL, PUBLIC_SUPABASE_PUBLISHABLE_KEY);

async function signUp(username: string, email: string, password: string) {
    const { data, error} = await supabase.auth.signUp({
        email: email,
        password: password,
        options: {
            data: {
                username: username
            },
            emailRedirectTo: "/home"
        }
    });

    if (error) {
        console.log(error);
        return false;
    }

    console.log(data);
    return true;
}

async function signIn(email: string, password: string) {
    const { data, error} = await supabase.auth.signInWithPassword({
        email: email,
        password: password
    });

    if (error) {
        console.log(error);
        return false;
    }

    console.log(data);
    return true;
}

async function resetPassword(email: string) {
    const { data, error } = await supabase.auth.resetPasswordForEmail(email);
    if (error) {
        console.log(error);
        return false;
    }
    
    return true;
}

export const auth = {
    signUp,
    signIn,
}