class Ticket{
    destination
    price
    status
    constructor(destination,price,status) {
        this.destination = destination;
        this.price = price;
        this.status = status;
    }
}
function solve(input,criteria){
    let tickets = [];
    for (const info of input) {
        let ticketInfo = info.split("|");
        let ticketDestination = ticketInfo[0];
        let ticketPrice = ticketInfo[1];
        let ticketStatus = ticketInfo[2];
        let ticket = new Ticket(ticketDestination,ticketPrice,ticketStatus);
        tickets.push(ticket);
    }
    if (criteria === 'price'){
        tickets.sort((a,b) => a.price - b.price)
    }
    else if (criteria === 'destination'){
        tickets.sort((a, b) => a.destination.toLowerCase().localeCompare(b.destination.toLowerCase()))
    }
    else if (criteria === 'status'){
        tickets.sort((a, b) => a.status.toLowerCase().localeCompare(b.status.toLowerCase()))
    }
    console.log(tickets)
}
solve(['Philadelphia|94.20|available',

        'New York City|95.99|available',

        'New York City|95.99|sold',

        'Boston|126.20|departed'],

    'destination')