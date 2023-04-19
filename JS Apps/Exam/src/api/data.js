import { get, post } from "./api.js";

export async function getAllAlbums(){
    return get('/data/albums?sortBy=_createdOn%20desc');
}
export async function getById(id){
    return get(`/data/albums/${id}`);
}
