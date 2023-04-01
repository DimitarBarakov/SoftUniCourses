function solve(){
    class Balloon{
        color
        hasWeight
        constructor(color,hasWeight) {
            this.color = color;
            this.hasWeight = hasWeight;
        }
    }
    class PartyBalloon extends Balloon{
        ribbon
        constructor(color, hasWeight, ribbonColor, ribbonLength) {
            super(color, hasWeight);
            this.ribbon = {
                color: ribbonColor,
                length: ribbonLength
            }
        }
        get ribbon(){
            return this.ribbon;
        }
    }
    class BirthdayBalloon extends PartyBalloon{
        text
        constructor(color, hasWeight, ribbonColor, ribbonLength, text) {
            super(color, hasWeight, ribbonColor, ribbonLength);
            this.text = text
        }
    }
    return{
        Balloon: Balloon,
        PartyBalloon: PartyBalloon,
        BirthdayBalloon: BirthdayBalloon
    }
}
let classes = solve();
let testBalloon = new classes.Balloon("yellow", 20.5);
let testPartyBalloon = new classes.PartyBalloon("yellow", 20.5, "red", 10.25);
let ribbon = testPartyBalloon.ribbon;
console.log(testBalloon);
console.log(testPartyBalloon);
console.log(ribbon);
