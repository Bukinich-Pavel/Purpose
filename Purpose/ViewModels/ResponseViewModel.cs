using Microsoft.AspNetCore.Identity;
using System.Collections;
using System.Collections.Generic;

namespace Purpose.ViewModels
{
    public class ResponseViewModel
    {
        public bool Status { get; set; }
        public UserFrontViewModel UserFront { get; set; }
        public IEnumerable<IdentityError> Errors { get; set; }
         
        public ResponseViewModel(bool status)
        {
            this.Status = status;
        }  
        public ResponseViewModel(UserFrontViewModel userFront)
        {
            Status = true;
            this.UserFront = userFront;
        }
        public ResponseViewModel(IEnumerable<IdentityError> errors)
        {
            Status = false;
            this.Errors = errors;
        }
    }
}
