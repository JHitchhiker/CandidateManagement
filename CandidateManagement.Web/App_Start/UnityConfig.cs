using System;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using CandidateManagement.Service;
using CandidateManagement.DAL;
using CandidateManagement.Data.Context;
using CandidateManagement.Web.Controllers;

namespace CandidateManagement.Web.App_Start
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your types here
            // container.RegisterType<IProductRepository, ProductRepository>();
            
            container.RegisterType<IBiteServiceService, BiteServiceService>();
            container.RegisterType<IContractStatusService, ContractStatusService>();
            container.RegisterType<IEthnicityService, EthnicityService>();
            container.RegisterType<IIntervieweeService, IntervieweeService>();
            container.RegisterType<IInterviewerService, InterviewerService>();
            container.RegisterType<IJobSeekerService, JobSeekerService>();
            container.RegisterType<ILeaverService, LeaverService>();
            container.RegisterType<IMembershipService, MembershipService>();
            container.RegisterType<IOriginatorService, OriginatorService>();
            container.RegisterType<IOriginService, OriginService>();
            container.RegisterType<IOutcomeService, OutcomeService>();
            container.RegisterType<IProfessionService, ProfessionService>();
            container.RegisterType<ISkillService, SkillService>();
            container.RegisterType<IVisaTypeService, VisaTypeService>();
            container.RegisterType<IWorkerService, WorkerService>();
            container.RegisterType<IReportService, ReportService>();
            container.RegisterType<IFinancialYearService, FinancialYearService>();

            container.RegisterType<IBiteServiceRepository, BiteServiceRepository>();
            container.RegisterType<IContractStatusRepository, ContractStatusRepository>();
            container.RegisterType<IEthnicityRepository, EthnicityRepository>();
            container.RegisterType<IIntervieweeRepository, IntervieweeRepository>();
            container.RegisterType<IInterviewerRepository, InterviewerRepository>();
            container.RegisterType<IJobSeekerRepository, JobSeekerRepository>();
            container.RegisterType<ILeaverRepository, LeaverRepository>();
            container.RegisterType<IMembershipRepository, MembershipRepository>();
            container.RegisterType<IOriginatorRepository, OriginatorRepository>();
            container.RegisterType<IOriginRepository, OriginRepository>();
            container.RegisterType<IOutcomeRepository, OutcomeRepository>();
            container.RegisterType<IProfessionRepository, ProfessionRepository>();
            container.RegisterType<ISkillRepository, SkillRepository>();
            container.RegisterType<IVisaTypeRepository, VisaTypeRepository>();
            container.RegisterType<IWorkerRepository, WorkerRepository>();
            container.RegisterType<IReportRepository, ReportRepository>();
            container.RegisterType<IFinancialYearRepository, FinancialYearRepository>();


            container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<ManageController>(new InjectionConstructor());
        }
    }
}
