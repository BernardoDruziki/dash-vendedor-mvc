function mostrarSenha() {//Função para passar o field "password" para "text" e vice-versa.
  var input = document.getElementById("senha");
  if (input.type === "password") {
    input.type = "text";
  } else {
    input.type = "password";
  }
}

