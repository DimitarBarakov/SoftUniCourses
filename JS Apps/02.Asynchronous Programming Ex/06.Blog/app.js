function attachEvents() {
    let showPostsBtn = document.getElementById('btnLoadPosts')
    showPostsBtn.addEventListener("click", createOptions)
    let postsOptions = document.getElementById('posts')
    let btnViewPost = document.getElementById('btnViewPost')
    btnViewPost.addEventListener("click", viewPost)
    let postTitle = document.getElementById('post-title')
    postTitle.innerHTML = "";
    let postBody = document.getElementById('post-body')
    postBody.innerHTML = "";
    let commentsList = document.getElementById('post-comments')


    async function createOptions(){
        let response = await fetch('http://localhost:3030/jsonstore/blog/posts')
        let data = await response.json()
        let posts = Object.entries(data);
        posts.forEach(post=> {
            let newOption = document.createElement('option')
            newOption.textContent = post[1].title;
            newOption.value = post[0];
            postsOptions.appendChild(newOption)
        })
    }
    async function viewPost(){
        let postId = postsOptions.value;
        let response = await fetch(`http://localhost:3030/jsonstore/blog/posts/${postId}`)
        let data = await response.json()

        postTitle.textContent = data.title;
        postBody.textContent = data.body;
        commentsList.innerHTML = "";

        let commentsResponse = await fetch('http://localhost:3030/jsonstore/blog/comments')
        let commentsData = await commentsResponse.json();
        let comments = Object.entries(commentsData)
        comments.forEach(comment=>{
            if (comment[1].postId === postId){
                let li = document.createElement('li');
                li.textContent = comment[1].text;
                commentsList.appendChild(li);
            }
        })
    }
}

attachEvents();