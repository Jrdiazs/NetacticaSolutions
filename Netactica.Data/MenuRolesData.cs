using Netactica.Models;
using System;

namespace Netactica.Data
{
    public class MenuRolesData : Repository<MenuRoles>, IMenuRolesData, IDisposable
    {
        public MenuRolesData() : base()
        {
        }
    }

    public interface IMenuRolesData : IRepository<MenuRoles>, IDisposable { }
}