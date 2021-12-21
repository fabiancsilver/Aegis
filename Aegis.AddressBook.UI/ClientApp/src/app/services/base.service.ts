import { Observable } from "rxjs";

export interface BaseService<T> {

  baseUrl: string;

  getAll(sortBy: string, direction: string, filterBy: string): Observable<T[]>;

  getItem(id: number): Observable<T>;

  insert(entity: T): Observable<T>;

  update(id: number, entity: T);

  delete(id: number);
}
