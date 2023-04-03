class Restaurant{
    constructor(budget) {
        this.budgetMoney = budget;
        this.menu = {};
        this.stockProducts = {}
        this.history  = [];
    }
    loadProducts(products){
        for (let product of products) {
            let [productName, productQuantity, productTotalPrice ] = product.split(" ");
            let newProduct = {
                productName,
                productQuantity: Number(productQuantity),
            }
            if (productTotalPrice <= this.budgetMoney){
                if (this.stockProducts[newProduct.productName] === undefined){
                    this.stockProducts[newProduct.productName] = newProduct.productQuantity;
                }
                else{
                   this.stockProducts[newProduct.productName] += Number(productQuantity)
                }
                this.budgetMoney-=productTotalPrice;
                this.history.push(`Successfully loaded ${productQuantity} ${productName}`)
            }
            else{
                this.history.push(`There was not enough money to load ${productQuantity} ${productName}`)
            }
        }
        let res = '';
        this.history.forEach(h=>res+=`\n${h}`);
        return res;
    }
    addToMenu(meal, neededProducts, price){
        if (this.menu[meal] != undefined){
            return `The ${meal} is already in the our menu, try something different.`
        }
        else{
            for (let product of neededProducts) {
                let [name, quantity] = product.split(" ");
            }
        }
    }
}
let kitchen = new Restaurant(1000);
console.log(kitchen.loadProducts(['Banana 10 5', 'Banana 20 10', 'Strawberries 50 30', 'Yogurt 10 10', 'Yogurt 500 1500', 'Honey 5 50']));
