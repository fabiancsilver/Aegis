import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { QueryParameters } from '../core/query-parameters';

import { BaseService } from './base.service';
import { Contact } from '../models/contact';

@Injectable({
  providedIn: 'root'
})
export class ContactService implements BaseService<Contact> {

  baseUrl: string = `${environment.baseAPIUrl}/Contacts`;

  constructor(private http: HttpClient) {

  }

  getAll(sortBy: string, direction: string, filterBy: string): Observable<Contact[]> {

    let queryParams: QueryParameters = {
      SortBy: sortBy,
      Direction: direction
    };

    let url: string = `${this.baseUrl}`;

    return this.http.get<Contact[]>(url);
  }

  getItem(id: number): Observable<Contact> {
    return this.http.get<Contact>(`${this.baseUrl}/${id}`);
  }

  insert(contact: Contact): Observable<Contact> {
    return this.http.post<Contact>(`${this.baseUrl}`, contact);
  }

  update(id: number, contact: Contact) {
    return this.http.put<Contact>(`${this.baseUrl}/${id}`, contact);
  }

  delete(id: number) {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }

}
