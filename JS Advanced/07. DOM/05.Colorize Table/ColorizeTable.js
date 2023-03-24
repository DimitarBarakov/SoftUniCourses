function colorize() {
    let rowsArray = document.getElementsByTagName('tr');
    for (let i = 1; i < rowsArray.length; i+=2) {
        rowsArray[i].style.background = 'Teal';
    }
}