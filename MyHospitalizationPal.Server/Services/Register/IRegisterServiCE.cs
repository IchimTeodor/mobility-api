using MyHospitalizationPal.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHospitalizationPal.Server.Services.Register
{
    public interface IRegisterService
    {
        AccountInfoDetails GetDetails(string uniqueCodeId);

        int Register(UserAdditional user);
        bool CheckUnicode(string uniqueCodeId);
    }
}
