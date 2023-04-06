class Garden{
    spaceAvailable
    plants
    storage
    constructor(spaceAvailable) {
        this.spaceAvailable = spaceAvailable;
        this.plants = [];
        this.storage = [];
    }
    addPlant(plantName, spaceRequired){
        if (spaceRequired > this.spaceAvailable){
            throw new Error("Not enough space in the garden.");
        }
        let currPlant = {
            plantName,
            spaceRequired,
            ripe: false,
            quantity: 0
        }
        this.plants.push(currPlant);
        this.spaceAvailable-=spaceRequired
        return `The ${plantName} has been successfully planted in the garden.`
    }
    ripenPlant(plantName, quantity){
        let currPlant = this.plants.find(obj => {
           return obj.plantName === plantName;
        });
        if(currPlant === undefined){
            throw new Error(`There is no ${plantName} in the garden.`)
        }
        if (currPlant.ripe === true){
            throw new Error(`The ${plantName} is already ripe.`)
        }
        if (quantity <= 0){
            throw new Error("The quantity cannot be zero or negative.")
        }
        else if (quantity === 1){
            currPlant.ripe = true;
            currPlant.quantity+=quantity;
            return `${quantity} ${plantName} has successfully ripened.`
        }
        else{
            currPlant.ripe = true;
            currPlant.quantity+=quantity;
            return `${quantity} ${plantName}s has successfully ripened.`
        }
    }
    harvestPlant(plantName){
        let currPlant = this.plants.find(obj => {
            return obj.plantName === plantName;
        });
        if(currPlant === undefined){
            throw new Error(`There is no ${plantName} in the garden.`)
        }
        if (currPlant.ripe === false){
            throw new Error(`The ${plantName} cannot be harvested before it is ripe.`)
        }
        this.plants.remove(currPlant);
        this.storage.push(currPlant);
        this.spaceAvailable+=currPlant.spaceRequired;
        return `The {plantName} has been successfully harvested.`
    }
    generateReport(){
        let res = `The garden has ${ this.spaceAvailable } free space left.`
        res+= "\nPlants in the garden: "
        this.plants.sort((obj1,obj2) => obj1.plantName.localeCompare(obj2.plantName));
        let plantsNames = [];
        for (const plant of this.plants) {
            plantsNames.push(plant.plantName);
        }
        let plantNamesAsString = plantsNames.join(", ")
        res+=plantNamesAsString;
        if (this.storage.length === 0){
            res+="\nPlants in storage: The storage is empty."
        }
        else{

        }
    }

}
const myGarden = new Garden(250)
console.log(myGarden.addPlant('apple', 20));
console.log(myGarden.addPlant('orange', 200));
console.log(myGarden.addPlant('raspberry', 10));
console.log(myGarden.ripenPlant('apple', 10));
console.log(myGarden.ripenPlant('orange', 1));
console.log(myGarden.harvestPlant('apple'));
console.log(myGarden.harvestPlant('olive'));



