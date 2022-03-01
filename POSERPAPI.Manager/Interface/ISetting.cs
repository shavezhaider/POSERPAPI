using POSERPAPI.Repository.EDMX;
using System;
using System.Collections.Generic;
using System.Text;

namespace POSERPAPI.Manager.Interface
{
   public interface ISetting
    {
        Setting GetSettingByName(string Name);
    }
}
