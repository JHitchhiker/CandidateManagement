using CandidateManagement.Data.ReportModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.Service
{
    public interface IReportService
    {
        List<IntervieweesBySourceByMonth> IntervieweesBySourceByMonth();
        List<IntervieweesByVisaByMonth> IntervieweesByVisaByMonth();
        List<OutcomeByMonth> OutcomesByMonth();
        List<OriginByMonth> OriginsByMonth();
        List<OutcomeByOriginMonth> OutcomeByOriginMonth();
        List<InterviewOutcomeByInterviewer> OutcomeByInterviewer();
        List<InterviewOutcomeByOriginator> OutcomeByOriginator();
        List<WorkingTotalByWeek> WorkingTotalByWeek();
        List<WorkingTotalByMonth> WorkingTotalByMonth();
        List<OutcomeYTD> OutcomeYTD();
        List<InterviewerClosureRates> InterviewerOutcomes();
        List<ConversionByMonth> ConversionsByMonth();
        List<AnnualSignups> AnnualSignUps();
        List<DashboardStat> DashboardStats();
        #region Closure Rates
        List<OriginatorClosureRates> OriginatorClosures();
        List<InterviewerClosureRates> InterviewerClosures();
        List<OriginByMonth> OriginSignUpByMonth();
        #endregion
    }
}
