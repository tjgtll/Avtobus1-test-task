using Avtobus1.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace Avtobus1.Web.Controllers;

[Route("{shortUrl}")]
public class RedirectController : Controller
{
    private readonly IShortUrlService _shortUrlService;

    public RedirectController(IShortUrlService shortUrlService)
    {
        _shortUrlService = shortUrlService;
    }

    [HttpGet]
    public async Task<IActionResult> RedirectToFullUrl(string shortUrl)
    {
        var longUrl = await _shortUrlService.GetFullUrlAndIncrementClicksAsync(shortUrl);
        if (longUrl == null)
        {
            return NotFound();
        }
        return Redirect(longUrl);
    }
}
