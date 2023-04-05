class ArtGallery{
    constructor(creator) {
        this.creator = creator;
        this.possibleArticles = { "picture":200,"photo":50,"item":250 }
        this.listOfArticles = []
        this.guests  = [];
    }
    addArticle( articleModel, articleName, quantity ){
        if (!this.possibleArticles.hasOwnProperty(articleModel.toLowerCase())){
            throw new Error("This article model is not included in this gallery!")
        }
        let currArticle = this.listOfArticles.find(art => art.articleName === articleName);
        if (!currArticle){
            this.listOfArticles.push({
                articleName,
                articleModel: articleModel.toLowerCase(),
                quantity: Number(quantity)
            });
        }
        else{
            currArticle.quantity+=Number(quantity);
        }
        return `Successfully added article ${articleName} with a new quantity- ${quantity}.`
    }
    inviteGuest ( guestName, personality){
        let currGuest = this.guests.find(g=>g.guestName === guestName);
        if (currGuest){
            throw new Error(`${guestName} has already been invited.`)
        }
        let points = 50;
        if (personality === "Vip"){
            points = 500;
        }
        else if (personality === "Middle"){
            points = 250;
        }
        this.guests.push(
            {
                guestName,
                points,
                purchaseArticle: 0
            })
        return `You have successfully invited ${guestName}!`
    }
    buyArticle ( articleModel, articleName, guestName){
        let currArticle = this.listOfArticles.find(art => art.articleName === articleName);
        if (!currArticle || !this.possibleArticles.hasOwnProperty(articleModel.toLowerCase()) || currArticle.articleModel !== articleModel.toLowerCase()){
            throw new Error("This article is not found.")
        }
        if (currArticle.quantity === 0){
            return `The ${articleName} is not available.`
        }
        let currGuest = this.guests.find(g=>g.guestName === guestName);
        if (!currGuest){
            return  "This guest is not invited.";
        }
        let neededPoints = Number(this.possibleArticles[articleModel.toLowerCase()])
        if (currGuest.points < neededPoints){
            return "You need to more points to purchase the article."
        }
        currGuest.points-=neededPoints;
        currGuest.purchaseArticle++;
        currArticle.quantity--;
        return `${guestName} successfully purchased the article worth ${neededPoints} points.`

    }
    showGalleryInfo (criteria){
        let buff = "";
        if (criteria === 'article'){
            buff += "Articles information:"
            this.listOfArticles.forEach(article=>buff+=`\n${article.articleModel} - ${article.articleName} - ${article.quantity}`)
        }
        else{
            buff+="Guests information:"
            this.guests.forEach(g=>buff+=`\n${g.guestName} - ${g.purchaseArticle} `)
        }
        return buff;
    }
}
const artGallery = new ArtGallery('Curtis Mayfield');
artGallery.addArticle('picture', 'Mona Liza', 3);
artGallery.addArticle('Item', 'Ancient vase', 2);
artGallery.addArticle('picture', 'Mona Liza', 1);
artGallery.inviteGuest('John', 'Vip');
artGallery.inviteGuest('Peter', 'Middle');
artGallery.buyArticle('picture', 'Mona Liza', 'John');
artGallery.buyArticle('item', 'Ancient vase', 'Peter');
console.log(artGallery.showGalleryInfo('article'));
console.log(artGallery.showGalleryInfo('guest'));

