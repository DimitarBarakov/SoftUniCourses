const chooseYourCar = require("../chooseYourCar")
const {assert} = require('chai')

describe("Tests choseYourCar", function() {

    describe("choosingTypeTest", function() {
        it("Should throw invalid year error", function() {
            assert.throw(()=>chooseYourCar.choosingType('Sedan', 'red', 1899),"Invalid Year!")
            assert.throw(()=>chooseYourCar.choosingType('Sedan', 'red', 2023),"Invalid Year!")
        });
        it('should throw different type error', function () {
            assert.throw(()=>chooseYourCar.choosingType('Seda', 'red', 2020), "This type of car is not what you are looking for.")
        });
        it('should work correctly 1', function () {
            let res = "This red Sedan meets the requirements, that you have."
            assert.equal(chooseYourCar.choosingType('Sedan', 'red', 2010),res)
            assert.equal(chooseYourCar.choosingType('Sedan', 'red', 2020),res)
            assert.equal(chooseYourCar.choosingType('Sedan', 'red', 2022),res)
        });
        it('should work 2', function () {
            let expected = "This Sedan is too old for you, especially with that red color."
            assert.equal(chooseYourCar.choosingType('Sedan', 'red', 2009),expected)
            assert.equal(chooseYourCar.choosingType('Sedan', 'red', 1900),expected)

        });
    });
    describe("brandName tests", function (){
        it('should throw invalid operation error', function () {
            let expected = "Invalid Information!";
            assert.throw(()=>chooseYourCar.brandName(['bmw','audi','mercedes'],-1),expected)
            assert.throw(()=>chooseYourCar.brandName(['bmw','audi','mercedes'],3),expected)
            assert.throw(()=>chooseYourCar.brandName(['bmw','audi','mercedes'],'1'),expected)
            assert.throw(()=>chooseYourCar.brandName(['bmw','audi','mercedes'],{}),expected)
            assert.throw(()=>chooseYourCar.brandName(['bmw','audi','mercedes'],[]),expected)
            assert.throw(()=>chooseYourCar.brandName("asdasd",1),expected)
            assert.throw(()=>chooseYourCar.brandName({},1),expected)
            assert.throw(()=>chooseYourCar.brandName("asdasd",-1),expected)
            assert.throw(()=>chooseYourCar.brandName({},-1),expected)
        });
        it('should work', function () {
            let expected = 'audi, mercedes';
            assert.equal(chooseYourCar.brandName(['bmw','audi','mercedes'],0),expected)
        });
        it('should work 1', function () {
            let expected = 'bmw, audi';
            assert.equal(chooseYourCar.brandName(['bmw','audi','mercedes'],2),expected)
        });
    });
    describe("carFuelConsumption tests",function (){
        it('should throw invalid operation error', function () {
            let expected = "Invalid Information!"
            assert.throw(()=>chooseYourCar.carFuelConsumption(0,0),expected)
            assert.throw(()=>chooseYourCar.carFuelConsumption(0,1),expected)
            assert.throw(()=>chooseYourCar.carFuelConsumption(1,0),expected)
            assert.throw(()=>chooseYourCar.carFuelConsumption({},1),expected)
            assert.throw(()=>chooseYourCar.carFuelConsumption([],1),expected)
            assert.throw(()=>chooseYourCar.carFuelConsumption('',1),expected)
            assert.throw(()=>chooseYourCar.carFuelConsumption(1,{}),expected)
            assert.throw(()=>chooseYourCar.carFuelConsumption(1,[]),expected)
            assert.throw(()=>chooseYourCar.carFuelConsumption(1,''),expected)
            assert.throw(()=>chooseYourCar.carFuelConsumption(-1,{}),expected)
            assert.throw(()=>chooseYourCar.carFuelConsumption(-1,[]),expected)
            assert.throw(()=>chooseYourCar.carFuelConsumption(-1,''),expected)
            assert.throw(()=>chooseYourCar.carFuelConsumption({},-1),expected)
            assert.throw(()=>chooseYourCar.carFuelConsumption([],-1),expected)
            assert.throw(()=>chooseYourCar.carFuelConsumption('',-1),expected)
            assert.throw(()=>chooseYourCar.carFuelConsumption({},{}),expected)
            assert.throw(()=>chooseYourCar.carFuelConsumption([],[]),expected)
            assert.throw(()=>chooseYourCar.carFuelConsumption('',''),expected)

        });
        it('should work 1', function () {
            assert.equal(chooseYourCar.carFuelConsumption(100,6),`The car is efficient enough, it burns 6.00 liters/100 km.`)
            assert.equal(chooseYourCar.carFuelConsumption(100,7),`The car is efficient enough, it burns 7.00 liters/100 km.`)
        });
        it('should work 2', function () {
            assert.equal(chooseYourCar.carFuelConsumption(100,8),`The car burns too much fuel - 8.00 liters!`)
        });
    })
});
