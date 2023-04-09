async function lockedProfile() {
    const response = fetch(`http://localhost:3030/jsonstore/advanced/profiles`)
    const data = (await response).json()
    console.log(Object.entries(data))
}