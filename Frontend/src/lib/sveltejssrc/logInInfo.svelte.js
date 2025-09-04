let isLoggedIn = $state(false);
let userName = $state("");

async function startAuthentication() {
    window.location.href = "http://[::1]:5157/auth/login";
}

async function refreshLoginStatus() {
    const response = await fetch('http://[::1]:5157/auth/validate', {
        credentials: 'include'
    });
    if (response.ok) 
        isLoggedIn = true;
    else
        isLoggedIn = false;
}

function checkLoginStatus(){
    return isLoggedIn;
}


export const authenticator = {
    startAuthentication,
    checkLoginStatus,
    refreshLoginStatus

}