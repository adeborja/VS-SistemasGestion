
//manuales>javascript>ultimo

window.onload = inicializaEventos;

function inicializaEventos() {

    document.getElementById("btnLlamada").addEventListener("click", llamada, false);
}

function llamada()
{
    //alert('Wola Mundo');
    var miLlamada = new XMLHttpRequest();

    //miLlamada.open("GET", "/Home/Index");
    miLlamada.open("GET", "https://angelapirestpersonas.azurewebsites.net/api/personas");

    //Mientras viene
    miLlamada.onreadystatechange = function () {

        alert(miLlamada.readyState);

        //mientras se espera a que se terminen los pasos anteriores
        if (miLlamada.readyState < 4) {
            document.getElementById("textoMostrar").innerHTML = "Cargando...";
        }
        //cuando ya han terminado
        else if (miLlamada.readyState == 4 && miLlamada.status == 200) {
            //document.getElementById("textoMostrar").innerHTML = miLlamada.responseText;

            //Continuacion
            //Pasarlo a objeto y escribir una propiedad
            var oPersona = new persona();
            var arrayPersonas = JSON.parse(miLlamada.responseText);
            oPersona = arrayPersonas[0];
            document.getElementById("textoMostrar").innerHTML = oPersona.telefono;
        }
    };

    miLlamada.send();
}

//class persona {
//    constructor(nombre, apellidos, fechaNacimiento, direccion) {
//        this.nombre = nombre;
//        this.apellidos = apellidos;
//        this.fechaNacimiento = fechaNacimiento;
//        this.direccion = direccion;
//    }
//}