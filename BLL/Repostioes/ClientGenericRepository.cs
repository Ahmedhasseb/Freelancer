using BLL.Interfaces;
using BLL.Repostioes;
using DAL;
using DAL.ContextConfiguration;
using DAL.Moduls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repostiory
{
    public class ClientGenericRepository: GenericRepository<Client>,IClient
    {
       

        public ClientGenericRepository(Dbcontext context):base(context) { }
       
    }
}
