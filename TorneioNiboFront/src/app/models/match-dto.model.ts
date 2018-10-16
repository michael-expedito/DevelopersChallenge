import { PhaseDto } from './phase-dto.model';
import { TeamDto } from './team-dto.model';

export class MatchDto {

  constructor(
    public Id: number,
    public NumberMatch: number,
    public FirstTeam: TeamDto,
    public SecondTeam: TeamDto,
    public WinnerTeam: TeamDto,
    public Phase: PhaseDto
  ){}
}
