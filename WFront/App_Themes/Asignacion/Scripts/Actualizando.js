        function AbreVentana(dir) {
            v = window.open(dir, "", "width=750px,height=670px,scrollbars=yes");
        }
        function CierraVentana() {
            v = window.close();
        }
        function MuestraGif() {
            var objImg = document.getElementById("DivX");
            objImg.style.display = "inline";
        }
        function OcultaGif() {
            var objImg = document.getElementById("DivX");
            objImg.style.display = "none";
        }