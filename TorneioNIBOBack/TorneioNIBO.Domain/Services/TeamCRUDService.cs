using TorneioNIBO.Domain.Entities;
using TorneioNIBO.Domain.Interfaces.Repositories;
using TorneioNIBO.Domain.Interfaces.Services;

namespace TorneioNIBO.Domain.Services
{
    public class TeamCRUDService : BaseCRUDService<Team>, ITeamCRUDService
    {
        public TeamCRUDService(ITeamRepository repository) : base(repository)
        {
        }

        protected bool ValidTeam(Team entity)
        {
            if (string.IsNullOrEmpty(entity.Name))
            {
                messages.Add(new Message("", MessageType.error, "O campo 'Nome' é um campo obrigatório."));
            }

            if (entity.Name.Length > 50)
            {
                messages.Add(new Message("", MessageType.error, "O campo 'Nome' deve ter no máximo 50 caracteres."));
            }

            if (entity.Description.Length > 150)
            {
                messages.Add(new Message("", MessageType.error, "O campo 'Descrição' deve ter no máximo 150 caracteres."));
            }

            return !HasFatalError();
        }

        public override bool ValidSave(Team entity)
        {
            return ValidTeam(entity);
        }

        public override bool ValidUpdate(Team entity)
        {
            return ValidTeam(entity);
        }
    }
}
