function solution(){
    class Post{
        title
        content
        constructor(title, content) {
            this.title = title;
            this.content = content;
        }
        toString(){
            return `Post: ${this.title}\nContent: ${this.content}`
        }
    }
    class SocialMediaPost extends Post{
        likes
        dislikes
        comments
        constructor(title, content, likes, dislikes) {
            super(title, content);
            this.likes = likes
            this.dislikes = dislikes;
            this.comments = [];
        }
        addComment(comment){
            this.comments.push(comment)
        }
        toString() {
            let res = super.toString() + `\nRating: ${this.likes - this.dislikes}`
            if (this.comments.length !== 0){
                res+="\nComments:"
                this.comments.forEach((c)=>res += `\n* ${c}`)
            }
            return res;
        }
    }
    class BlogPost extends Post{
        views
        constructor(title, content,views) {
            super(title,content);
            this.views = views
        }
        view(){
            this.views++;
            return this.views;
        }
        toString() {
            return super.toString() + `\nViews: ${this.views}`
        }
    }
    return {
        Post,
        SocialMediaPost,
        BlogPost
    }
}
const classes = solution();
let post = new classes.Post("Post", "Content");

console.log(post.toString());

// Post: Post
// Content: Content

let scm = new classes.SocialMediaPost("TestTitle", "TestContent", 25, 30);

scm.addComment("Good post");
scm.addComment("Very good post");
scm.addComment("Wow!");

console.log(scm.toString());

let bl = new classes.BlogPost("blog", "post", 10)
bl.view();
bl.view();
console.log(bl.toString())
