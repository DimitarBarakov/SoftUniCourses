const cinema = require("../cinema")
const {assert} = require('chai')

describe("CinemaTests",function (){
    describe("ShowMovies Tests", function (){
        it('should should throw error', function () {
            let movies = [];
            let res = cinema.showMovies(movies);
            assert.equal(res, 'There are currently no movies to show.')
        });
        it('should work ', function () {
            let movies = ["asd","zxc"];
            let res = cinema.showMovies(movies);
            assert.equal(res, "asd, zxc")
        });
    })
    describe("ticketPriceTests",function (){
        it('should throw error for wrong type', function () {
            assert.throw(()=>cinema.ticketPrice('asd'),'Invalid projection type.' )
        });
        it('should work', function () {
            assert.equal(cinema.ticketPrice("Premiere"), 12)
            assert.equal(cinema.ticketPrice("Normal"), 7.5)
            assert.equal(cinema.ticketPrice("Discount"), 5.5)
        });
    })
    describe('swapSeats',function (){
        it('should work', function () {
            let res = cinema.swapSeatsInHall(2,18)
            assert.equal(res,"Successful change of seats in the hall.")

        });
        it('should throw error', function () {
            assert.equal(cinema.swapSeatsInHall('2',{}),"Unsuccessful change of seats in the hall.")
            assert.equal(cinema.swapSeatsInHall(0,18),"Unsuccessful change of seats in the hall.")
            assert.equal(cinema.swapSeatsInHall(1,21),"Unsuccessful change of seats in the hall.")

        });
    })
})