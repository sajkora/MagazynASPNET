using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Magazyn.Areas.Identity.Data;

// Add profile data for application users by adding properties to the MagazynUser class
public class MagazynUser : IdentityUser
{
    
    public string Imie {  get; set; }

   
    public string Nazwisko { get; set; }

}

