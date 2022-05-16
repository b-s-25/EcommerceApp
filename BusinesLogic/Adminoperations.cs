using BusinesLogic.Interface;
using DomainLayer;
using DomainLayer.MasterData;
using DomainLayer.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
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
        //private readonly IGenericRepositoryOperation<ForgetPasswordView> _forgetPasswordView;
        private readonly ProductDbContext _dbContext;

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly IGenericRepositoryOperation<MasterData> _repo;
        public Adminoperations(ProductDbContext dbContext, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration, IGenericRepositoryOperation<MasterData> repo)
        {
            _dbContext = dbContext;
            _repositoryOperation = new GenericRepositoryOperation<Registration>(_dbContext);
            //_forgetPasswordView = new GenericRepositoryOperation<ForgetPasswordView>(_dbContext);
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _repo = new GenericRepositoryOperation<MasterData>(_dbContext);

        }



        //private readonly IGenericRepositoryOperation<Registration> _repositoryOperation;
        //private readonly ProductDbContext _dbContext;
        //public Adminoperations(ProductDbContext dbContext)
        //{
        //    _dbContext = dbContext;
        //    _repositoryOperation = new GenericRepositoryOperation<Registration>(_dbContext);


        //}


        //public void Add(Registration entity)
        //{
        //    _repositoryOperation.Add(entity);
        //}

        //public Registration Authenticate(string username, string password)
        //{
        //    Registration registration = new Registration();
        //    var list = _repositoryOperation.GetAll();
        //    var user = list.FirstOrDefault(users => users.email == username && users.password == password);

        //    return user;
        //}

        //public IEnumerable<Registration> GetUserData()
        //{
        //    return _repositoryOperation.GetAll();
        //}
        public async Task<IdentityResult> Register(Registration register)
        //public async Task<bool> Register(Registration register)
        {
            var user = new ApplicationUser()
            {
                firstName = register.firstName,
                lastName = register.lastName,
                Email = register.email,
                UserName = register.email,
                isActive = register.isActive,
                createdOn = DateTime.UtcNow,
                createdBy = register.firstName + register.lastName,
                modifiedOn = DateTime.UtcNow,
                modifiedBy = register.firstName + register.lastName
            };
            return await _userManager.CreateAsync(user, register.password);
            //try
            //{
            //    _repositoryOperation.Add(register);
            //    return true;
            //}
            //catch (Exception ex)
            //{
            //    return false;
            //}
        }

    }
}
