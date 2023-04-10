function attachEvents() {
    let authorElement = document.querySelector("input[name = 'author']")
    let contentElement = document.querySelector("input[name = 'content']")
    let messages = document.getElementById('messages')

    let sendBtn = document.getElementById('submit')
    let refreshBtn = document.getElementById('refresh')

    sendBtn.addEventListener("click", submitComment)
    refreshBtn.addEventListener("click", refreshComments)

    async function refreshComments(){
        messages.innerHTML = "";
        const response = await fetch('http://localhost:3030/jsonstore/messenger')
        const data = await response.json();
        console.log(data)
        Object.values(data).forEach((m)=>{
            messages.innerHTML += `${m.author}: ${m.content} <br>`
        })
    }

    async function submitComment(){
        let author = authorElement.value;
        let content = contentElement.value;
        let comment = {
            author,
            content
        }

        await fetch('http://localhost:3030/jsonstore/messenger',{
            method: 'post',
            headers:{
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(comment)
        })

    }
}

attachEvents();