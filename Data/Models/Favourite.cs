using System.ComponentModel.DataAnnotations;

namespace BooksStore.Data.Models;

public class Favourite
{
    [Key]
    public int Id { get; set; }
    public IEnumerable<Book> Books { get; set; } = new List<Book>();
}