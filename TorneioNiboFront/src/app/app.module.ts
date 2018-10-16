import { FrameworkModule } from './framework/framework.module';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { FooterComponent } from './components/_layout/footer/footer.component';
import { HeaderComponent } from './components/_layout/header/header.component';
import { HomeComponent } from './components/_layout/home/home.component';
import { MenuComponent } from './components/_layout/menu/menu.component';
import { TeamListComponent } from './components/team/team-list/team-list.component';
import { TeamRegisterComponent } from './components/team/team-register/team-register.component';
import { PrimeNGModule } from './prime-ng/prime-ng.module';
import { routes } from './app.routes';
import { HttpClientModule } from '@angular/common/http';
import { TournamentListComponent } from './components/tournament/tournament-list/tournament-list.component';
import { TournamentRegisterComponent } from './components/tournament/tournament-register/tournament-register.component';
import { ResultComponent } from './components/result/result.component';
import { MatchComponent } from './components/match/match.component';

@NgModule({
  declarations: [
    AppComponent,
    FooterComponent,
    HeaderComponent,
    HomeComponent,
    MenuComponent,
    TeamListComponent,
    TeamRegisterComponent,
    TournamentListComponent,
    TournamentRegisterComponent,
    ResultComponent,
    MatchComponent
  ],
  imports: [
    BrowserModule,
    PrimeNGModule,
    routes,
    HttpClientModule,
    FrameworkModule
  ],
  providers: [

  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
