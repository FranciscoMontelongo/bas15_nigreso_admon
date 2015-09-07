//E.BARILLA
/*******************/
function CamposValida() {
    var Mensaje = "";
    Mensaje = Mensaje + ValidaContenido("cboEntidades", "Entidad");
    Mensaje = Mensaje + ValidaContenido("cboSubSistemas", "Subsistema");
    Mensaje = Mensaje + ValidaContenido("ddlCCT", "CCT");
    Mensaje = Mensaje + ValidaContenido("ddlCargo", "Cargo");
    Mensaje = Mensaje + ValidaContenido("cboEstatus", "Estatus");
    Mensaje = Mensaje + ValidaContenido("cboTipo", "Tipo docente");
    Mensaje = Mensaje + ValidaContenido("cboGrupo", "Tipo docente / Grupo de desempeño");
    Mensaje = Mensaje + ValidaContenido("cboAsignatura", "Asignatura");

    if (Mensaje != "") {
        alert("Debe Capturar los Campos necesarios " + "\n" + Mensaje)
        return false
    }
    else {
        return true;
    }
}
function ValidaContenido(obj, campo) {
    var Objt = document.getElementById(obj);
    if (Objt != null && typeof Objt != "undefined") {
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

    }
    Objt.style.backgroundColor = "#FFFFFF";
    return "";
}
function trimAll(sString) {
    while (sString.substring(0, 1) == ' ') {
        sString = sString.substring(1, sString.length);
    }
    while (sString.substring(sString.length - 1, sString.length) == ' ') {
        sString = sString.substring(0, sString.length - 1);
    }
    return sString;
}