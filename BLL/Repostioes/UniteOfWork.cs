using BLL.Interfaces;
using BLL.Repostiory;
using DAL.ContextConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repostioes
{
    public class UniteOfWork : IUnitOfWork,IDisposable
    {
        private readonly Dbcontext _dbcontext;

   
        public IClient Client { get; set; }
        public IGallery Gallery { get; set; }
        public IHairArtist HairArtist { get; set; }
        public UniteOfWork(Dbcontext dbcontext)
        {
           
            Client = new ClientGenericRepository(dbcontext);
            Gallery = new GalleryGenericRepository(dbcontext);
            HairArtist = new HairArtistGenericRepository(dbcontext);
            _dbcontext = dbcontext;
        }

       
      
        public void Dispose()
        {
            _dbcontext.Dispose();
        }

        async Task<int> IUnitOfWork.Complete()
        {
            return await _dbcontext.SaveChangesAsync();
        }
    }
}
