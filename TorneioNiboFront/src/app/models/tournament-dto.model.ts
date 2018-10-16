import { PhaseDto } from './phase-dto.model';

export class TournamentDto{
  constructor(

    public Id: number,
    public Name: string,
    public NumberTeams: number,
    public NumberPhases: number,
    public Phases: PhaseDto[]

  ){}
}
