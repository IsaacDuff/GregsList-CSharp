namespace gregslist_cSharp.Models;

public class House
{
    public int Id { get; set; }
    public int? Bathrooms { get; set; }
    public int? Bedrooms { get; set; }
    public string ImgUrl { get; set; }
    public int? Levels { get; set; }
    public int? Price { get; set; }
}