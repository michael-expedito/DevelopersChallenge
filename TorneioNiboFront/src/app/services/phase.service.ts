import { Injectable } from '@angular/core';
import { CrudService } from 'src/app/framework/services/crud.service';
import { PhaseDto } from 'src/app/models/phase-dto.model';
import { HttpClient } from '@angular/common/http';
import { ADDRESS_API } from 'src/app/models/address-api';

@Injectable({
  providedIn: 'root'
})
export class PhaseService extends CrudService<PhaseDto> {

  getAdressAPI(): string {
    return ADDRESS_API+'phase/';
  }

  constructor(protected http: HttpClient) {
    super(http);
  }
}
