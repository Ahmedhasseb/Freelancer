using BLL.Interfaces;
using DAL.ContextConfiguration;
using DAL.Moduls;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repostioes
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private protected readonly Dbcontext _dbcontext;

        public GenericRepository(Dbcontext dbcontext)
        {
                _dbcontext = dbcontext;
        }
        public async Task Add(T item)
        {
           await _dbcontext.Set<T>().AddAsync(item);
            
        }

        public void Delete(T item)
        {
            _dbcontext.Set<T>().Remove(item);
           
        }

        public async Task<T> Get(int id)
        {
          return  await _dbcontext.Set<T>().FindAsync(id);
           
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            if (typeof(T) == typeof(Gallery))
            {
                return (IEnumerable<T>)await _dbcontext.Galleries.Include(e => e.HairArtist).ToListAsync();

            }
            else
            {
                return _dbcontext.Set<T>().ToList();

            }
            
        }

        public void Update(T item)
        {
            _dbcontext.Set<T>().Update(item);
           
        }
    }

}
