function area(radius){
    let type = typeof(radius)
    let result;
    if(type !== "number"){
        console.log(`We can not calculate the circle area, because we receive a ${type}.`)
    }
    else{
        result = radius*radius*Math.PI
    }
    console.log(result.toFixed(2))

}

area(5)