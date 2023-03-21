function calculatePrice(fruit, grams, price){
    let kg = grams / 1000
    let totalPrice = price*kg
    console.log(`I need $${totalPrice.toFixed(2)} to buy ${kg.toFixed(2)} kilograms ${fruit}.`)
}

calculatePrice('apple', 1563, 2.35)