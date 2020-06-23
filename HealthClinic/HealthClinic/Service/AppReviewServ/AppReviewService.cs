using Model.Survey;
using Repository.AppReviewRepo;
using Repository.SurveyResponseRepo;
using System.Collections.Generic;


namespace HealthClinic.Service.AppReviewServ
{
    public class AppReviewService
    {
        public AppReviewRepositoryFactory appReviewRepositoryFactory;

        public List<AppReview> GetAllAppReviews()
        {
            AppReviewFileRepository appRepo = new AppReviewFileRepository();

            List<AppReview> appReviews = new List<AppReview>();
            appReviews = (List<AppReview>)appRepo.FindAll();

            return appReviews;
        }

        public void AddAppReviews(List<AppReview> appReviewsToSave)
        {
            AppReviewFileRepository appRepo = new AppReviewFileRepository();

            appRepo.SaveAll(appReviewsToSave);
        }

        public void AddAppReview(AppReview appReviewToSave)
        {
            AppReviewFileRepository appRepo = new AppReviewFileRepository();

            appRepo.Save(appReviewToSave);
        }
    }
}
