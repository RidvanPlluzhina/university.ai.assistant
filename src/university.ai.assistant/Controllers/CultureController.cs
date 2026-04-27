namespace university.ai.assistant.Controllers;

using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

public class CultureController : Controller
{
    [HttpGet]
    [Route("set-culture")]
    public IActionResult SetCulture(string culture, string redirectUri)
    {
        if (!string.IsNullOrEmpty(culture))
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(
                    new RequestCulture(culture)
                ),
                new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddYears(1)
                }
            );
        }

        if (string.IsNullOrWhiteSpace(redirectUri))
            redirectUri = "/";

        return LocalRedirect(redirectUri);
    }
}
