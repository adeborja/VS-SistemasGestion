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

function buscarNombreDeDepartamento(arrayNombres, idBuscado) {
    var nombre = null;
    var departamentoEncontrado = false;
    for (i = 0; !departamentoEncontrado && i < arrayNombres.length; i++)
    {
        if (arrayNombres[i]["idDepartamento"] == idBuscado) {
            nombre = arrayNombres[i]["nombreDepartamento"];
            departamentoEncontrado = true;
        }
    }

    return nombre;
}


function generarTabla(arrayPersonas, arrayDepartamentos) {
    

    //Obtener referencia del elemento Body
    var body = document.getElementsByTagName("body")[0];
    //body.setAttribute("id", "tablaElementos");

    //Crea una tabla y un elemento para su cuerpo
    var tabla = document.getElementById("tablaElementos");

    //var tabla = document.createElement("table");
    //tabla.setAttribute("id", "tablaElementos");

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
                //var aux = arrayPersonas[i]["idDepartamento"]; //hacer busqueda
                //textoCelda = document.createTextNode(arrayDepartamentos[aux-1]["nombreDepartamento"]);

                var aux = arrayPersonas[i]["idDepartamento"];
                textoCelda = document.createTextNode(buscarNombreDeDepartamento(arrayDepartamentos, aux));
            }

            celda.appendChild(textoCelda);

            hilera.appendChild(celda);
        }

        //alert(aux);

        hilera.cells[posicionIdPersona].hidden = true;

        //Añadir los botones necesarios
        var btnEditar = document.createElement("tr");
        var txtEditar = document.createElement("input");

        txtEditar.setAttribute("numeroFila", i);
        txtEditar.setAttribute("id", "btnEditar");
        txtEditar.setAttribute("type", "button");
        txtEditar.setAttribute("value", "Editar");
        txtEditar.setAttribute("class", "mdl-button mdl-js-button mdl-button--raised mdl-button--colored");

        //da error porque intenta enlazar la fila cuando aun no se ha creado
        //txtEditar.click(clickEditar(i));

        btnEditar.appendChild(txtEditar);

        //btnEditar.addEventListener("click", clickEditar(i), false);

        //por completar
        hilera.appendChild(btnEditar);

        var btnBorrar = document.createElement("tr");
        var txtBorrar = document.createElement("input");

        txtBorrar.setAttribute("numeroFila", i);
        txtBorrar.setAttribute("id", "btnBorrar");
        txtBorrar.setAttribute("type", "button");
        txtBorrar.setAttribute("value", "Borrar");
        txtBorrar.setAttribute("class", "mdl-button mdl-js-button mdl-button--raised mdl-button--colored");
        btnBorrar.appendChild(txtBorrar);
        //por completar
        hilera.appendChild(btnBorrar);


        var btnGuardar = document.createElement("tr");
        var txtGuardar = document.createElement("input");

        txtGuardar.hidden = true;
        txtGuardar.setAttribute("numeroFila", i);
        txtGuardar.setAttribute("id", "btnGuardar");
        txtGuardar.setAttribute("type", "button");
        txtGuardar.setAttribute("value", "Guardar");
        txtGuardar.setAttribute("class", "mdl-button mdl-js-button mdl-button--raised mdl-button--colored");
        btnGuardar.appendChild(txtGuardar);
        //por completar
        hilera.appendChild(btnGuardar);


        var btnCancelar = document.createElement("tr");
        var txtCancelar = document.createElement("input");

        txtCancelar.hidden = true;
        txtCancelar.setAttribute("numeroFila", i);
        txtCancelar.setAttribute("id", "btnCancelar");
        txtCancelar.setAttribute("type", "button");
        txtCancelar.setAttribute("value", "Cancelar");
        txtCancelar.setAttribute("class", "mdl-button mdl-js-button mdl-button--raised mdl-button--colored");
        btnCancelar.appendChild(txtCancelar);
        //por completar
        hilera.appendChild(btnCancelar);



        //agrega la hilera al final de la tabla (final del elemento tbody)
        tbody.appendChild(hilera);

        //tbody.rows.item(i + 1).getElementById("btnEditar").addEventListener("click", clickEditar(i), false);
    }

    //evento onclick de editar

    var fila = null;

    for (i = 1; i < tbody.rows.length; i++) {
        //tbody.rows.item(i).txtEditar.click(clickEditar(this.numeroFila));
        //tbody.rows.item(i).btnEditar.addEventListener("click", clickEditar(1), false);
        //tbody.rows.item(i).getElementById("btnEditar").addEventListener("click", clickEditar(i), false);

        fila = tbody.rows.item(0);

        //fila.getElementById("btnEditar").innerHTML = "Editttttt";
        fila.children.item(0).addEventListener("click", clickEditar(i + 1), false);

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

function clickEditar(numeroFila) {
    'use-strick';

    /*var filaTabla = document.getElementById("tablaElementos").rows[numeroFila].cells;

    //Coger los campos de la fila
    var campos = filaTabla.getElementsByTagName('td');
    document.getElementById("demo").innerHTML = "" + campos[0].te*/

    //alert(document.getElementById("tablaElementos").rows.item(numeroFila).innerHTML);
    alert(45);


    //https://stackoverflow.com/questions/16177458/adding-a-button-with-onclick-function-via-javascript-jquery
    //https://www.w3schools.com/jsref/coll_table_rows.asp

}