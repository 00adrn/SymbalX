import { spotifyBE } from '../tssrc/apiRequests'

let isLoggedIn = $state(false);

export async function refreshLoginStatus() {
    isLoggedIn = await spotifyBE.verifyLogin();
}

export function checkLoginStatus(){
    return isLoggedIn;
}