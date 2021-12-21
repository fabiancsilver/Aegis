import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { QueryParameters } from '../core/query-parameters';

import { BaseService } from './base.service';
import { AddressType } from '../models/address-type';

@Injectable({
  providedIn: 'root'
})
export class AddressTypeService implements BaseService<AddressType> {

  baseUrl: string = `${environment.baseAPIUrl}/AddressTypes`;

  constructor(private http: HttpClient) {

  }

  getAll(sortBy: string, direction: string, filterBy: string): Observable<AddressType[]> {

    let queryParams: QueryParameters = {
      SortBy: sortBy,
      Direction: direction
    };

    let url: string = `${this.baseUrl}`;

    return this.http.get<AddressType[]>(url);
  }

  getItem(id: number): Observable<AddressType> {
    return this.http.get<AddressType>(`${this.baseUrl}/${id}`);
  }

  insert(addressType: AddressType): Observable<AddressType> {
    return this.http.post<AddressType>(`${this.baseUrl}`, addressType);
  }

  update(id: number, addressType: AddressType) {
    return this.http.put<AddressType>(`${this.baseUrl}/${id}`, addressType);
  }

  delete(id: number) {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }

}
