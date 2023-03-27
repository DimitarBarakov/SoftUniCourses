function create(words) {
    let content = document.getElementById('content')
    for (let word of words) {
        let newDiv = document.createElement('div');
        let newP = document.createElement("p");
        newP.style.display = 'none';
        newP.textContent = word;
        newDiv.append(newP);
        newDiv.addEventListener('click',function (event){
            newP.style.display = 'contents';
        })
        content.append(newDiv);
    }
}