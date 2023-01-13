using dotnet_mvc.Models;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using WebApi.Models;

 namespace dotnet_mvc.Controllers
 {
     public class userController : Controller
     {
        public IActionResult namePage()//View cadastro de nome.
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> namePage([Bind("name")] nameViewModel user)
        {
            using (var pgsql = new npgsqlCon())
            if (ModelState.IsValid)
            {
                user.uuId = Guid.NewGuid().ToString(user.uuId);
                HttpContext.Session.SetString("name", user.name);
                return RedirectToAction(nameof(companyPage));
            }
            return View(user);
        }
//--------------------------------------------------------------------------------------------------------
        public IActionResult companyPage()//View cadastro do nome da empresa.
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> companyPage([Bind("companyName")] companyViewModel user)
        {
            using (var pgsql = new npgsqlCon())
            if (ModelState.IsValid)
            {
                HttpContext.Session.SetString("companyName", user.companyName);
                return RedirectToAction(nameof(documentPage));
            }
            return View(user);
        }
//----------------------------------------------------------------------------------------------------------
        public IActionResult documentPage()//View cadastro do documento.
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> documentPage([Bind("cpf, cnpj")] documnetViewModel user)
        {
            using (var pgsql = new npgsqlCon())
            if (ModelState.IsValid)
            {
                //user = pgsql.FindAsync(userId);
                //user.companyName = "nome da empresa";
                //pgsql.(user);pgsql.modify
                //pgsql.Add(user);
                //await pgsql.SaveChangesAsync();
                HttpContext.Session.SetString("cpf", user.cpf);
                return RedirectToAction(nameof(phonePage));
            }
            return View(user);
        }
//--------------------------------------------------------------------------------------------------------
        public IActionResult phonePage()//View cadastro do telefone.
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> phonePage([Bind("phoneNumber")] phoneViewModel user)
        {
            using (var pgsql = new npgsqlCon())
            if (ModelState.IsValid)
            {
                //user = pgsql.FindAsync(userId);
                //user.companyName = "nome da empresa";
                //pgsql.(user);pgsql.modify
                //pgsql.Add(user);
                //await pgsql.SaveChangesAsync();
                HttpContext.Session.SetString("phoneNumber", user.phoneNumber);
                return RedirectToAction(nameof(emailPage));
            }
            return View(user);
        }
//--------------------------------------------------------------------------------------------------------
        public IActionResult emailPage()//View cadastro do email.
        {
            return View();
        }
        [HttpPost]
            public async Task<IActionResult> emailPage([Bind("email")] emailViewModel user)
        {
            using (var pgsql = new npgsqlCon())
            if (ModelState.IsValid)
            {
                //user = pgsql.FindAsync(userId);
                //user.companyName = "nome da empresa";
                //pgsql.(user);pgsql.modify
                //pgsql.Add(user);
                //await pgsql.SaveChangesAsync();
                HttpContext.Session.SetString("email", user.email);
                return RedirectToAction(nameof(passwordPage));
            }
            return View(user);
        }
//--------------------------------------------------------------------------------------------------------

         public IActionResult passwordPage()//View cadastro da senha.
        {
            return View();
        }
            [HttpPost]
            public async Task<IActionResult> passwordPage([Bind("password")] passwordViewModel user)
        {
            using (var pgsql = new npgsqlCon())
            if (ModelState.IsValid)
            {
                //user = pgsql.FindAsync(userId);
                //user.companyName = "nome da empresa";
                //pgsql.(user);pgsql.modify
                //pgsql.Add(user);
                //await pgsql.SaveChangesAsync();
                user.password = BCrypt.Net.BCrypt.HashPassword(user.password);//Encripta a senha do usuário.
                HttpContext.Session.SetString("password", user.password);
                return RedirectToAction(nameof(cepPage));            
            }
            return View(user);
        }
//--------------------------------------------------------------------------------------------------------
        public IActionResult cepPage()//View cadastro do enfereço.
        {
            return View();
        }
        public IActionResult homePage()
        {
            return View();
        }

            [HttpPost]
            public async Task<IActionResult> cepPage([Bind("cep, state, city, district, street, number, complement")] cepViewModel user)
        {
            using (var pgsql = new npgsqlCon())
            if (ModelState.IsValid)
            {
                //user = pgsql.FindAsync(userId);
                //user.companyName = "nome da empresa";
                //pgsql.(user);pgsql.modify
                //pgsql.Add(user);
                //await pgsql.SaveChangesAsync();
                HttpContext.Session.SetString("cep", user.cep);
                await pgsql.SaveChangesAsync();
                return RedirectToAction(nameof(homePage));
            }
            return View(user);
        }
     }
 }
 //--------------------------------------------------------------------------------------------------------

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
