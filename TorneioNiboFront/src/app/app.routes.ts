import { TeamRegisterComponent } from './components/team/team-register/team-register.component';
import { HomeComponent } from './components/_layout/home/home.component';
import { Routes, RouterModule } from '@angular/router';
import { ModuleWithProviders } from '@angular/core';
import { TeamListComponent } from './components/team/team-list/team-list.component';
import { TournamentListComponent } from './components/tournament/tournament-list/tournament-list.component';
import { TournamentRegisterComponent } from './components/tournament/tournament-register/tournament-register.component';
import { ResultComponent } from './components/result/result.component';
import { MatchComponent } from './components/match/match.component';

export const ROUTES: Routes = [
    { path : '', component: HomeComponent},
    { path : 'home', component: HomeComponent},

    { path : 'team', component: TeamListComponent},
    { path : 'team/register', component: TeamRegisterComponent},
    { path : 'team/register/:id' , component: TeamRegisterComponent},

    { path : 'tournament', component: TournamentListComponent},
    { path : 'tournament/register', component: TournamentRegisterComponent},
    { path : 'tournament/register/:id' , component: TournamentRegisterComponent},

    { path : 'result', component: ResultComponent},

    { path : 'match', component: MatchComponent},
];

export const routes: ModuleWithProviders = RouterModule.forRoot(ROUTES);
