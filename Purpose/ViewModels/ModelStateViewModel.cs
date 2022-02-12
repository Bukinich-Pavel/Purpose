namespace Purpose.ViewModels
{
    public class ModelStateViewModel
    {
        public string NameError { get; set; }
        public string ErrorMessage { get; set; }

        public ModelStateViewModel(string nameError, string errorMesage)
        {
            NameError = nameError;
            ErrorMessage = errorMesage;
        }
    }
}
