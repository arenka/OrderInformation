import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { map } from 'rxjs/operators';
import { Order } from "../models/Order";

@Injectable()
export class Store {
    constructor(private http: HttpClient) {


    }
    public orders:Order[] = [];

    loadOrders(): Observable<void>{
        return this.http.get<[]>("http://localhost:5191/api/OrderInformations")
            .pipe(map(data => {
                this.orders = data;
                return;
            }));
    }
    update(orderId: number,statuId : number): Observable<boolean> {
        return this.http
            .put<Response>(`$http://localhost:5191/api/OrderInformations/${orderId}/${statuId}`, {
                observe: 'response',
            })
            .pipe(
                map((response) => {
                    console.table(response);
                    return response.status === 204;
                })
            );
    }
}