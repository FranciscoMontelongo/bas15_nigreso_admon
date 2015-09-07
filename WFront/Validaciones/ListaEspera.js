﻿//E.BARILLA
/*******************/
function CamposValida() {
    var Mensaje = "";
    Mensaje = Mensaje + ValidaContenido("cboEntidades", "Entidad");
    Mensaje = Mensaje + ValidaContenido("cboSubSistemas", "Subsistema");
    Mensaje = Mensaje + ValidaContenido("cblCategorias", "Categoria");
    Mensaje = Mensaje + ValidaContenido("cboAfin", "Afin");


    if (Mensaje != "") {
        alert("Debe Capturar los Campos necesarios " + "\n" + Mensaje)
        return false
    }
    else
    { return true; }
}
function ValidaContenido(obj, campo) {
    var Objt = document.getElementById(obj);

    if (Objt.value.length <= 0) {
        Objt.style.border = "thin solid #B0E2FF";
        return ("- " + campo + "\n");
    }
    if (Objt.value.length > 0) {
        if (trimAll(Objt.value) == '') {
            Objt.style.border = "thin solid #B0E2FF";
            return ("- " + campo + "\n");
        }
    }
    Objt.style.backgroundColor = "#FFFFFF";
    return "";
}
function trimAll(sString) {
    while (sString.substring(0, 1) == ' ')
    { sString = sString.substring(1, sString.length); }
    while (sString.substring(sString.length - 1, sString.length) == ' ')
    { sString = sString.substring(0, sString.length - 1); }
    return sString;
} 