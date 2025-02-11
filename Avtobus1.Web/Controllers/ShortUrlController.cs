using Avtobus1.BLL.Services;
using Avtobus1.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Avtobus1.Web.Controllers;

public class ShortUrlController : Controller
{
    private readonly IShortUrlService _shortUrlService;
    public ShortUrlController(IShortUrlService shortUrlService)
    {
        _shortUrlService = shortUrlService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var result = await _shortUrlService.GetListUrl();

        return View(result);
    }

    [HttpGet("Create")]
    public IActionResult Create() => View();

    [HttpPost("Create")]
    public async Task<IActionResult> Create(string longUrl)
    {
        var response = await _shortUrlService.AddUrlAsync(longUrl);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet("Edit")]
    public async Task<IActionResult> Edit(string shortUrl)
    {
        var url = await _shortUrlService.GetUrlAsync(shortUrl);
        if (url == null) return NotFound();

        return View(url);
    }

    [HttpPost("Edit")]
    public async Task<IActionResult> Edit(string newShortUrl, Url url)
    {
        if (ModelState.IsValid)
        {
            await _shortUrlService.UpdateUrlAsync(newShortUrl, url);
            return RedirectToAction(nameof(Index));
        }
        return View(url);
    }

    [HttpPost("Delete/{shortUrl}")]
    public async Task<IActionResult> Delete(string shortUrl)
    {
        var success = await _shortUrlService.DeleteUrlAsync(shortUrl);
        if (!success) return NotFound();

        return Json(new { success = true });
    }

    [HttpPost("GenerateShortUrl")]
    public async Task<IActionResult> GenerateShortUrl(string longUrl)
    {
        var shortUrl = _shortUrlService.GenerateShortUrl();
        return Json(new { shortUrl });
    }

}
