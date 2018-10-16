import { Injectable } from '@angular/core';
import { ADDRESS_API } from 'src/app/models/address-api';
import { CrudService } from 'src/app/framework/services/crud.service';
import { MatchDto } from 'src/app/models/match-dto.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class MatchService extends CrudService<MatchDto> {

  getAdressAPI(): string {
    return ADDRESS_API+'match/';
  }

  constructor(protected http: HttpClient) {
    super(http);
  }
}
