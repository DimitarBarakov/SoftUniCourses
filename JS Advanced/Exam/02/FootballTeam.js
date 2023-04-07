class footballTeam{
    constructor(name, country) {
        this.clubName = name
        this.country = country;
        this.invitedPlayers = [];
    }
    newAdditions(footballPlayers){
        for (let footballPlayer of footballPlayers) {
            let[name,age,value] = footballPlayer.split('/')
            value= Number(value);
            let currPlayer = this.invitedPlayers.find(pl=>pl.name === name);
            if (!currPlayer){
                this.invitedPlayers.push({
                    name,
                    age,
                    value: Number(value)
                })
            }
            else{
                if (value > currPlayer.value){
                    currPlayer.value = value;
                }
            }
        }
        let names = [];
        for (let player of this.invitedPlayers) {
            names.push(player.name)
        }
        let namesAsString = names.join(', ');
        let res = `You successfully invite ${namesAsString}.`
        return res;
    }
    signContract(selectedPlayer){
        let[name, offer] = selectedPlayer.split('/')
        let currPlayer = this.invitedPlayers.find(pl=>pl.name === name);
        if (!currPlayer){
            throw new Error(`${name} is not invited to the selection list!`)
        }
        if (offer < currPlayer.value){
            let priceDifference = currPlayer.value - offer;
            throw new Error(`The manager's offer is not enough to sign a contract with ${name}, ${priceDifference} million more are needed to sign the contract!`)
        }
        currPlayer.value = 'Bought'
        return `Congratulations! You sign a contract with ${currPlayer.name} for ${offer} million dollars.`
    }
    ageLimit(name, age){
        let currPlayer = this.invitedPlayers.find(pl=>pl.name === name);
        if (!currPlayer){
            throw new Error(`${name} is not invited to the selection list!`)
        }
        if (currPlayer.age < age){
            let ageDiff = age - currPlayer.age;
            if (ageDiff < 5){
                return `${name} will sign a contract for ${ageDiff} years with ${this.clubName} in ${this.country}!`
            }
            else {
                return `${name} will sign a full 5 years contract for ${this.clubName} in ${this.country}!`
            }
        }
        else{
            return `${name} is above age limit!`
        }
    }
    transferWindowResult(){
        let buff = [];
        this.invitedPlayers.sort((pl1,pl2) => pl1.name - pl2.name);
        buff.push("Players list:");
        this.invitedPlayers.forEach(pl=>buff.push(`Player ${pl.name}-${pl.value}`))
        return buff.join('\n').trimEnd();
    }
}
let fTeam = new footballTeam("Barcelona", "Spain");
console.log(fTeam.newAdditions(["Kylian Mbappé/23/160", "Lionel Messi/35/50", "Pau Torres/25/52"]));
console.log(fTeam.signContract("Kylian Mbappé/240"));
console.log(fTeam.ageLimit("Kylian Mbappé", 30));
console.log(fTeam.transferWindowResult());
