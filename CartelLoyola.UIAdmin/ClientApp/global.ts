//TOKEN
export let isLogged = false;
export let username = "";
export let TOKEN = "";

export function setToken(newToken: string, user: string) {
    isLogged = true;
    username = user;
    TOKEN = newToken;
}