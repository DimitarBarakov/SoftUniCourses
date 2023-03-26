function deleteByEmail() {
    let emails = document.querySelectorAll("tr td:nth-child(2)");
    console.log(emails)
    let searchedEmail = document.getElementsByTagName("input")[0].value;
    for (let email of emails) {
        if (email.textContent === searchedEmail){
            email.parentElement.remove();
            break;
        }
    }
}