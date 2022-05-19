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

namespace BusinesLogic
{
    public class UserOperations : IUserOperations
    {
        private readonly IGenericRepositoryOperation<Registration> _repositoryOperation;
        private readonly IGenericRepositoryOperation<ForgetPasswordView> _forgetPasswordView;
        private readonly ProductDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly IEmailService _emailService;
        public UserOperations(ProductDbContext dbContext, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration, IEmailService emailService)
        {
            _dbContext = dbContext;
            _repositoryOperation = new GenericRepositoryOperation<Registration>(_dbContext);
            _forgetPasswordView = new GenericRepositoryOperation<ForgetPasswordView>(_dbContext);
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _emailService = emailService;
        }
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
            var users =_userManager.Users.ToList();
            return users;
        }

        /*public Registration ForgetPassword(int userId)
        {
            var data = _repositoryOperation.GetAll();
            var check = data.Where(val => val.registrationId == userId).FirstOrDefault();
            return check;
        }*/

        public async Task<ApplicationUser> GetUserByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }
        public async Task GenerateForgotPasswordTokenAsync(ApplicationUser user)
        {
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            if (!string.IsNullOrEmpty(token))
            {
                await SendForgotPasswordEmail(user, token);
            }
        }
        private async Task SendForgotPasswordEmail(ApplicationUser user, string token)
        {
            string appDomain = _configuration.GetSection("Application:AppDomain").Value;
            string confirmationLink = _configuration.GetSection("Application:ForgotPassword").Value;

            UserEmail options = new UserEmail
            {
                toEmails = new List<string>() { user.Email },
                placeHolders = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("{{UserName}}", user.firstName),
                    new KeyValuePair<string, string>("{{Link}}",
                        string.Format(appDomain + confirmationLink, user.Id, token))
                }
            };
            await _emailService.SendEmailForForgotPassword(options);
        }

        public async Task<IdentityResult> ResetPasswordAsync(ResetPassword resetpassword)
        {
            return await _userManager.ResetPasswordAsync(await _userManager.FindByIdAsync(resetpassword.userId), resetpassword.token, resetpassword.newPassword);
        }
    }
}
