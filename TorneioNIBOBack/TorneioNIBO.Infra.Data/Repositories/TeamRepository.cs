using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TorneioNIBO.Domain.Entities;
using TorneioNIBO.Domain.Interfaces.Repositories;

namespace TorneioNIBO.Infra.Data.Repositories
{
    public class TeamRepository : BaseRepository<Team>, ITeamRepository
    {

    }
}
