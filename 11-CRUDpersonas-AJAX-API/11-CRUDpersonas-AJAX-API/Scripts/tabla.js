window.onload = inicializaEventos;
var posicionIdPersona = 0;
//var posicionIdDepartamento = 0;

function inicializaEventos() {
    obtenerDatos();

    //añadir eventos a los botones
    //TODO
    //document.getElementById("btnEditar").
    
    //alert('inicio');
}

function obtenerDatos() {

    var arrayPersonas;
    var arrayDepartamentos;

    var miLlamada = new XMLHttpRequest();

    miLlamada.open("GET", "https://apirestpersonasangel.azurewebsites.net/api/personas");

    //Mientras viene
    miLlamada.onreadystatechange = function () {

        if (miLlamada.readyState == 4 && miLlamada.status == 200) {
            
            arrayPersonas = JSON.parse(miLlamada.responseText);

            //generarTabla(arrayPersonas);//, arrayDepartamentos);

            var nombresDepartamento = new XMLHttpRequest();

            nombresDepartamento.open("GET", "https://apirestpersonasangel.azurewebsites.net/api/departamentos");

            nombresDepartamento.onreadystatechange = function () {
                if (nombresDepartamento.readyState == 4 && nombresDepartamento.status == 200) {
                    arrayDepartamentos = JSON.parse(nombresDepartamento.responseText);

                    generarTabla(arrayPersonas, arrayDepartamentos);
                }
            };

            nombresDepartamento.send();
        }
    };

    miLlamada.send();

    /*var nombresDepartamento = new XMLHttpRequest();

    nombresDepartamento.open("GET", "https://apirestpersonasangel.azurewebsites.net/api/departamentos");

    nombresDepartamento.onreadystatechange = function () {
        if (nombresDepartamento.readyState == 4 && nombresDepartamento.status == 200) {
            arrayDepartamentos = JSON.parse(nombresDepartamento.responseText);

            generarTabla(arrayPersonas);
        }
    };
    
    nombresDepartamento.send();*/
}


function generarTabla(arrayPersonas, arrayDepartamentos) {
    

    //Obtener referencia del elemento Body
    var body = document.getElementsByTagName("body")[0];
    //body.setAttribute("id", "tablaElementos");

    //Crea una tabla y un elemento para su cuerpo
    var tabla = document.createElement("table");
    tabla.setAttribute("id", "tablaElementos");

    //Claves del array
    var cols = 0;
    if (arrayPersonas != null && arrayPersonas.length > 0) cols = Object.keys(arrayPersonas[0]);
    else console.log("arrayPersonas no tiene elementos");

    var thead = document.createElement("thead");

    //Crea la hileras de la tabla para mostrar las claves
    var hilera = document.createElement("tr");

    for (var i = 0; i < cols.length; i++) {
        var thh = document.createElement("th");

        //var textoTh = document.createTextNode(cols[i]);

        if (cols[i] == "idDepartamento") {
            textoTh = document.createTextNode("Departamento");
            //posicionIdDepartamento = i;
        }
        else {
            textoTh = document.createTextNode(cols[i]);
        }

        thh.appendChild(textoTh);

        if (cols[i] == "idPersona") {
            thh.hidden = true;
            posicionIdPersona = i;
        }

        hilera.appendChild(thh);
        
    }

    thead.appendChild(hilera);

    tabla.appendChild(thead);



    var tbody = document.createElement("tbody");

    //Crear las filas
    for (var i = 0; i < arrayPersonas.length; i++) {

        //Crea las hileras de la tabla
        hilera = document.createElement("tr"); //Se vuelve a crear la asignacion para limpiar la configuracion anterior. Comentar esta linea para ver por qué.

        //var aux;
        //Crear las columnas
        for (var prop in arrayPersonas[0]) {
            //Crea un elemento td
            var celda = document.createElement("td");

            var textoCelda;// = document.createTextNode(arrayPersonas[i][prop]);
            //aux = arrayPersonas[i]["idDepartamento"];
            //aux = arrayDepartamentos[1]["nombreDepartamento"];


            if (prop != "idDepartamento") {
                textoCelda = document.createTextNode(arrayPersonas[i][prop]);
            }
            else {
                var aux = arrayPersonas[i]["idDepartamento"];
                textoCelda = document.createTextNode(arrayDepartamentos[aux-1]["nombreDepartamento"]);
            }

            celda.appendChild(textoCelda);

            hilera.appendChild(celda);
        }

        //alert(aux);

        hilera.cells[posicionIdPersona].hidden = true;

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

        txtBorrar.setAttribute("id", "btnBorrar");
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

    //Borrar la columna idPersona de la tabla
    /*var allRows = tabla.rows;
    for(var x = 0; x < allRows.length; x++)
    {
        allRows[x].deleteCell(posicionIdPersona);
    }*/

    body.appendChild(tabla);

    //tabla.setAttribute("border", "4");
}