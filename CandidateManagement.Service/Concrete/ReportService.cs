using CandidateManagement.DAL;
using CandidateManagement.Data.ReportModels;
using System.Collections.Generic;
using System.Data.Common;

namespace CandidateManagement.Service
{
    public class ReportService : IReportService
    {
        IReportRepository _repository;
        public ReportService(IReportRepository repository)
        {
            _repository = repository;
        }
        public List<IntervieweesBySourceByMonth> IntervieweesBySourceByMonth()
        {
            return _repository.IntervieweesBySourceByMonth();
        }
        public List<IntervieweesByVisaByMonth> IntervieweesByVisaByMonth()
        {
            return _repository.IntervieweesByVisaByMonth();
        }
        public List<OutcomeByMonth> OutcomesByMonth()
        {
            return _repository.OutcomesByMonth();
        }
        public List<OriginByMonth> OriginsByMonth()
        {
            return _repository.OriginsByMonth();
        }
        public List<OriginByMonth> OriginSignUpByMonth()
        {
            return _repository.OriginSignupByMonth();
        }
        public List<OutcomeByOriginMonth> OutcomeByOriginMonth()
        {
            return _repository.OutcomesByOriginByMonth();
        }
        public List<InterviewOutcomeByInterviewer> OutcomeByInterviewer()
        {
            return _repository.OutcomeByInterviewer();
        }
        public List<InterviewOutcomeByOriginator> OutcomeByOriginator()
        {
            return _repository.OutcomeByOriginator();
        }
        public List<DashboardStat> DashboardStats()
        {
            return _repository.DashboardMainView();
        }
        public List<WorkingTotalByWeek> WorkingTotalByWeek()
        {
            return _repository.WorkingTotalByWeek();
        }
        public List<WorkingTotalByMonth> WorkingTotalByMonth()
        {
            return _repository.WorkingTotalByMonth();
        }

        public List<OutcomeYTD> OutcomeYTD()
        {
            return _repository.OutcomeYTD();
        }
        public List<InterviewerClosureRates> InterviewerOutcomes()
        {
            return _repository.InterviewerClosureRates();
        }
        public List<ConversionByMonth> ConversionsByMonth()
        {
            return _repository.ConversionByMonth();
        }
        public List<AnnualSignups> AnnualSignUps()
        {
            return _repository.AnnualSignup();
        }

        #region Closure Rates
        public List<OriginatorClosureRates> OriginatorClosures()
        {
            return _repository.OriginatorClosureRates();
        }
        public List<InterviewerClosureRates> InterviewerClosures()
        {
            return _repository.InterviewerClosureRates();
        }
        #endregion   
    }
}
