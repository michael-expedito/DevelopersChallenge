import { TournamentDto } from './../../../models/tournament-dto.model';
import { Component, OnInit } from '@angular/core';
import { ListComponent } from '../../../framework/components/list.component';
import { TournamentService } from '../../../services/tournament.service';
import { Router } from '@angular/router';
import { TreeNode } from 'primeng/components/common/treenode';
import { ResponseApi } from 'src/app/framework/models/response-api';

@Component({
  selector: 'app-tournament-list',
  templateUrl: './tournament-list.component.html',
  styleUrls: ['./tournament-list.component.css']
})
export class TournamentListComponent extends ListComponent<TournamentDto> implements OnInit {

  constructor(
    protected serviceTournament: TournamentService,
    protected router: Router
  ) {
    super(serviceTournament, router);
  }

  ngOnInit() {
    super.ngOnInit();
  }

  getRouterLink(): string {
    return 'tournament';
  }
}
