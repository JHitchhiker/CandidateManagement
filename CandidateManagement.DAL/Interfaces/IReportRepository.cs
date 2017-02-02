using CandidateManagement.Data.ReportModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.DAL
{
    public interface IReportRepository
    {
        List<IntervieweesBySourceByMonth> IntervieweesBySourceByMonth();
        List<IntervieweesByVisaByMonth> IntervieweesByVisaByMonth();
       
        
        List<InterviewOutcomeByInterviewer> OutcomeByInterviewer();
        List<InterviewOutcomeByOriginator> OutcomeByOriginator();
        List<WorkingTotalByWeek> WorkingTotalByWeek();
        List<WorkingTotalByMonth> WorkingTotalByMonth();
        
       
        List<ConversionByMonth> ConversionByMonth();
        List<AnnualSignups> AnnualSignup();

        List<DashboardStat> DashboardMainView();

        #region Closure Rates
        List<OriginatorClosureRates> OriginatorClosureRates();
        List<InterviewerClosureRates> InterviewerClosureRates();
        List<OutcomeYTD> OutcomeYTD();
        List<OutcomeByMonth> OutcomesByMonth();
        #endregion

        #region Stats By Source
        List<OriginByMonth> OriginsByMonth();
        List<OutcomeByOriginMonth> OutcomesByOriginByMonth();

        List<OriginByMonth> OriginSignupByMonth();

        #endregion
    }
}
