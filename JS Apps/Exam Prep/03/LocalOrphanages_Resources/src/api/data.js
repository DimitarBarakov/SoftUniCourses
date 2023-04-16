import { get, post } from "./api.js";

export async function getAllPosts(){
    return get('/data/posts?sortBy=_createdOn%20desc');
}
export async function getById(id){
    return get(`/data/posts/${id}`);
}
export async function createPost(data){
    post('/data/posts', data);
}