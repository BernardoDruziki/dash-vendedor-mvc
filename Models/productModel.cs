using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace dotnet_mvc.Models;


[NotMapped]
public class productViewModel
{    public int id { get; set; }
//---------------------------------------------------------
    public string uuId { get; set; }
//---------------------------------------------------------
    public string name { get; set; }
//---------------------------------------------------------
    public string category { get; set; }
//---------------------------------------------------------
    public string description { get; set; }
//---------------------------------------------------------
    public double price { get; set; }
//---------------------------------------------------------
    public double promoPrice { get; set; }
//---------------------------------------------------------
    public string image { get; set; }
}



[Table("Products")]
[Serializable]//Permite a serialização.
public class Product
{
    [Column("id")]
    [Key]
    public int id { get; set; }
//---------------------------------------------------------
    [Column("uuId")]
    public string uuId { get; set; }
//---------------------------------------------------------
    [Column("name")]
    [Display(Name="Nome do produto")]
    [Required (ErrorMessage = "Name Required")]
    public string name { get; set; }
//---------------------------------------------------------
    [Column("category")]
    [Required (ErrorMessage = "Category Required")]
    public string category { get; set; }
//---------------------------------------------------------
    [Column("description")]
    [Display(Name="Descrição")]
    [Required (ErrorMessage = "Description Required")]
    public string description { get; set; }
//---------------------------------------------------------
    [Column("price")]
    [Display(Name="Preço")]
    [Required (ErrorMessage = "Price Required")]
    public double price { get; set; }
//---------------------------------------------------------
    [Column("promoPrice")]
    public double promoPrice { get; set; }
//---------------------------------------------------------
    [Column ("image")]
    [Required (ErrorMessage = "Photo Required")]
    public string image { get; set; }
//---------------------------------------------------------
}