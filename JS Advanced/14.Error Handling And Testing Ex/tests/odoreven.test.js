const {isOddOrEven} = require('../02.OddOrEven')
const {expect} = require('chai')

describe("isodddoreven",function(){
    it("should return undefined",()=>{
        let res = isOddOrEven(123)
        expect(res).to.be.undefined
    })
})