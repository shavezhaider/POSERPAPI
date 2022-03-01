using Microsoft.EntityFrameworkCore;
using POSERPAPI.Manager.Interface;
using POSERPAPI.Repository.EDMX;
using POSERPAPI.Repository.Interface;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace POSERPAPI.Manager.Implementation
{
    public class SettingManager : ISetting
    {
        private IBaseRepository<Setting> _settingRepo;
        private readonly DbContext _dbContext;
        public SettingManager(IServiceProvider serviceProvider, DbContext dbContext)
        {
            _dbContext = dbContext;
            ResolveRepository(serviceProvider);
        }
        public Setting GetSettingByName(string Name)
        {
            //  _settingRepo.GetByIdAsync
            var result = _settingRepo.FirstOrDefaultAsync(x => x.Name == Name).Result;
            return result;
            // throw new NotImplementedException();
        }

        private void ResolveRepository(IServiceProvider serviceProvider)
        {
            _settingRepo = serviceProvider.GetService<IBaseRepository<Setting>>();
        }

    }
}
