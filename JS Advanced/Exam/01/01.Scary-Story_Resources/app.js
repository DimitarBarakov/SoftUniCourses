window.addEventListener("load", solve);

function solve() {
    let firstName = document.getElementById('first-name')
    let lastName = document.getElementById('last-name')
    let age = document.getElementById('age')
    let storyTitle = document.getElementById('story-title')
    let genre = document.getElementById('genre')
    let story = document.getElementById('story')

    let publishBtn = document.getElementById('form-btn');
    let previewList = document.getElementById('preview-list')

    publishBtn.addEventListener('click', function (){
        let firstNameValue = firstName.value;
        let lastNameValue = lastName.value;
        let ageValue = age.value;
        let storyTitleValue = storyTitle.value;
        let genreValue = genre.value;
        let storyValue = story.value;

        if (!firstNameValue || !lastNameValue || !ageValue || !storyValue || !storyTitleValue || !genreValue){
            return;
        }

        let newLi = document.createElement('li');
        newLi.classList.add("story-info")

        let newArticle = document.createElement('article')

        let h4 = document.createElement('h4');
        h4.textContent = `Name: ${firstNameValue} ${lastNameValue}`
        let pAge = document.createElement('p');
        pAge.textContent = `Age: ${ageValue}`;
        let pTitle = document.createElement('p');
        pTitle.textContent = `Title: ${storyTitleValue}`;
        let pGenre = document.createElement('p');
        pGenre.textContent = `Genre: ${genreValue}`;
        let pStory = document.createElement('p');
        pStory.textContent = `"${storyValue}"`;

        newArticle.appendChild(h4)
        newArticle.appendChild(pAge)
        newArticle.appendChild(pTitle)
        newArticle.appendChild(pGenre)
        newArticle.appendChild(pStory)

        let saveBtn = document.createElement('button')
        saveBtn.classList.add('save-btn')
        saveBtn.textContent = 'Save Story'

        let editBtn = document.createElement('button')
        editBtn.classList.add('edit-btn')
        editBtn.textContent = 'Edit Story'

        let deleteBtn = document.createElement('button')
        deleteBtn.classList.add('delete-btn')
        deleteBtn.textContent = 'Delete Story'

        newLi.appendChild(newArticle)
        newLi.appendChild(saveBtn)
        newLi.appendChild(editBtn)
        newLi.appendChild(deleteBtn)

        previewList.appendChild(newLi)

        firstName.value = '';
        lastName.value = '';
        age.value = '';
        storyTitle.value = '';
        story.value = '';
        genre.value = '';

        publishBtn.disabled = true;
        deleteBtn.disabled = false;
        editBtn.disabled = false;
        saveBtn.disabled = false;

        saveBtn.addEventListener('click',function (){
            let main = document.getElementById('main')
            main.innerHTML = ""
            let h1 = document.createElement('h1')
            h1.textContent = "Your scary story is saved!"
            main.appendChild(h1)
        })
        editBtn.addEventListener('click',function (){
            firstName.value = firstNameValue
            lastName.value = lastNameValue
            age.value = ageValue
            storyTitle.value = storyTitleValue
            story.value = storyValue;
            genre.value = genreValue;

            publishBtn.disabled = false;
            editBtn.disabled = true;
            saveBtn.disabled = true;
            deleteBtn.disabled = true;

            previewList.removeChild(newLi);
        })
        deleteBtn.addEventListener('click',function (){
            previewList.removeChild(newLi);
            publishBtn.disabled = false;
        })
    })
}
