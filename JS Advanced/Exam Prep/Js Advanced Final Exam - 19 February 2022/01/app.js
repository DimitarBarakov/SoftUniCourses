function solve() {
    let fname = document.getElementById('fname')
    let lname = document.getElementById('lname')
    let email = document.getElementById('email')
    let birth = document.getElementById('birth')
    let position = document.getElementById('position')
    let salary = document.getElementById('salary')

    let addWorkerBtn = document.getElementById('add-worker')
    addWorkerBtn.addEventListener('click',function (e){
        e.preventDefault();
        let fnameValue = fname.value;
        let lnameValue = lname.value;
        let emailValue = email.value;
        let birthValue = birth.value;
        let positionValue = position.value;
        let salaryValue = Number(salary.value);

        if (!fnameValue || !lnameValue || !emailValue || !birthValue || !positionValue || !salaryValue){
            return;
        }
        let tableBody = document.getElementById('tbody');
        let newRow = document.createElement('tr');

        let fnameTd = document.createElement("td")
        fnameTd.textContent = fnameValue;
        let lnameTd = document.createElement("td")
        lnameTd.textContent = lnameValue;
        let emailTd = document.createElement("td")
        emailTd.textContent = emailValue;
        let birthTd = document.createElement("td")
        birthTd.textContent = birthValue
        let positionTd = document.createElement("td")
        positionTd.textContent = positionValue;
        let salaryTd = document.createElement("td")
        salaryTd.textContent = salaryValue;
        let actionsTd = document.createElement('td');

        let fireBtn = document.createElement('button')
        fireBtn.textContent = "Fired";
        fireBtn.classList.add('fired')

        let editBtn = document.createElement('button')
        editBtn.textContent = "Edit";
        editBtn.classList.add('edit')

        actionsTd.appendChild(fireBtn)
        actionsTd.appendChild(editBtn)

        newRow.appendChild(fnameTd);
        newRow.appendChild(lnameTd);
        newRow.appendChild(emailTd);
        newRow.appendChild(birthTd);
        newRow.appendChild(positionTd);
        newRow.appendChild(salaryTd);
        newRow.appendChild(actionsTd);

        tableBody.appendChild(newRow);

        fname.value = "";
        lname.value = "";
        email.value = "";
        birth.value = "";
        position.value = ""
        salary.value = "";

        let sum = document.getElementById('sum');
        let sumValue = Number(sum.textContent);
        sumValue += Number(salaryValue);
        sum.innerText = sumValue.toFixed(2);

        editBtn.addEventListener('click',function (){
            fname.value = fnameValue;
            lname.value = lnameValue
            email.value = emailValue
            birth.value = birthValue
            position.value = positionValue
            salary.value = salaryValue

            sumValue -= Number(salaryValue);
            sum.innerText = sumValue.toFixed(2);
            tableBody.removeChild(newRow)
        })
        fireBtn.addEventListener("click",function (){
            sumValue -= Number(salaryValue);
            sum.innerText = sumValue.toFixed(2);
            tableBody.removeChild(newRow)
        })
    })
}
solve()