using Netactica.Models;
using System;
using System.Data;

namespace Netactica.Data
{
    public class UsuarioInfoData : Repository<UsuarioInfo>, IUsuarioInfoData, IDisposable
    {
        public UsuarioInfoData() : base()
        {
        }
        public UsuarioInfoData(IDbConnection connection) : base(connection)
        {
        }
    }

    public interface IUsuarioInfoData : IRepository<UsuarioInfo>, IDisposable { }
}