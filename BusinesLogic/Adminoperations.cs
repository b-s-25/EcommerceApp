using BusinesLogic.Interface;
using DomainLayer.Users;
using RepositoryLayer;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLogic
{
    public class Adminoperations: IAdminoperations
    {
        private readonly IGenericRepositoryOperation<Registration> _repositoryOperation;
        private readonly ProductDbContext _dbContext;
        public Adminoperations(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
            _repositoryOperation = new GenericRepositoryOperation<Registration>(_dbContext);


        }

       
        public void Add(Registration entity)
        {
          _repositoryOperation.Add(entity);
        }

        public IEnumerable<Registration> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Registration> GetUserData()
        {
            return _repositoryOperation.GetAll();
        }
    }
}
