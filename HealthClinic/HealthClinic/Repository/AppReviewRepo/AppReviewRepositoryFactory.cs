using System;

namespace Repository.AppReviewRepo
{
   public interface AppReviewRepositoryFactory
    {
        AppReviewRepository CreateAppReviewRepository();
   
   }
}