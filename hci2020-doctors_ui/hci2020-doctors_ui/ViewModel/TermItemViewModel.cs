
namespace hci2020_doctors_ui.ViewModel
{
    public class TermItemViewModel //: BaseViewModel
    {
        public string Name { get; set; }
        public string Doctor { get; set; }
        public string Patient { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Room { get; set; }
        public string TypeOfTerm { get; set; }  //Cardiac, general etc.
        public string Color { get; set; } //to be converted 
    }
}
