﻿function mostrarSenha() {
  var input = document.getElementById("senha");
  if (input.type === "password") {
    input.type = "text";
  } else {
    input.type = "password";
  }
}
