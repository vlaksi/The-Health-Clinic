using HealthClinic.Service.AppReviewServ;
using Model.Survey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClinic.Controller.AppReviewContr
{
    public class AppReviewController
    {
        public AppReviewService appReviewService = new AppReviewService();

        public List<AppReview> GetAllAppReviews()
        {
            return appReviewService.GetAllAppReviews();
        }

        public void AddAppReviews(List<AppReview> appReviewsToSave)
        {
            appReviewService.AddAppReviews(appReviewsToSave);
        }

        public void AddAppReview(AppReview appReviewToSave)
        {
            appReviewService.AddAppReview(appReviewToSave);
        }
    }
}
