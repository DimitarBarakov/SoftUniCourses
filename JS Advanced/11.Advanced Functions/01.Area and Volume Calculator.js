function solve(area, vol, input){
    let objs = JSON.parse(input);
    let res = [];
    for (let obj of objs) {

        let objArea = area.call(obj);
        let objVolume = vol.call(obj);

        res.push({
            area: objArea,
            volume: objVolume
        });
    }
    console.log(res)
}
function area() {

    return Math.abs(this.x * this.y);

};
function vol() {

    return Math.abs(this.x * this.y * this.z);

};
solve(area, vol, `[

{"x":"10","y":"-22","z":"10"},

{"x":"47","y":"7","z":"-5"},

{"x":"55","y":"8","z":"0"},

{"x":"100","y":"100","z":"100"},

{"x":"55","y":"80","z":"250"}

]`)