using DomainLayer.Users;
using RepositoryLayer.Interface;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinesLogic.Interface;
using Microsoft.AspNetCore.Identity;
using DomainLayer;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using DomainLayer.DTO;
using Microsoft.Extensions.Options;
using DomainLayer.MasterData;

namespace BusinesLogic
{
    public class UserOperations /*: *//*IUserOperations*/
    {
        private readonly IGenericRepositoryOperation<Registration> _repositoryOperation;
        //private readonly IGenericRepositoryOperation<ForgetPasswordView> _forgetPasswordView;
        private readonly ProductDbContext _dbContext;

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly IGenericRepositoryOperation<MasterData> _repo;
        public UserOperations(ProductDbContext dbContext, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration, IGenericRepositoryOperation<MasterData> repo)
        {
            _dbContext = dbContext;
            _repositoryOperation = new GenericRepositoryOperation<Registration>(_dbContext);
            //_forgetPasswordView = new GenericRepositoryOperation<ForgetPasswordView>(_dbContext);
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _repo=new GenericRepositoryOperation<MasterData>(_dbContext);

        }
        //public async Task<IdentityResult> Register(Registration register)
        ////public async Task<bool> Register(Registration register)
        //{
        //    var user = new ApplicationUser()
        //    {
        //        firstName = register.firstName,
        //        lastName = register.lastName,
        //        Email = register.email,
        //        UserName = register.email,
        //        isActive = register.isActive,
        //        createdOn = DateTime.UtcNow,
        //        createdBy = register.firstName + register.lastName,
        //        modifiedOn = DateTime.UtcNow,
        //        modifiedBy = register.firstName + register.lastName
        //    };
        //    return await _userManager.CreateAsync(user, register.password);
        //    //try
        //    //{
        //    //    _repositoryOperation.Add(register);
        //    //    return true;
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    return false;
        //    //}
        //}

        public async Task<Registration> Authenticate(string username, string password)
        {
            Registration registration = new Registration();
            var list = _repositoryOperation.GetAll();
            var user = list.FirstOrDefault(users => users.email == username && users.password == password);

            return user;
        }

        public async Task Edit(Registration user)
        {
            _repositoryOperation.Update(user);
            _repositoryOperation.Save();
        }

        public async Task<string> Userlogin(Login login)
        {
            var result = await _signInManager.PasswordSignInAsync(login.username, login.password, false, false);
            if (!result.Succeeded)
            {
                return null;
            }
            var authclaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, login.username),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };
            var authSignInKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]));
            var token = new JwtSecurityToken
            (
            issuer: _configuration["JWT:ValidIssuer"],
            audience: _configuration["JWT:ValidAudience"],
            expires: DateTime.Now.AddHours(3),
            claims: authclaims,
            signingCredentials: new SigningCredentials(authSignInKey, SecurityAlgorithms.HmacSha256Signature)
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<List<ApplicationUser>> GetUser()
        {
            //return _repositoryOperation.GetAll();
            var users = _userManager.Users.ToList();
            return users;
        }

        public Registration ForgetPassword(int userId)
        {
            var data = _repositoryOperation.GetAll();
            var check = data.Where(val => val.registrationId == userId).FirstOrDefault();
            return check;
        }

        /*public async Task GenerateForgetPasswordToken(ApplicationUser user)
        {
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            if (!string.IsNullOrEmpty(token))
            {
                await SendForgetPasswordEmail(user, token);
            }
        }*/

        /*public async Task SendForgetPasswordEmail(ApplicationUser user, string token)
        {
            string appDomain = _configuration.GetSection("Application:AppDomain").Value;
            string confirmationLink = _configuration.GetSection("Application:EmailConfirmation").Value;
            UserEmail email = new UserEmail()
            {
                ToEmails = new List<string>() { user.Email },
                PlaceHolders = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("{{UserName}}", user.firstName),
                    new KeyValuePair<string, string>("{{Link}}",
                        string.Format(appDomain + confirmationLink, user.Id, token))
                }
            };
            await _emailService.SendEmailForForgotPassword(options);
        }*/




        //MASTERDATA OPERATIONS

        //public async Task MasterDataAdd(MasterData data)
        //{
        //   _repo.Add(data);
        //    _repo.Save();
        //}

        //public async Task MasterDataDelete(MasterData entity)
        //{
        //    _repo.Delete(entity);
        //    _repo.Save();
        //}

        //public IEnumerable<MasterData> GetAllMasterData()
        //{
        //    return _repo.GetAll();
        //}

        //public async Task MasterDataEdit(MasterData entity)
        //{
        //    _repo.Update(entity);
        //    _repo.Save();
        //}

        //public MasterData MasterDataGetById(int Id)
        //{
        //    return _repo.GetById(Id);
        //}

        //Task<IdentityResult> IUserOperations.Register(Registration register)
        //{
        //    throw new NotImplementedException();
        //}

        //Task<Registration> IUserOperations.Authenticate(string username, string password)
        //{
        //    throw new NotImplementedException();
        //}

        //Task IUserOperations.Edit(Registration user)
        //{
        //    throw new NotImplementedException();
        //}

        //Task<string> IUserOperations.Userlogin(Login login)
        //{
        //    throw new NotImplementedException();
        //}

        //Task<List<ApplicationUser>> IUserOperations.GetUser()
        //{
        //    throw new NotImplementedException();
        //}

        //Task IUserOperations.MasterDataAdd(MasterData data)
        //{
        //    throw new NotImplementedException();
        //}

        //Task IUserOperations.MasterDataDelete(MasterData entity)
        //{
        //    throw new NotImplementedException();
        //}

        //Task<IEnumerable<MasterData>> IUserOperations.GetAllMasterData()
        //{
        //    throw new NotImplementedException();
        //}

        //Task IUserOperations.MasterDataEdit(MasterData entity)
        //{
        //    throw new NotImplementedException();
        //}

        //MasterData IUserOperations.MasterDataGetById(int Id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
