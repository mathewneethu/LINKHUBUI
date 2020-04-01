using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{

    public class UniqueEmailAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            LinkHubDbEntities db = new LinkHubDbEntities();
            if(value!=null )
            {
            string userEmailvalue = value.ToString();
            int count = db.tbl_User.Where(x => x.UserEmail == userEmailvalue).ToList().Count();
            if (count != 0)

                return new ValidationResult("User Already Exist With This Email ID");
            }
            return ValidationResult.Success;

        }
    }
   public class tbl_UserValidation
    {
       [Required]
       [EmailAddress]
       [UniqueEmail]
       public string UserEmail { get; set; }

       [Required]
       public string Password { get; set; }

       [Required]
       [Compare("Password")]
       public string ConfirmPassword { get; set; }
    }
   [MetadataType(typeof(tbl_UserValidation))]
   public partial class tbl_User
   {
       public string ConfirmPassword { get; set; }
   }
}
