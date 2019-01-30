window.onload = inicializaEventos;

function inicializaEventos() {
    obtenerDatos();
}

function obtenerDatos() {

    var miLlamada = new XMLHttpRequest();

    miLlamada.open("GET", "/api/personajes");
    
    miLlamada.onreadystatechange = function () {

        if (miLlamada.readyState == 4 && miLlamada.status == 200) {

            var arrayPersonajes = JSON.parse(miLlamada.responseText);

            //sin terminar
        }
    };

    miLlamada.send();
}