import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { QueryParameters } from '../core/query-parameters';

import { BaseService } from './base.service';
import { Address } from '../models/address';

@Injectable({
  providedIn: 'root'
})
export class AddressService implements BaseService<Address> {

  baseUrl: string = `${environment.baseAPIUrl}/Addresses`;

  constructor(private http: HttpClient) {

  }

  getAll(sortBy: string, direction: string, filterBy: string): Observable<Address[]> {

    let queryParams: QueryParameters = {
      SortBy: sortBy,
      Direction: direction
    };

    let url: string = `${this.baseUrl}`;

    return this.http.get<Address[]>(url);
  }

  getAllByContact(contactID: number): Observable<Address[]> {    

    let url: string = `${this.baseUrl}/ByContact/${contactID}`;

    return this.http.get<Address[]>(url);
  }

  getLast10(): Observable<Address[]> {

    let url: string = `${this.baseUrl}/Last10`;

    return this.http.get<Address[]>(url);
  }

  getItem(id: number): Observable<Address> {
    return this.http.get<Address>(`${this.baseUrl}/${id}`);
  }



  insert(address: Address): Observable<Address> {
    return this.http.post<Address>(`${this.baseUrl}`, address);
  }

  update(id: number, address: Address) {
    return this.http.put<Address>(`${this.baseUrl}/${id}`, address);
  }

  delete(id: number) {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }
}
