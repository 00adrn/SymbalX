let isLoggedIn = $state(false);
let userName = $state("");

async function startAuthentication() {
    window.location.href = "http://[::1]:5157/auth";
}

async function verifyLogin(){
    const response = await fetch('http://[::1]:5157/auth/validate', {
        credentials: 'include'
    });
    if (response.ok) return true;
    return false;
}

async function refreshLoginStatus() {
    isLoggedIn = await verifyLogin();
}

function checkLoginStatus(){
    return isLoggedIn;
}

async function getUserName() {
    const response = await fetch('http://[::1]:5157/auth/username-info', {
        credentials: 'include'
    });

}

export const authenticator = {
    startAuthentication,
    verifyLogin,
    checkLoginStatus,
    refreshLoginStatus

}