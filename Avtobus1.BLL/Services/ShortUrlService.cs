using Avtobus1.DAL.Entities;
using Avtobus1.DAL.Repositories.IRepositories;

namespace Avtobus1.BLL.Services;

public class ShortUrlService : IShortUrlService
{
    private readonly IGenericRepository<Url> _urlRepository;

    public ShortUrlService(IGenericRepository<Url> urlRepository)
    {
        _urlRepository = urlRepository;
    }

    public async Task<bool> AddUrlAsync(string longUrl)
    {
        if (longUrl == null) return false;
        
        var existingUrl = await _urlRepository.GetAsync(u => u.LongUrl == longUrl);
        if (existingUrl != null)
        {
            return false; 
        }
        
        Url url = new Url()
        {
            ShortUrl = GenerateShortUrl(),
            LongUrl = longUrl
        };

        await _urlRepository.AddAsync(url);
        return true;
    }
    public async Task<bool> UpdateUrlAsync(string shorUrl, Url model)
    {
        var url = await _urlRepository.GetAsync(v => v.ShortUrl == model.ShortUrl);
        if (url == null)
            return false;

        await _urlRepository.DeleteAsync(url);
        url.LongUrl = model.LongUrl;
        url.ShortUrl = shorUrl;
        await _urlRepository.AddAsync(url);
        return true;
    }

    public async Task<bool> DeleteUrlAsync(string shortUrl)
    {
        if (shortUrl == null) return false;

        var url = await _urlRepository.GetAsync(v => v.ShortUrl == shortUrl);
        if (url == null)
            return false;

        await _urlRepository.DeleteAsync(url);
        return true;
    }

    public string GenerateShortUrl()
    {
        return UrlEncoder.Encode();
    }

    public async Task<string?> GetFullUrlAndIncrementClicksAsync(string shortUrl)
    {
        if (shortUrl == null) return null;

        var url = await _urlRepository.GetAsync(u => u.ShortUrl == shortUrl);
        if (url != null)
        {
            url.Сlicks++;
            await _urlRepository.UpdateAsync(url);
            return url.LongUrl;
        }

        return null;
    }

    public async Task<IEnumerable<Url>> GetListUrl()
    {
        var urls = await _urlRepository.GetListAsync();
        return urls.OrderByDescending(u=>u.CreateAt);
    }

    public async Task<Url> GetUrlAsync(string shortUrl)
    {
        if (shortUrl == null) return null;

        var url = await _urlRepository.GetAsync(v => v.ShortUrl == shortUrl);
        return url;
    }
}