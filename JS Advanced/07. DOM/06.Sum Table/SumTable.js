function sumTable() {
    let cells = document.querySelectorAll('tr td:nth-child(2)')
    let res = 0;
    console.log(cells)
    for (let i = 0; i < cells.length - 1; i++) {
        res += Number(cells[i].textContent);
    }
    document.getElementById('sum').innerText = res.toString();
}