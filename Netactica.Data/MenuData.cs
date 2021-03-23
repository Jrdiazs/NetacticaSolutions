using Netactica.Models;
using System;

namespace Netactica.Data
{
    public class MenuData : Repository<Menu>, IMenuData, IDisposable
    {
        public MenuData() : base()
        {
        }
    }

    public interface IMenuData : IRepository<Menu>, IDisposable { }
}