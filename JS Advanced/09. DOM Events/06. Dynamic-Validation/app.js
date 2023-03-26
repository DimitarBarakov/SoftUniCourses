function validate() {
    let pattern = '[a-z]+@[a-z]+\\.[a-z]+';
    let input = document.getElementsByTagName('input');
    input.addEventListener('change',function (event){
        if (!pattern.test(event.target)){
            event.target.classList.add('error');
        }
    });
}