using System.Web.Http;
using TorneioNIBO.Application;
using TorneioNIBO.Application.Interface;
using TorneioNIBO.Domain.Interfaces.Repositories;
using TorneioNIBO.Domain.Interfaces.Services;
using TorneioNIBO.Domain.Services;
using TorneioNIBO.Infra.Data.Repositories;
using Unity;
using Unity.WebApi;

namespace TorneioNIBO.API
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType(typeof(IAppBaseCRUDService<>), typeof(AppBaseCRUDService<>));
            container.RegisterType<ITeamAppCRUDService, TeamAppCRUDService>();
            container.RegisterType<ITournamentAppCRUDService, TournamentAppCRUDService>();
            container.RegisterType<ITournamentAppBusinessService, TournamentAppBusinessService>();
            container.RegisterType<IPhaseAppCRUDService, PhaseAppCRUDService>();
            container.RegisterType<IMatchAppCRUDService, MatchAppCRUDService>();

            container.RegisterType(typeof(IBaseCRUDService<>), typeof(BaseCRUDService<>));
            container.RegisterType<ITeamCRUDService, TeamCRUDService>();
            container.RegisterType<ITournamentCRUDService, TournamentCRUDService>();
            container.RegisterType<ITournamentBusinessService, TournamentBusinessService>();
            container.RegisterType<IPhaseCRUDService, PhaseCRUDService>();
            container.RegisterType<IMatchCRUDService, MatchCRUDService>();

            container.RegisterType<IBaseBusinessService, BaseBusinessService>();
            container.RegisterType<ITournamentBusinessService, TournamentBusinessService>();

            container.RegisterType(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            container.RegisterType<ITeamRepository, TeamRepository>();
            container.RegisterType<ITournamentRepository, TournamentRepository>();
            container.RegisterType<IPhaseRepository, PhaseRepository>();
            container.RegisterType<IMatchRepository, MatchRepository>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}