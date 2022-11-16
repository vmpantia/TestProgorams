using App.Common.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DataAccess.Repository
{
    public class RepositoryConnection : IRepositoryConnection
    {
        private readonly AppDBContext _context;

        public RepositoryConnection()
        {
            _context = new AppDBContext();
        }

        public AppDBContext Context { get { return _context; } }
    }
}
