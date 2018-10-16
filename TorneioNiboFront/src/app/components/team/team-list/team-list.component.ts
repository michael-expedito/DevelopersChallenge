import { TournamentDto } from 'src/app/models/tournament-dto.model';
import { Router } from '@angular/router';
import { TeamService } from './../../../services/team.service';
import { TeamDto } from './../../../models/team-dto.model';
import { Component, OnInit } from '@angular/core';
import { ListComponent } from '../../../framework/components/list.component';

@Component({
  selector: 'app-team-list',
  templateUrl: './team-list.component.html',
  styleUrls: ['./team-list.component.css']
})
export class TeamListComponent extends ListComponent<TeamDto> implements OnInit {

  constructor(
    protected serviceTeam: TeamService,
    protected router: Router
  ) {
    super(serviceTeam, router);
  }

  ngOnInit() {
    super.ngOnInit();
  }

  getRouterLink(): string {
    return 'team';
  }
}
