function solution(){
    class Employee{
        name
        age
        salary

        constructor(name, age) {
           this.name = name;
           this.age = age;
           this.salary = 0;
        }
        collectSalary(){
            console.log(`${this.name} received ${this.salary} this month.`)
        }
        
    }
}