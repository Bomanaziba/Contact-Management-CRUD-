using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagement.Domain
{
    public class AppUser : IdentityUser
    {

        //public async Task<ClaimsIdentity> GenreteUserIdentityAsync(UserManager<AppUser> manager)
        //{
        //    var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
        //    //Add custom user claims here
        //    return userIdentity;
        //}

        //public virtual UserProfile UserProfile { get; set; }
    }
    //public abstract class UserProfile
    //{
    //    [Key]
    //    public int UserProfileId { get; set; }

    //    public string FirstName { get; set; }
    //    public string LastName { get; set; }
    //    public string Email { get; set; }
    //    public string Gender { get; set; }
    //}
}
