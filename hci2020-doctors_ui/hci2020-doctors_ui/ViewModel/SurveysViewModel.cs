using Controller.SurveyResponseContr;
using Model.Survey;
using System;
using System.Collections.Generic;

namespace hci2020_doctors_ui.ViewModel
{
    class SurveysViewModel : BaseViewModel
    {
		private List<SurveyResponse> surveys;

		public List<SurveyResponse> Surveys
		{
			get { return surveys; }
			set { surveys = value; OnPropertyChanged("Surveys"); }
		}

		private SurveyResponseController surveyResponseController = new SurveyResponseController();

		public SurveysViewModel()
		{
			Surveys = new List<SurveyResponse>(surveyResponseController.GetAllSurveyResponses());
			
			
		}

	}
}
