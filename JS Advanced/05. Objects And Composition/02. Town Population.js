function solve(townsAndPopulationAsArray){
    let res = {};
    for(townAndPopulation of townsAndPopulationAsArray){
        let [name, population] = townAndPopulation.split(' <-> ');
        if(res[name] == undefined){
            res[name] = population;
        }
        else{
            res[name]+=population;
        }
    }
    for(town in res){
        console.log(`${town} : ${res[town]}`)
    }
}

solve(['Sofia <-> 1200000',
'Montana <-> 20000',
'New York <-> 10000000',
'Washington <-> 2345000',
'Las Vegas <-> 1000000']
)