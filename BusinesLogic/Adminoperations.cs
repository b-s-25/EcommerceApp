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

        public Registration Authenticate(string username, string password)
        {
            Registration registration = new Registration();
            var list = _repositoryOperation.GetAll();
            var user = list.FirstOrDefault(users => users.email == username && users.password == password);

            return user;
        }

        public IEnumerable<Registration> GetUserData()
        {
            return _repositoryOperation.GetAll();
        }
    }
}
