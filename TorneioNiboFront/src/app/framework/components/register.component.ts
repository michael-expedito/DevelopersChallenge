import { FunctionsService } from './../services/functions.service';
import { ResponseApi } from './../models/response-api';
import { Message } from './../models/message.model';

import { NgForm } from "@angular/forms";
import { OnInit, ViewChild } from "@angular/core";
import { ActivatedRoute, Router } from '@angular/router';
import { CrudService } from '../services/crud.service';

export abstract class RegisterComponent<T> implements OnInit {

  @ViewChild("form")
  form: NgForm;

  entity: T;

  constructor(
    protected service: CrudService<T>,
    protected route: ActivatedRoute,
    protected router: Router
  ) {}

  messages: Message[];

  ngOnInit() {
    const id: number = this.route.snapshot.params['id'];
    if (id != undefined) {
      this.findById(id);
    }
    this.entity = this.createEntity();
  }

  abstract createEntity(): T;

  protected showMessage(messages: Message[]): void {
    this.messages = messages;
    document.getElementById('openModalButton').click();
  }

  abstract isUpdateMode(): boolean;

  save() {
    if (this.isUpdateMode()) {
      this.service
        .update(this.entity)
        .subscribe((responseApi: ResponseApi) => {
          const mensagens: Array<Message> = responseApi.messages;
          if (!FunctionsService.hasErrors(mensagens)) {
            this.form.resetForm();
          }
          this.showMessage(mensagens);
        });
    } else {
      this.service
        .create(this.entity)
        .subscribe((responseApi: ResponseApi) => {
          const mensagens: Array<Message> = responseApi.messages;
          if (!FunctionsService.hasErrors(mensagens)) {
            this.form.resetForm();
          }
          this.showMessage(mensagens);
        });
    }
  }
  delete(){
    const id: number = this.route.snapshot.params['id'];
    if (id != undefined) {
      this.service
      .delete(id)
      .subscribe((responseApi: ResponseApi) => {
        const mensagens: Array<Message> = responseApi.messages;
        if (!FunctionsService.hasErrors(mensagens)) {
          this.form.resetForm();
        }
        this.showMessage(mensagens);
      });
    }
  }

  findById(id: number) {
    this.service.findById(id).subscribe((responseApi: ResponseApi) => {
      this.entity = responseApi.data;
      this.afterFindById(this.entity);
    });
  }

  afterFindById(entity: T){}

  abstract getRouterLink(): string;

  back() {
    this.router.navigate(['/'+this.getRouterLink()]);
  }
}
