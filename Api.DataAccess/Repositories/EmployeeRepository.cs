using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.DbContext.DatabaseContext;
using Api.model.EntityModel;

namespace Api.DataAccess.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IDisposable
    {
        public static ProjectDbContext _context = new ProjectDbContext();

        public EmployeeRepository() : base(_context = new ProjectDbContext())
        {
            // Context = _context; 
        }

       

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                  

                    _context.Dispose();
                    // _context = null;
                }

               

                disposedValue = true;
            }
        }

        
        ~EmployeeRepository()
        {
           
            Dispose(true);
        }

       
        public void Dispose()
        {
           
            Dispose(true);
            
        }
        #endregion
    }
}
