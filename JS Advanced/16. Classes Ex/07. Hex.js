class Hex {
    value;
    constructor(value) {
        this.value = value;
    }
    parse(string){
        return parseInt(string,16)
    }
    valueOf(){
        return this.value;
    }
    toString(){
        return "0x"+ this.value.toString(16).toUpperCase()
    }
    plus(n){
        let result = (this.value + Number(n.valueOf()));
        return new Hex(result)
    }
    minus(n){
        let result = (this.value - Number(n.valueOf()));
        return new Hex(result)
    }
}
let FF = new Hex(255);
console.log(FF.toString());
let a = new Hex(10);
let b = new Hex(5);
console.log(a.plus(b).toString());
console.log(a.plus(b).toString()==='0xF');
console.log(FF.parse('AAA'));


