function extract(elementID) {
    let textToExtract = document.getElementById(elementID).textContent;
    let pattern = /\(([^)]+)\)/g;

    let matches = textToExtract.matchAll(pattern);
    let res = "";
    for (let match of matches) {
        res+=match;
    }
    console.log(res);
}