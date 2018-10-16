import { MatchDto } from "./match-dto.model";
import { TournamentDto } from 'src/app/models/tournament-dto.model';

export class PhaseDto {

  constructor(
    public Id: number,
    public NumberPhase: number,
    public Matches: MatchDto[],
    public Closed: boolean
  ){}
}
