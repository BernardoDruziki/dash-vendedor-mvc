using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace dotnet_mvc.Models;
[Table("Users")]
[Serializable]//Permite a serialização.
public class User{
    [Column("userId")]
    [Key]
    public int userId { get; set; }
//---------------------------------------------------------
     [Column("uuId")]
    public string? uuId { get; set; }
//---------------------------------------------------------
    [Column("name")]
    [Required (ErrorMessage = "Name Required")]
    public string name { get; set; }
//---------------------------------------------------------
    [Column("companyName")] 
    [Required (ErrorMessage = "companyName Required")]
    public string companyName { get; set; }
//---------------------------------------------------------
    [Column("cpf")]
    public string? cpf { get; set; }
//---------------------------------------------------------
    [Column("cnpj")]
    public string? cnpj { get; set; }
//---------------------------------------------------------
    [Column("phoneNumber")]
    [Required (ErrorMessage = "phoneNumber Required")]
    public string phoneNumber { get; set; }
//---------------------------------------------------------
    [Column("email")] 
    [Required (ErrorMessage = "Email Required")]
    public string email { get; set; }
//---------------------------------------------------------
    [Column("password")]
    [Required (ErrorMessage = "Password Required")]
    public string password { get; set; }
//---------------------------------------------------------
    [Column("cep")]
    [Required (ErrorMessage = "cep Required")]
    public string cep { get; set; }
//---------------------------------------------------------
    [Column("uf")]
    [Required (ErrorMessage = "uf Required")]
    public string uf { get; set; }
//---------------------------------------------------------
    [Column("city")]
    [Required (ErrorMessage = "City Required")]
    public string city { get; set; }
//---------------------------------------------------------
    [Column("district")]
    [Required (ErrorMessage = "District Required")]
    public string district { get; set; }
//---------------------------------------------------------
    [Column("street")]
    [Required (ErrorMessage = "Street Required")]
    public string street { get; set; }
//---------------------------------------------------------
    [Column("number")]
    [Required (ErrorMessage = "Number Required")]
    public string number { get; set; }
//---------------------------------------------------------
    [Column("complement")]
    public string complement { get; set; }    
//---------------------------------------------------------
}

