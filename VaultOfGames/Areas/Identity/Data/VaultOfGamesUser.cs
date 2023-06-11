using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace VaultOfGames.Areas.Identity.Data;

// Add profile data for application users by adding properties to the VaultOfGamesUser class
public class VaultOfGamesUser : IdentityUser
{
    [PersonalData]
    public string NickName { get; set; }

    [PersonalData]
    public string FirstName { get; set; }

    [PersonalData]
    public string LastName { get; set; }
}

