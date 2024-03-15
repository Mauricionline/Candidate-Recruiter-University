﻿const open = document.getElementById("open");
const modalcont = document.getElementById("modal-container");
const cerrar = document.getElementById("cerrar");

open.addEventListener("click", () => {
    modalcont.classList.add("show")
})

cerrar.addEventListener("click", () => {
    modalcont.classList.remove("show")
})