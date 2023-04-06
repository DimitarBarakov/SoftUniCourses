window.addEventListener("load", solve);

function solve(){
    let title = document.getElementById('post-title')
    let category = document.getElementById('post-category')
    let content = document.getElementById('post-content')



    let reviewList = document.getElementById("review-list");
    let publishedList = document.getElementById("published-list")

    let publishBtn = document.getElementById('publish-btn')
    publishBtn.addEventListener('click', function (e){
        let titleValue = title.value;
        let categoryValue = category.value;
        let contentValue = content.value;

        console.log(titleValue)
        console.log(categoryValue)
        console.log(contentValue)

        let li = document.createElement('li');
        let article = document.createElement('article');
        let h4 = document.createElement('h4')
        h4.textContent = titleValue;
        let p1 = document.createElement('p')
        p1.textContent = "Category: " + categoryValue
        let p2 = document.createElement('p')
        p2.textContent = "Content: " + contentValue;

        article.appendChild(h4);
        article.appendChild(p1);
        article.appendChild(p2);
        li.appendChild(article)

        let editBtn = document.createElement('button');
        editBtn.classList.add("action-btn");
        editBtn.classList.add("edit");
        editBtn.value = "Edit";
        editBtn.addEventListener("click", editPost)

        let approveBtn = document.createElement('button');
        approveBtn.classList.add("action-btn")
        approveBtn.classList.add("approve")
        approveBtn.value = "Approve"
        approveBtn.addEventListener("click", approvePost)

        li.appendChild(editBtn)
        li.appendChild(approveBtn)
        li.classList.add("rpost")
        reviewList.appendChild(li);

        title.value = "";
        content.value = "";
        category.value = "";

        function editPost(){
            title.value = titleValue;
            content.value = contentValue;
            category.value = categoryValue;
            reviewList.removeChild(li);
        }
        function approvePost(){

            li.removeChild(editBtn)
            li.removeChild(approveBtn)
            publishedList.appendChild(li);
        }
    })
    let clearBtn = document.getElementById("clear-btn");
    clearBtn.addEventListener("click", function (){
        publishedList.innerHTML = "";
    })
}