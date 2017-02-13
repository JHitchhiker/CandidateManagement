using CandidateManagement.Data.Context;
using CandidateManagement.Data.ReportModels;
using System.Collections.Generic;
using System.Linq;

namespace CandidateManagement.DAL
{
    public class ReportRepository : IReportRepository
    {
        CMContext _context;

        public ReportRepository(CMContext context)
        {
            _context = context;
        }

        public List<InterviewOutcomeByInterviewer> OutcomeByInterviewer()
        {
            return _context.Database
                           .SqlQuery<InterviewOutcomeByInterviewer>("usp_REPORT_InterviewOutcomeByInterviewer")
                           .ToList();
        }
        public List<InterviewOutcomeByOriginator> OutcomeByOriginator()
        {
            return _context.Database
                           .SqlQuery<InterviewOutcomeByOriginator>("usp_REPORT_InterviewOutcomeByOriginator")
                           .ToList();
        }
        public List<IntervieweesBySourceByMonth> IntervieweesBySourceByMonth()
        {
            return _context.Database
                           .SqlQuery<IntervieweesBySourceByMonth>("usp_REPORT_InterviewsBySourceByMonth")
                           .ToList();
        }
        public List<IntervieweesByVisaByMonth> IntervieweesByVisaByMonth()
        {
            return _context.Database
                           .SqlQuery<IntervieweesByVisaByMonth>("usp_REPORT_InterviewsByVisaByMonth")
                           .ToList();
        }
        
        public List<WorkingTotalByWeek> WorkingTotalByWeek()
        {
            return _context.Database
                           .SqlQuery<WorkingTotalByWeek>("usp_REPORT_WorkingTotalByWeek")
                           .ToList();
        }
        public List<WorkingTotalByMonth> WorkingTotalByMonth()
        {
            return _context.Database
                           .SqlQuery<WorkingTotalByMonth>("usp_REPORT_WorkingTotalByMonth")
                           .ToList();
        }
      
        public List<ConversionByMonth> ConversionByMonth()
        {
            return _context.Database
                           .SqlQuery<ConversionByMonth>("usp_REPORT_ConversionByMonth")
                           .ToList();
        }
        public List<AnnualSignups> AnnualSignup()
        {
            var result = _context.Database
                           .SqlQuery<AnnualSignups>("usp_REPORT_AnnualConversions")
                           .ToList();

            return result;
        }


        #region CLOSURE RATES
        public List<OriginatorClosureRates> OriginatorClosureRates()
        {
            var result = _context.Database
                           .SqlQuery<OriginatorClosureRates>("usp_REPORT_OiginatorOutcomes")
                           .ToList();
            return result;

        }
        public List<InterviewerClosureRates> InterviewerClosureRates()
        {
            return _context.Database
                           .SqlQuery<InterviewerClosureRates>("usp_REPORT_InterviewerOutcomes")
                           .ToList();
        }

      
        public List<OutcomeByMonth> OutcomesByMonth()
        {
            return _context.Database
                           .SqlQuery<OutcomeByMonth>("usp_REPORT_OutcomeByMonth")
                           .ToList();
        }
        public List<OutcomeYTD> OutcomeYTD()
        {
            return _context.Database
                           .SqlQuery<OutcomeYTD>("usp_REPORT_OutcomeYTD")
                           .ToList();
        }
        #endregion

        #region Stats by Source
        public List<OriginByMonth> OriginsByMonth()
        {
            return _context.Database
                           .SqlQuery<OriginByMonth>("usp_REPORT_OriginByMonth")
                           .ToList();
        }
        public List<OutcomeByOriginMonth> OutcomesByOriginByMonth()
        {
            return _context.Database
                           .SqlQuery<OutcomeByOriginMonth>("usp_REPORT_OutcomeByOriginByMonth")
                           .ToList();
        }
        public List<OriginByMonth> OriginSignupByMonth()
        {
            return _context.Database
                           .SqlQuery<OriginByMonth>("usp_REPORT_OriginSignupByMonth")
                           .ToList();
        }
        #endregion

        public List<DashboardStat> DashboardMainView()
        {
            return _context.Database
                           .SqlQuery<DashboardStat>("sp_DASHBOARD_Main")
                           .ToList();
        }
        public List<OriginatorLeaver> OriginatorLeavers()
        {
            return _context.Database
                           .SqlQuery<OriginatorLeaver>("usp_REPORT_OiginatorLeavers")
                           .ToList();
        }
    }
}
