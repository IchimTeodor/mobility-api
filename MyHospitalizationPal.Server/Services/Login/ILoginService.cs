using Microsoft.AspNetCore.Mvc;
using MyHospitalizationPal.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHospitalizationPal.Server.Services.Login
{
    public interface ILoginService
    {
        int Login(User user);
    }
}
