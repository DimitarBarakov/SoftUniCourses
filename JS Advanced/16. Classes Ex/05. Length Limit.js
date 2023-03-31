class Stringer{
    startingString
    maxLength
    currentString
    constructor(text,length) {
        this.startingString = text
        this.maxLength = length;
        this.currentString = this.startingString;
    }
    increase(length){
        this.maxLength+=length;
        if (this.maxLength >= this.startingString.length){
            this.currentString = this.startingString;
        }
        else{
            for (let i = this.currentString.length; i < this.maxLength; i++) {
                this.currentString+=this.startingString[i];
            }
        }
    }
    decrease(length){
        this.maxLength -= length;
        if (this.maxLength < 0){
            this.maxLength = 0;
        }
        this.currentString = this.currentString.slice(0,this.maxLength);
    }
    toString(){
        if (this.maxLength < this.startingString.length){
            this.currentString+="..."
        }
        return this.currentString
    }
}
let test = new Stringer("Test", 5);
console.log(test.toString()); // Test
test.decrease(3);
console.log(test.toString()); // Te...
test.decrease(5);
console.log(test.toString()); // ...
test.increase(4);
console.log(test.toString()); // Test