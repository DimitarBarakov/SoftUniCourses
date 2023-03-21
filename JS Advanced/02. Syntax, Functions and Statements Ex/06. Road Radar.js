function solve(speed, area){
    switch(area){
        case 'motorway':
            if(speed<=130){
                console.log(`Driving ${speed} km/h in a 130 zone`)
            }
            else{
                let diff = speed - 130;
                let status;
                if(diff <= 20){
                    status = 'speeding'
                    console.log()
                }
            }
    }
}