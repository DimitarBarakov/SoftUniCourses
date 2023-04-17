import { get, post } from "./api.js";

export async function getAllPosts(){
    return get('/data/shoes?sortBy=_createdOn%20desc');
}
export async function getById(id){
    return get(`/data/shoes/${id}`);
}
export async function createPost(data){
    post('/data/posts', data);
}