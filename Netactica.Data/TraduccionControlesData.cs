using Netactica.Models;
using System;

namespace Netactica.Data
{
    public class TraduccionControlesData : Repository<TraduccionControles>, ITraduccionControlesData, IDisposable
    {
        public TraduccionControlesData() : base()
        {
        }
    }

    public interface ITraduccionControlesData : IRepository<TraduccionControles>, IDisposable
    {
    }
}