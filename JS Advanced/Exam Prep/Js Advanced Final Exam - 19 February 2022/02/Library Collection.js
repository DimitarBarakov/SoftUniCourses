class LibraryCollection{
    constructor(capacity) {
        this.capacity = Number(capacity);
        this.books = [];
    }
    addBook (bookName, bookAuthor){
        if (this.books.length === this.capacity){
            throw new Error("Not enough space in the collection.")
        }
        this.books.push({
            bookName,
            bookAuthor,
            payed: false
        })
        return `The ${bookName}, with an author ${bookAuthor}, collect.`
    }
    payBook(bookName){
        let book = this.books.find(b=>b.bookName === bookName)
        if (!book){
            throw new Error(`${bookName} is not in the collection.`)
        }
        if (book.payed){
            throw new Error(`${bookName} has already been paid.`)
        }
        book.payed = true;
        return `${bookName} has been successfully paid.`
    }
    removeBook(bookName){
        let book = this.books.find(b=>b.bookName === bookName)
        if (!book){
            throw new Error("The book, you're looking for, is not found.")
        }
        if (!book.payed){
            throw new Error(`${bookName} need to be paid before removing from the collection.`)
        }
        let indexToRemove = this.books.indexOf(book)
        this.books.splice(indexToRemove,1)
        return `${bookName} remove from the collection.`
    }
    getStatistics(bookAuthor) {
        if (!bookAuthor) {
            let emptySlots = this.capacity - this.books.length;
            let buff = []
            buff.push(`The book collection has ${emptySlots} empty spots left.`)
            this.books.sort((b1, b2) => b1.bookName - b2.bookName)
                .forEach(b => buff.push(`${b.bookName} == ${b.bookAuthor} - ${b.payed ? 'Has Paid' : 'Not Paid'}.`))
            return buff.join('\n').trim();
        } else {
            let booksByAuthor = this.books.filter(b => b.bookAuthor === bookAuthor)
            if (booksByAuthor.length === 0) {
                throw new Error(`${bookAuthor} is not in the collection.`)
            }
            let buff = [];
            booksByAuthor.forEach(b => buff.push(`${b.bookName} == ${b.bookAuthor} - ${b.payed ? 'Has Paid' : 'Not Paid'}.`))
            return buff.join('\n').trim()
        }
    }
}

const library = new LibraryCollection(2)
console.log(library.addBook('Don Quixote', 'Miguel de Cervantes'));
console.log(library.getStatistics('Miguel de Cervantes'));
