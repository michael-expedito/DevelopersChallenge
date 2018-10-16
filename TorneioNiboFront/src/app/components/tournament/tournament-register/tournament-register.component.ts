import { PhaseDto } from "./../../../models/phase-dto.model";
import { ActivatedRoute, Router } from "@angular/router";
import { Component, OnInit } from "@angular/core";
import { RegisterComponent } from "src/app/framework/components/register.component";
import { TournamentDto } from "src/app/models/tournament-dto.model";
import { TournamentService } from "src/app/services/tournament.service";
import { MatchDto } from "../../../models/match-dto.model";
import { PhaseService } from "src/app/services/phase.service";
import { ResponseApi } from "src/app/framework/models/response-api";
import { Message } from "src/app/framework/models/message.model";
import { FunctionsService } from "src/app/framework/services/functions.service";
import { TeamDto } from "../../../models/team-dto.model";
import { TeamService } from "../../../services/team.service";

@Component({
  selector: "app-tournament-register",
  templateUrl: "./tournament-register.component.html",
  styleUrls: ["./tournament-register.component.css"]
})
export class TournamentRegisterComponent
  extends RegisterComponent<TournamentDto>
  implements OnInit {
  optionsNumberTeams = [
    { label: "2 Times", value: 2 },
    { label: "4 Times", value: 4 },
    { label: "8 Times", value: 8 },
    { label: "16 Times", value: 16 },
    { label: "32 Times", value: 32 }
  ];

  phaseSelected: PhaseDto;

  constructor(
    protected service: TournamentService,
    protected serviceTeam: TeamService,
    protected route: ActivatedRoute,
    protected router: Router
  ) {
    super(service, route, router);
  }
  
  teamsList: TeamDto[];

  ngOnInit() {
    super.ngOnInit();
    this.serviceTeam.findAll().subscribe((responseApi: ResponseApi) => {
      this.teamsList = responseApi['data'];
    });
  }

  createEntity(): TournamentDto {
    this.generatePhases(4);
    return new TournamentDto(null, "", 4, 2, null);
  }

  changeNumberTeams(event) {
    this.generatePhases(this.entity.NumberTeams);
  }

  generatePhases(numberTeams: number): any {
    this.service
      .generatePhases(numberTeams)
      .subscribe((responseApi: ResponseApi) => {
        let phases = responseApi["data"];
        this.phaseSelected = phases[0];
        this.entity.NumberPhases = phases.length;
        this.entity.Phases = phases;
        this.disabledBtnSearchTeam(event);
      });
  }

  generateTeams(): any {
    this.service
      .generateTeams(this.entity.NumberTeams)
      .subscribe((responseApi: ResponseApi) => {
        const mensagens: Array<Message> = responseApi["messages"];
        if (FunctionsService.hasErrors(mensagens)) {
          this.showMessage(mensagens);
        } else {
          let phases = responseApi["data"];
          this.entity.Phases[0] = phases[0];
          this.phaseSelected = this.entity.Phases[0];
        }
      });
  }

  statusBtnSearchTeam: boolean = false;

  disabledBtnSearchTeam(event) {
    if (this.phaseSelected.NumberPhase > 1) {
      this.statusBtnSearchTeam = true;
    } else {
      this.statusBtnSearchTeam = false;
    }
  }

  isUpdateMode(): boolean {
    return this.entity.Id != null;
  }

  getRouterLink(): string {
    return "tournament";
  }

  afterFindById(entity: TournamentDto) {
    if (entity.Phases != undefined) {
      this.phaseSelected = entity.Phases[0];
    }
  }

  display: boolean = false;
  messages: Message[];
  matchSelected: MatchDto = new MatchDto(
    null, 0, 
    new TeamDto(null, '',''), 
    new TeamDto(null, '',''), 
    new TeamDto(null, '',''), 
    null);
  
  showDialog(match: MatchDto) {
      this.display = true;
      this.matchSelected = match;
  }
  closeDialog(){
    this.display = false;
  }
}
