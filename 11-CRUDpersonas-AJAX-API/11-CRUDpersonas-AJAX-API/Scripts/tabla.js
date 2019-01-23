window.onload = inicializaEventos;

function inicializaEventos() {
    obtenerDatos();
    generarTabla();
    alert('inicio');
}

function obtenerDatos() {

    //document.getElementById("textoMostrar").innerHTML = "Texto de prueba";

    var miLlamada = new XMLHttpRequest();

    //miLlamada.open("GET", "/Home/Index");
    miLlamada.open("GET", "https://apirestpersonasangel.azurewebsites.net/api/personas");

    //Mientras viene
    miLlamada.onreadystatechange = function () {

        alert(miLlamada.readyState);

        //mientras se espera a que se terminen los pasos anteriores
        if (miLlamada.readyState < 4) {
            document.getElementById("textoMostrar").innerHTML = "Cargando...";
        }
        //cuando ya han terminado
        else if (miLlamada.readyState == 4 && miLlamada.status == 200) {

            document.getElementById("textoMostrar").innerHTML = "Cargado";
            
            var arrayPersonas = JSON.parse(miLlamada.responseText);

            generarTabla(arrayPersonas);
        }
    };

    miLlamada.send();
}


function generarTabla(arrayPersonas) {

    var divTabla = document.getElementById(divTabla);

    //alert('Entrada al onreadystatechange');

    //Obtener referencia del elemento Body
    var body = document.getElementsByTagName("body")[0];

    //Crea una tabla y un elemento para su cuerpo
    var tabla = document.createElement("table");

    //Claves del array
    var cols = Object.keys(arrayPersonas[0]);

    var thead = document.createElement("thead");

    //Crea la hileras de la tabla para mostrar las claves
    var hilera = document.createElement("tr");

    for (var i = 0; i < cols.length; i++) {
        var thh = document.createElement("th");

        var textoTh = document.createTextNode(cols[i]);

        thh.appendChild(textoTh);

        hilera.appendChild(thh);
    }

    thead.appendChild(hilera);

    tabla.appendChild(thead);



    var tbody = document.createElement("tbody");

    //Crear las filas
    for (var i = 0; i < arrayPersonas.length; i++) {

        //Crea las hileras de la tabla
        //var hilera2 = document.createElement("tr");
        hilera = document.createElement("tr"); //Se vuelve a crear la asignacion para limpiar la configuracion anterior. Comentar esta linea para ver por qué.

        //Crear las columnas
        //for (var j = 0; j < 6; j++) {
        for (var prop in arrayPersonas[0]) {
            //Crea un elemento td
            var celda = document.createElement("td");

            //Crea un nodo de texto y escribe el texto que tendrá la celda
            //var textoCelda = document.createTextNode("celda " + i + "," + j);
            var textoCelda = document.createTextNode(arrayPersonas[i][prop]);

            celda.appendChild(textoCelda);
            hilera.appendChild(celda);
        }

        //Añadir los botones necesarios
        var btnEditar = document.createElement("tr");
        var txtEditar = document.createElement("input");

        txtEditar.setAttribute("id", "btnEditar");
        txtEditar.setAttribute("type", "button");
        txtEditar.setAttribute("value", "Editar");
        txtEditar.setAttribute("class", "mdl-button mdl-js-button mdl-button--raised mdl-button--colored");
        btnEditar.appendChild(txtEditar);
        //por completar
        hilera.appendChild(btnEditar);

        var btnBorrar = document.createElement("tr");
        var txtBorrar = document.createElement("input");

        txtBorrar.setAttribute("type", "button");
        txtBorrar.setAttribute("value", "Borrar");
        txtBorrar.setAttribute("class", "mdl-button mdl-js-button mdl-button--raised mdl-button--colored");
        btnBorrar.appendChild(txtBorrar);
        //por completar
        hilera.appendChild(btnBorrar);



        //agrega la hilera al final de la tabla (final del elemento tbody)
        tbody.appendChild(hilera);
    }

    //posicionar tbody debajo del elemento tabla
    tabla.appendChild(tbody);

    body.appendChild(tabla);

    tabla.setAttribute("border", "4");

    //divTabla.appendChild(body);
}