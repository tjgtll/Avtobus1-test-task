using Avtobus1.DAL.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace Avtobus1.DAL.Entities;
public class Url : BaseEntity
{
    [Key]
    public string ShortUrl { get; set; }
    [Required]
    [Url]
    public string LongUrl { get; set; }
    public uint Сlicks { get; set; }
}
