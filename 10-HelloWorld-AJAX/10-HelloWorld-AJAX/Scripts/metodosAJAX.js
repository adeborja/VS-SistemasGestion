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
    miLlamada.open("GET", "https://angelapirestpersonas.azurewebsites.net/api/personas/1");

    //Mientras viene
    miLlamada.onreadystatechange = function () {

        alert(miLlamada.readyState);

        //mientras se espera a que se terminen los pasos anteriores
        if (miLlamada.readyState < 4) {
            document.getElementById("textoMostrar").innerHTML = "Cargando...";
        }
        //cuando ya han terminado
        else if (miLlamada.readyState == 4 && miLlamada.status == 200) {
            document.getElementById("textoMostrar").innerHTML = miLlamada.responseText;
        }
    };

    miLlamada.send();
}