class VegetableStore{
    constructor(owner, location) {
        this.owner = owner;
        this.location = location;
        this.availableProducts = [];
    }
    loadingVegetables (vegetables){
        for (let vegetableInfo of vegetables) {
            let [type, quantity, price] = vegetableInfo.split(" ");
            let currVegetable = this.availableProducts.find(obj=>obj.type === type);
            if (currVegetable === undefined){
                this.availableProducts.push({
                    type,
                    quantity,
                    price
                })
            }
            else{
                currVegetable.quantity += quantity
                if (price > currVegetable.price){
                    currVegetable.price = price;
                }
            }
        }
    }
}