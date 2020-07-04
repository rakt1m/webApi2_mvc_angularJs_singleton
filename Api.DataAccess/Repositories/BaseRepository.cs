using Api.DbContext.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.DataAccess.Contracts;

namespace Api.DataAccess.Repositories
{
  public  class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private ProjectDbContext context;
        public BaseRepository(ProjectDbContext context)
        {
            this.context = context;
          
        }
        ~BaseRepository()
        {
            context = null;
        }
        public DbSet<TEntity> Set
        {
            get { return this.context.Set<TEntity>(); }


        }

        public ProjectDbContext contexts()
        {
            return this.context;
        }


        public bool Add(TEntity entity)
        {
            try
            {
                using (var _context = new ProjectDbContext())
                {
                    _context.Set<TEntity>().Add(entity);
                    var res = _context.SaveChanges();
                 
                    return res > 0;
                }

            }
            catch (DbEntityValidationException e)
            {
               
                throw e;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Update(TEntity entity)
        {
            try
            {
                using (var _context = new ProjectDbContext())
                {
                    
                    _context.Entry(entity).State = EntityState.Modified;
                    int res = _context.SaveChanges();
                    if (res > 0)
                    {
                        
                        return true;
                    }
                    return false;
                    
                }
            }
            catch (DbEntityValidationException e)
            {
              
                throw e;
            }
            catch (Exception ex)
            {
               
                throw ex;
            }
            
        }

        public TEntity Get(long id)
        {
            try
            {
                return Set.Find(id);
            }
            catch (Exception ex)
            {
               
                throw ex;
            }

        }
        public IEnumerable<TEntity> GetAll()
        {

            try
            {
                var query = context.Set<TEntity>().AsNoTracking().AsQueryable();
                return query;
               // return Set.ToList();
            }
            catch (Exception ex)
            {
               
                throw ex;
            }

        }
        public bool Remove(TEntity entity)
        {
            try
            {

                Set.Attach(entity);
                Set.Remove(entity);
                int res = context.SaveChanges();
                if (res > 0)
                {
                    
                    return true;
                }
                return false;


            }
            catch (DbEntityValidationException e)
            {
               
                throw e;
            }
            catch (Exception ex)
            {
              
                throw ex;
            }
        }

     
    }
}
