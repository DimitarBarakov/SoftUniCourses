export function getUserData(){
    const userData = JSON.parse(sessionStorage.getItem('userData'));
    return userData;
}
export function setUserData(data){
    sessionStorage.setItem('userData', JSON.stringify(data))
}
export function clearUserData(){
    sessionStorage.removeItem('userData')
}