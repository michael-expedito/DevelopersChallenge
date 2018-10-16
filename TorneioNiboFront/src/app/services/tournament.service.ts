import { PhaseDto } from './../models/phase-dto.model';
import { HttpClient } from '@angular/common/http';
import { TournamentDto } from './../models/tournament-dto.model';
import { Injectable } from '@angular/core';
import { CrudService } from '../framework/services/crud.service';
import { ADDRESS_API } from '../models/address-api';

@Injectable({
  providedIn: 'root'
})
export class TournamentService extends CrudService<TournamentDto> {

  constructor(protected http: HttpClient) {
    super(http);
  }

  getAdressAPI(): string {
    return ADDRESS_API+'tournament/';
  }

  generatePhases(numberTeams: number){
    return this.http.get(`${this.getAdressAPI()}/generate-phases/${numberTeams}`);
  }

  generateTeams(numberTeams: number){
    return this.http.get(`${this.getAdressAPI()}/generate-teams/${numberTeams}`);
  }

  closePhase(phaseDto: PhaseDto){
    return this.http.put(`${this.getAdressAPI()}/close-phase/`, phaseDto);
  }

  generateTreeNodeTournament(idTournament: number){
    return this.http.get(`${this.getAdressAPI()}/generate-tree-node-tournament/${idTournament}`);
  }
}
