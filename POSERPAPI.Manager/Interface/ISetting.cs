using POSERPAPI.Repository.EDMX;
using System;
using System.Collections.Generic;
using System.Text;

namespace POSERPAPI.Manager.Interface
{
    interface ISetting
    {
        Setting GetSettingByName();
    }
}
