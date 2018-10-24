using System;
using System.Collections.Generic;
using System.Linq;
using TorneioNIBO.Domain.Entities;
using TorneioNIBO.Domain.Interfaces.Repositories;
using TorneioNIBO.Domain.Interfaces.Services;

namespace TorneioNIBO.Domain.Services
{
    public class TournamentCRUDService : BaseCRUDService<Tournament>, ITournamentCRUDService
    {
        public TournamentCRUDService(ITournamentRepository repository) : base(repository)
        {
        }

        protected bool ValidTournament(Tournament entity)
        {
            if (string.IsNullOrEmpty(entity.Name))
            {
                messages.Add(new Message("", MessageType.error, "O campo 'Nome' é um campo obrigatório."));
            }

            if (entity.Name.Length > 50)
            {
                messages.Add(new Message("", MessageType.error, "O campo 'Nome' deve ter no máximo 50 caracteres."));
            }
            List<Team> teams = new List<Team>();
            foreach (var match in entity.Phases[0].Matches)
            {
                if (match.FirstTeam == null || match.FirstTeam?.Id == null)
                {
                    messages.Add(new Message("", MessageType.error, "Informe o time A da partida " + match.NumberMatch));
                }
                else
                {
                    teams.Add(match.FirstTeam);
                }
                if (match.SecondTeam == null || match.SecondTeam?.Id == null)
                {
                    messages.Add(new Message("", MessageType.error, "Informe o time B da partida " + match.NumberMatch));
                }
                else
                {
                    teams.Add(match.SecondTeam);
                }
            }

            var duplicates = teams.GroupBy(x => x.Id).Where(x => x.Count() > 1).Select(x => x.Key).ToList();
            if (duplicates.Count > 0)
            {
                duplicates.ForEach(x => messages.Add(
                    new Message("", 
                    MessageType.error, 
                    "O time " + teams.Where(t => t.Id == x).FirstOrDefault().Name + " foi relacionado em mais de uma partida")));
            }

            return !HasFatalError();
        }

        public override bool ValidSave(Tournament entity)
        {
            return ValidTournament(entity);
        }

        public override bool ValidUpdate(Tournament entity)
        {
            return ValidTournament(entity);
        }

    }
}
