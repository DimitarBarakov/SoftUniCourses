function solve(input) {
    let juiceAndQuantity = new Map();
    for (const inputInfo of input) {
        let splitted = inputInfo.split(" => ")
        let juice = splitted[0];
        let quantity = Number(splitted[1]);
        if (!juiceAndQuantity.has(juice)) {

            juiceAndQuantity.set(juice, quantity);
            juiceAndQuantity[juice] = 0;
        } else {
            juiceAndQuantity.set(juice, juiceAndQuantity.get(juice) + quantity)

        }
    }
    console.log(juiceAndQuantity)
}

solve(['Kiwi => 234',
    'Pear => 2345',
    'Watermelon => 3456',
    'Kiwi => 4567',
    'Pear => 5678',
    'Watermelon => 6789']
)