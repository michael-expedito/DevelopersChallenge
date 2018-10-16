import { ActivatedRoute, Router } from '@angular/router';
import { RegisterComponent } from './../../../framework/components/register.component';
import { Component, OnInit } from '@angular/core';
import { TeamDto } from '../../../models/team-dto.model';
import { TeamService } from '../../../services/team.service';

@Component({
  selector: 'app-team-register',
  templateUrl: './team-register.component.html',
  styleUrls: ['./team-register.component.css']
})
export class TeamRegisterComponent extends RegisterComponent<TeamDto> implements OnInit {

  constructor(
    protected service: TeamService,
    protected route: ActivatedRoute,
    protected router: Router
  ) {
    super(service, route, router);
  }

  createEntity(): TeamDto {
    return new TeamDto(null,'','');
  }

  isUpdateMode(): boolean {
    return (this.entity.Id != null);
  }

  getRouterLink(): string {
    return 'team';
  }
}
