using dotnet_mvc.Models;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Validator;
using WebApi.Models;

 namespace dotnet_mvc.Controllers
 {
     public class userController : Controller
     {

        public IActionResult namePage()//View cadastro de nome.
        {
            return View();
        }

        public IActionResult companyPage()//View cadastro do nome da empresa.
        {
            return View();
        }

        public IActionResult documentPage()//View cadastro do documento.
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult saveUser(User user)
        {
            using (var pgsql = new npgsqlCon())//Utilizar o banco de dados.
            if (ModelState.IsValid)
            {
                pgsql.Users.Add(user);
                pgsql.SaveChanges();
                return RedirectToAction("Index");
            }
            return Redirect("/Home/Index");
        }
    }
}
        //SALVAR USUÁRIO 
        // [HttpPost]
        // public static async Task<string> SaveUser([FromBody]User user)
        // {
        //     string response = "";
        //     userValidator validator = new userValidator();
        //     ValidationResult result = validator.Validate(user);//Faz a validação do usuário.
        //     string message = result.ToString();
        //     if (!result.IsValid)
        //     {
        //         return message;
        //     }
        //     else
        //     {
        //         using (var pgsql = new npgsqlCon())//Utilizar o banco de dados.
        //         {
        //             try
        //             {
        //                 List<User> IsEmailValid = pgsql.Users.Where(x => x.email == user.email).ToList();//Verifica se o email já existe no banco.                                                    
        //                 if (IsEmailValid.Count == 0)
        //                 {//Persiste o usuário, caso ele não esteja na base.
        //                     List<User> IsDocumentValid = pgsql.Users.Where(x => x.cpf == user.cpf).Where(x => x.cnpj == user.cnpj).ToList();//Verifica se os documentos já existem no banco.
        //                     if (IsDocumentValid.Count == 0)
        //                     {
        //                         user.uuId = Guid.NewGuid().ToString(user.uuId);//Gera o uuId do usuário.
        //                         user.password = BCrypt.Net.BCrypt.HashPassword(user.password);//Encripta a senha do usuário.
        //                         user.email = user.email.ToString().ToLower();//Salva o email no banco em lower case.
        //                         pgsql.Users.Add(user);
        //                         await pgsql.SaveChangesAsync();
        //                         message = "OK";//Usuário salvo com sucesso.
        //                         response = JsonSerializer.Serialize(new { user.userId, user.uuId, message });//Retorno para o front.
        //                     }
        //                     else
        //                     {
        //                         message = "DOCUMENT_EXISTS";//Cpf ou Cnpj já existente no banco.
        //                         response = JsonSerializer.Serialize(new { message });
        //                     }
        //                 }
        //                 else
        //                 {
        //                     message = "EMAIL_EXISTS";//Email já existente no banco.
        //                     response = JsonSerializer.Serialize(new { message });
        //                 }
        //             }
        //             catch (Exception e)
        //             {
        //                 Console.WriteLine(e.ToString());
        //             }
        //             return response;
        //         }
        //     }
        // }

        //EDITAR USUÁRIO 
//         [HttpPut("/edituser/{Id}")]
//         public static async Task<String> EditUser([FromBody] User user)//Passar o id e uuId para edição.
//         {
//             string response = "";
//             string message = response.ToString();
//             using (var pgsql = new npgsqlCon())
//             {
//                 try
//                 {
//                     var users = new User();
//                     pgsql.Users.Update(user);//Edita um usuário existente no bacno.
//                     await pgsql.SaveChangesAsync();
//                     message = "OK";//Usuário editado com sucesso.
//                     response = JsonSerializer.Serialize(new { message });
//                 }
//                 catch (Exception e)
//                 {
//                     message = "USER_NOT_FOUND";//Usuário não encontrado.
//                     response = JsonSerializer.Serialize(new { message });
//                 }
//             }
//             return response;
//         }

//         //DELETAR USUÁRIO
//         [HttpDelete("/deleteuser/{Id}")]
//         public static async Task<string> DeleteUser([FromRoute] int Id)//Passar o id para deletar.
//         {
//             string response = "";
//             string message = response.ToString();
//             using (var pgsql = new npgsqlCon())
//             {
//                 try
//                 {
//                     User user = pgsql.Users.Find(Id);//Acha o usário pelo Id no banco.
//                     pgsql.Users.Remove(user);//Deleta o usuário do banco.
//                     pgsql.SaveChanges();
//                     message = "OK";//Usuário deletado com sucesso.
//                     response = JsonSerializer.Serialize(new { message });
//                 }
//                 catch (Exception e)
//                 {
//                     message = "USER_NOT_FOUND";//Usuário não encontrado.
//                     response = JsonSerializer.Serialize(new { message });
//                 }
//             }
//             return response;
//         }
//     }
// }
