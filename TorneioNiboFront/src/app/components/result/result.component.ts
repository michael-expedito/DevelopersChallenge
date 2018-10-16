import { MatchDto } from '../../models/match-dto.model';
import { TournamentDto } from '../../models/tournament-dto.model';
import { Component, OnInit } from '@angular/core';
import { TournamentService } from 'src/app/services/tournament.service';
import { ResponseApi } from 'src/app/framework/models/response-api';
import { PhaseDto } from '../../models/phase-dto.model';
import { TeamDto } from '../../models/team-dto.model';
import { Message } from 'src/app/framework/models/message.model';
import { PhaseService } from 'src/app/services/phase.service';

@Component({
  selector: 'app-resultado',
  templateUrl: './result.component.html',
  styleUrls: ['./result.component.css']
})
export class ResultComponent implements OnInit {

  constructor(
    protected service: TournamentService,
    protected phaseService: PhaseService
  ) { }

  tournamentList: TournamentDto[];
  tournamentSelected: TournamentDto;
  phaseSelected: PhaseDto = new PhaseDto(null, 1, null, false);
  matchSelected: MatchDto = new MatchDto(null, 0, null, null, null, null);

  ngOnInit() {
    this.loadData();
  }

  loadData(){
    this.service.findAll().subscribe((responseApi: ResponseApi) => {
      this.tournamentList = responseApi['data'];
      this.tournamentSelected = this.tournamentList[0];
      this.phaseSelected = this.tournamentSelected.Phases[0];
      this.matchSelected = this.phaseSelected.Matches[0];
      this.teamsMatch = new Array<TeamDto>();
      this.teamsMatch.push(this.matchSelected.FirstTeam);
      this.teamsMatch.push(this.matchSelected.SecondTeam);
      this.changePhase(null);
    });
  }

  display: boolean = false;
  teamsMatch: TeamDto[];
  messages: Message[];

  showDialog(match: MatchDto) {
      this.teamsMatch = new Array<TeamDto>();
      this.display = true;
      this.matchSelected = match;
      this.teamsMatch.push(match.FirstTeam);
      this.teamsMatch.push(match.SecondTeam);
  }
  closeDialog(){
    this.display = false;
  }

  register(){
    this.phaseService.update(this.phaseSelected)
    .subscribe((responseApi: ResponseApi) => {
      const mensagens: Array<Message> = responseApi.messages;
      this.showMessage(mensagens);
      this.loadData();
    });
  }

  protected showMessage(messages: Message[]): void {
    this.messages = messages;
    document.getElementById('openModalButton').click();
  }

  disableBtnClosePhase: boolean = true;

  checkFaseIsComplete(): boolean{
    let result = true;

    for (var i = 0; i < this.phaseSelected.Matches.length; ++i) {
      var element = this.phaseSelected.Matches[i];

      if (element.WinnerTeam == null){
        result = false;
        break;
      }
    }
    return result;
  }

  changePhase(event){
    this.disableBtnClosePhase = (!this.checkFaseIsComplete() || this.phaseSelected.Closed);
  }

  closePhase(){
    this.service.closePhase(this.phaseSelected).subscribe(
      (responseApi: ResponseApi) => {
        const mensagens: Array<Message> = responseApi.messages;
        this.showMessage(mensagens);
        this.loadData();
      });
  }

  changeTournament(event){
    this.phaseSelected = this.tournamentSelected.Phases[0];
      this.matchSelected = this.phaseSelected.Matches[0];
      this.teamsMatch = new Array<TeamDto>();
      this.teamsMatch.push(this.matchSelected.FirstTeam);
      this.teamsMatch.push(this.matchSelected.SecondTeam);
      this.changePhase(null);
  }
}
