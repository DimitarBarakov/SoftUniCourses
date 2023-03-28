function solve(data,criteriaInput){
    data = JSON.parse(data);
    let criteria = criteriaInput.split('-')[0];
    let value = criteriaInput.split('-')[1];
    if (criteria !== 'all'){
        data = data.filter((emp) => emp[criteria] == value)

    }
    data.forEach((emp,i) => console.log(`${i}. ${emp.first_name} ${emp.last_name} - ${emp.email}`));

}
solve(`[{

"id": "1",

"first_name": "Kaylee",

"last_name": "Johnson",

"email": "k0@cnn.com",

"gender": "Female"

}, 
{
"id": "2", 
"first_name": "Kizzee", 
"last_name": "Johnson", 
"email": "kjost1@forbes.com", 
"gender": "Female" }, 
{ 
"id": "3", 
"first_name": "Evanne", 
"last_name": "Maldin", 
"email": "emaldin2@hostgator.com", 
"gender": "Male" }, 
{ "id": "4", 
"first_name": "Evanne", 
"last_name": "Johnson", 
"email": "ev2@hostgator.com", 
"gender": "Male" }]`,
    'all')