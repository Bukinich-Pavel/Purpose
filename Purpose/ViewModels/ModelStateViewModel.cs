namespace Purpose.ViewModels
{
    public class ModelStateViewModel
    {
        public string Field { get; set; }
        public string ValidationMessage { get; set; }

        public ModelStateViewModel(string nameError, string errorMesage)
        {
            Field = nameError;
            ValidationMessage = errorMesage;
        }
    }
}
