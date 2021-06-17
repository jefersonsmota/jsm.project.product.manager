import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { ApiService } from '../api.service';
import { AppConstants } from "src/app/core/app.constants";
import { HttpHeaders } from '@angular/common/http';
import { CreateProductRequest } from '../../models/product/createProductRequest';
import { UpdateProductRequest } from '../../models/product/updateProductRequest';
import { DeleteProductRequest } from '../../models/product/deleteProductRequest';
import { Product } from '../../models/product/product';
import { serialize } from 'src/app/core/serialize';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class ProductService {

    private url: string = AppConstants.API_RESOURCE + AppConstants.PRODUCT_RESOURCE;

    constructor(private apiService: ApiService) {
        this.apiService.headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });
    }

    add(product: CreateProductRequest) {
        return this.apiService.http.post<any>(this.url, JSON.stringify(product), { headers: this.apiService.headers }).pipe(
            map(result => {
                return result;
            }));
    }

    update(product: UpdateProductRequest) {
        return this.apiService.http.put<any>(this.url, JSON.stringify(product), { headers: this.apiService.headers }).pipe(
            map(result => {
                return result;
            }));
    }

    delete(product: DeleteProductRequest) {
        return this.apiService.http.delete<any>(`${this.url}?Id=${product.Id}`, { headers: this.apiService.headers }).pipe(
            map(result => {
                return result;
            }));
    }

    get(id: string) {
        return this.apiService.http.get<Product>(`${this.url}?Id=${id}`, { headers: this.apiService.headers }).pipe(
            map(result => {
                return result;
            }));
    }

    getAll(filtro: any) : Observable<Product[]> {
        const queryFiltro = serialize(filtro);
        return this.apiService.http.get<any>(`${this.url}${queryFiltro == '' ? '/all' : '/all?' + queryFiltro}`, { headers: this.apiService.headers }).pipe(
            map(result => {
                return result.data;
            }));
    }

}
