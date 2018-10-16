import { HttpClient } from '@angular/common/http';
import { ICrudService } from './icrud.service';

export abstract class CrudService<T> implements ICrudService<T> {

  constructor(protected http: HttpClient) {}

  create(entity: T) {
      return this.http.post(`${this.getAdressAPI()}`, entity);
  }

  update(entity: T) {
    return this.http.put(`${this.getAdressAPI()}`, entity);
  }

  findAll() {
    return this.http.get(`${this.getAdressAPI()}`);
  }

  findById(id: number) {
    return this.http.get(`${this.getAdressAPI()}${id}`);
  }

  delete(id: number) {
    return this.http.delete(`${this.getAdressAPI()}${id}`);
  }

  abstract getAdressAPI(): string ;
}
