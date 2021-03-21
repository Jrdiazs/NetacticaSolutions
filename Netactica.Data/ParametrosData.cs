using Netactica.Models;
using System;

namespace Netactica.Data
{
    public class ParametrosData : Repository<Parametros>, IParametrosData, IDisposable
    {
        public ParametrosData() : base()
        {
        }
    }

    public interface IParametrosData : IRepository<Parametros>, IDisposable
    {
    }
}