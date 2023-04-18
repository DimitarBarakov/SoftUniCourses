import { get, post } from "./api.js";

export async function getAllPosts(){
    return get('/data/offers?sortBy=_createdOn%20desc');
}
export async function getById(id){
    return get(`/data/offers/${id}`);
}
