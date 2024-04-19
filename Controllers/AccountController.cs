using AutoMapper;
using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using RefactorBEcapstone.Service;
using RefactorBEcapstone.Models;


namespace RefactorBEcapstone.Controllers
{
    [Route("api/v1/[controller]")]
    public class AccountController : BaseController
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<AccountController> _logger;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        private readonly IAccountService _accountService;

        public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, ILogger<AccountController> logger, IConfiguration config, IMapper mapper, IAccountService accountService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
            _config = config;
            _mapper = mapper;
            _accountService = accountService;
        }

        [AllowAnonymous]
        [EnableCors]
        [HttpPost("ExternalLogin")]
        public async Task<IActionResult> ExternalLogin(string provider, string? redirectUrl = null)
        {
            var responseAction = Url.Action(nameof(ExternalLoginCallback), "Account", new { redirectUrl });
            //var schemes = await _signInManager.GetExternalAuthenticationSchemesAsync();
            // Instruct the middleware corresponding to the requested external identity
            // provider to redirect the user agent to its own authorization endpoint.
            // Note: the authenticationScheme parameter must match the value configured in Startup.cs
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, responseAction);
            return Challenge(properties, provider);
        }

        [HttpGet("/auth/callback")]
        public async Task<IActionResult> ExternalLoginCallback()
        {
            try
            {
                var isNewUser = false;
                var info = await _signInManager.GetExternalLoginInfoAsync();
                if (info != null)
                {
                    // Sign in the user with this external login provider if the user already has a login.
                    var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);
                    //Get Claims
                    var emailClaim = info.Principal.FindFirst(ClaimTypes.Email);
                    var idClaim = info.Principal.FindFirst(ClaimTypes.NameIdentifier);

                    var appUser = await _userManager.FindByEmailAsync(emailClaim.Value);

                    if (appUser == null)
                    {
                        isNewUser = true;
                        appUser = new AppUser
                        {
                            UserName = emailClaim.Value,
                            Email = emailClaim.Value
                        };
                        appUser.EmailConfirmed = true;
                        var identityResult = await _userManager.CreateAsync(appUser);
                    }

                    if (!result.Succeeded && !string.IsNullOrEmpty(appUser.Email))
                    {
                        await _userManager.AddLoginAsync(appUser, info);
                    }

                    if (info.AuthenticationTokens != null)
                    {
                        await _signInManager.UpdateExternalAuthenticationTokensAsync(info);
                        await _signInManager.SignInAsync(appUser, true);
                    }

                    _logger.LogInformation("{Name} logged in with {LoginProvider} provider.", info.Principal.Identity.Name, info.LoginProvider);
                    return isNewUser
                        ? Redirect($"{_config["FrondEndBaseUrl"]}/account/setup")
                        : Redirect($"{_config["FrondEndBaseUrl"]}");

                }
                return StatusCode(500, new { errorMessage = "The authentication provider is currently down." });
            }
            catch (Exception e)
            {
                return Unauthorized(new { errorMessage = e.Message });
            }
        }
    }
}
