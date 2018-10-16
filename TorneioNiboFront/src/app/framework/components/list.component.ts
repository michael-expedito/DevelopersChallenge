import { ResponseApi } from './../models/response-api';
import { Router } from '@angular/router';
import { CrudService } from '../services/crud.service';

export abstract class ListComponent<T> {

  page = 0;
  count = 5;
  pages: Array<number>;

  list: Array<T>;

  constructor(
    protected service: CrudService<T>,
    protected router: Router
  ) { }

  ngOnInit() {
    this.findAll();
  }

  findAll(): any {
    this.service.findAll().subscribe((responseApi: ResponseApi) => {
      this.list = responseApi['data'];
    });
  }

  edit(id: string) {
    this.router.navigate(['/'+this.getRouterLink()+'/register', id]);
  }

  new() {
    this.router.navigate(['/'+this.getRouterLink()+'/register']);
  }

  abstract getRouterLink(): string;
}
