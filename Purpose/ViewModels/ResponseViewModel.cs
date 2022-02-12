using Microsoft.AspNetCore.Identity;
using System.Collections;
using System.Collections.Generic;

namespace Purpose.ViewModels
{
    public class ResponseViewModel
    {
        public bool Status { get; set; }
        public UserFrontViewModel User { get; set; }
        public List<ModelStateViewModel> Errors { get; set; }
         
        public ResponseViewModel(bool status)
        {
            this.Status = status;
        }  
        public ResponseViewModel(UserFrontViewModel userFront)
        {
            Status = true;
            this.User = userFront;
        }
        public ResponseViewModel(List<ModelStateViewModel> errors)
        {
            Status = false;
            this.Errors = errors;
        }
        public ResponseViewModel(ModelStateViewModel error)
        {
            Status = false;
            this.Errors = new List<ModelStateViewModel>();
            this.Errors.Add(error);
        }
    }
}
