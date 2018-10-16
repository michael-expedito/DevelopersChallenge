import { Component, OnInit } from '@angular/core';
import { TournamentDto } from '../../models/tournament-dto.model';
import { TournamentService } from 'src/app/services/tournament.service';
import { ResponseApi } from '../../framework/models/response-api';
import { TreeNode } from 'primeng/components/common/treenode';

@Component({
  selector: 'app-match',
  templateUrl: './match.component.html',
  styleUrls: ['./match.component.css']
})
export class MatchComponent implements OnInit {

  constructor(protected tournamentService: TournamentService) { }

  tournamentList: TournamentDto[];
  tournamentSelected: TournamentDto;

  ngOnInit() {
    this.loadData();
  }

  loadData(){
    this.tournamentService.findAll().subscribe((responseApi: ResponseApi) => {
      this.tournamentList = responseApi['data'];
      this.tournamentSelected = this.tournamentList[0];
      this.consultTree(this.tournamentSelected.Id);
    });
  }

  changeTournament(event){
    this.consultTree(this.tournamentSelected.Id);
  }

  dataTreeNode: TreeNode[];

  consultTree(idTournament: number){
    this.tournamentService.generateTreeNodeTournament(idTournament)
      .subscribe((responseApi: ResponseApi) => {
        this.dataTreeNode = responseApi['data'];
    });
  }
}
