import { get } from "./api.js";

export async function getAllPets(){
    return get('/data/pets?sortBy=_createdOn%20desc&distinct=name');
}
export async function getById(id){
    return get(`/data/pets/${id}`);
}