import { TeamDto } from './../models/team-dto.model';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CrudService } from '../framework/services/crud.service';
import { ADDRESS_API } from '../models/address-api';

@Injectable({
  providedIn: 'root'
})
export class TeamService extends CrudService<TeamDto> {

  constructor(protected http: HttpClient) {
    super(http);
  }

  getAdressAPI(): string {
    return ADDRESS_API+'team/';
  }
}
