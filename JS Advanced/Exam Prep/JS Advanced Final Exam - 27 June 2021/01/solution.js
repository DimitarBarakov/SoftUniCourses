window.addEventListener('load', solution);

function solution() {
  let fullName = document.getElementById("fname");
  let email = document.getElementById("email");
  let phone = document.getElementById("phone");
  let address = document.getElementById("address");
  let code = document.getElementById("code");

  let previewList = document.getElementById("infoPreview");

  let submitBtn = document.getElementById("submitBTN");
  submitBtn.addEventListener('click', function (){
    let fullNameValue = fullName.value;
    let emailValue = email.value;
    let phoneValue = phone.value;
    let addressValue = address.value;
    let codeValue = code.value;

    if (!fullNameValue || !emailValue){
      return;
    }

    let fullNameLi = document.createElement('li');
    fullNameLi.textContent = `Full Name: ${fullNameValue}`;
    let emailLi = document.createElement('li');
    emailLi.textContent = `Email: ${emailValue}`;
    let phoneLi = document.createElement('li');
    phoneLi.textContent = `Phone Number: ${phoneValue}`;
    let addressLi = document.createElement('li');
    addressLi.textContent = `Address: ${addressValue}`;
    let codeLi = document.createElement('li');
    codeLi.textContent = `Post Code: ${codeValue}`;

    previewList.appendChild(fullNameLi);
    previewList.appendChild(emailLi);
    previewList.appendChild(phoneLi);
    previewList.appendChild(addressLi);
    previewList.appendChild(codeLi);

    submitBtn.disabled = true;
    let editBtn = document.getElementById("editBTN")
    let continueBtn = document.getElementById("continueBTN");
    editBtn.disabled = false;
    continueBtn.disabled = false;

    fullName.value = "";
    email.value = "";
    phone.value = "";
    address.value = "";
    code.value = "";

    editBtn.addEventListener("click", function (){
      fullName.value = fullNameValue;
      email.value = emailValue;
      phone.value = phoneValue;
      address.value = addressValue;
      code.value = codeValue;

      previewList.innerHTML = "";
      editBtn.disabled = true;
      continueBtn.disabled = true;
      submitBtn.disabled = false;
    })
    continueBtn.addEventListener('click',function (){
      let blockDiv = document.getElementById("block")
      blockDiv.innerHTML = "";
      let h3 = document.createElement('h3')
      h3.textContent = "Thank you for your reservation!"
      blockDiv.appendChild(h3);
    })
  })
}
