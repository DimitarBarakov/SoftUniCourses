class Company{
    departments;
    constructor() {
        this.departments = new Map();
    }

    addEmployee(name, salary, position, department){
        if (!name || !salary || !position || !department || salary<0){
            throw new Error("Invalid input!");
        }
        let employee = {
            name,
            salary,
            position
        }
        if (!this.departments.has(department)){

            let employees = [];
            this.departments.set(department,employees)
        }
        this.departments["department"].push(employee);
    }
}
let c = new Company();

c.addEmployee("Stanimir", 2000, "engineer", "Construction");

c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");

c.addEmployee("Slavi", 500, "dyer", "Construction");

c.addEmployee("Stan", 2000, "architect", "Construction");

c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");

c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");

c.addEmployee("Gosho", 1350, "HR", "Human resources");
console.log(c.departments)