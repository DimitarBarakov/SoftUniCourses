const {sum} = require("../test")
const {expect} = require('chai')
describe('sum', function () {
    it('should work', function () {
        let input = [1,2,3]
        let res = sum(input);
        expect(res).to.be.equal(6);
    });
});