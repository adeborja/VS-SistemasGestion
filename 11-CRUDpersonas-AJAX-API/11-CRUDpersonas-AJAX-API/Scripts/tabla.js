window.onload = inicializaEventos;
var posicionIdPersona = 0;
var arrayDepartamentos;
//var posicionIdDepartamento = 0;

function inicializaEventos() {
    obtenerDatos();
    //CrearEventosOnClickEditar();

    //añadir eventos a los botones
    //TODO
    //document.getElementById("btnEditar").
    
    //alert('inicio');
}

function obtenerDatos() {

    var arrayPersonas;
    //var arrayDepartamentos;

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

                    CrearEventosOnClickEditar();
                }
            };

            nombresDepartamento.send();
        }
    };

    miLlamada.send();

    //CrearEventosOnClickEditar();

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

function obtenerListaDepartamentos() {
    var arrayDepartamentos;
    var nombresDepartamento = new XMLHttpRequest();

    nombresDepartamento.open("GET", "https://apirestpersonasangel.azurewebsites.net/api/departamentos");

    nombresDepartamento.onreadystatechange = function () {
        if (nombresDepartamento.readyState == 4 && nombresDepartamento.status == 200) {
            arrayDepartamentos = JSON.parse(nombresDepartamento.responseText);

            return arrayDepartamentos;
        }
    };

    //nombresDepartamento.send();
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
    //tbody.set

    //Crear las filas
    for (var i = 0; i < arrayPersonas.length; i++) {

        //Crea las hileras de la tabla
        hilera = document.createElement("tr"); //Se vuelve a crear la asignacion para limpiar la configuracion anterior. Comentar esta linea para ver por qué.

        //var aux;
        //Crear las columnas
        for (var prop in arrayPersonas[0]) {
            
            //Crea un elemento td
            var celda = document.createElement("td");


            //prueba editable
            //var divv = document.createElement("div");
            //divv.contentEditable = "true";


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

            //prueba editable
            //divv.appendChild(textoCelda);
            //celda.appendChild(divv);


            hilera.appendChild(celda);
        }

        //alert(aux);

        hilera.cells[posicionIdPersona].hidden = true;

        //Añadir los botones necesarios
        var btnEditar = document.createElement("tr");
        var txtEditar = document.createElement("input");

        txtEditar.setAttribute("numerofila", i+1);
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

        txtBorrar.setAttribute("numerofila", i);
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
        txtGuardar.setAttribute("numerofila", i);
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
        txtCancelar.setAttribute("numerofila", i);
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

    /*var fila = null;

    for (i = 0; i < tbody.rows.length; i++) {
        //tbody.rows.item(i).txtEditar.click(clickEditar(this.numeroFila));
        //tbody.rows.item(i).btnEditar.addEventListener("click", clickEditar(1), false);
        //tbody.rows.item(i).getElementById("btnEditar").addEventListener("click", clickEditar(i), false);

        fila = tbody.rows.item(i);
        
        //fila.children.item(7).innerHTML = "Edittttt";
        fila.children.item(7).addEventListener("click", clickEditar(i), false);

    }*/

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

function clickEditar() {
    //'use-strick';

    /*var filaTabla = document.getElementById("tablaElementos").rows[numeroFila].cells;

    //Coger los campos de la fila
    var campos = filaTabla.getElementsByTagName('td');
    document.getElementById("demo").innerHTML = "" + campos[0].te*/

    //alert(document.getElementById("tablaElementos").rows.item(numeroFila).innerHTML);
    var numFila = this.getAttribute("numerofila");

    //alert(numFila);

    //se ah cambiado numeroFila por i+1
    //Cambia la visibilidad de los botones al hacer click en el boton de Editar
    document.getElementById("tablaElementos").rows[numFila].children.item(7).firstChild.hidden = true;
    document.getElementById("tablaElementos").rows[numFila].children.item(8).firstChild.hidden = true;
    document.getElementById("tablaElementos").rows[numFila].children.item(9).firstChild.hidden = false;
    document.getElementById("tablaElementos").rows[numFila].children.item(10).firstChild.hidden = false;


    //https://stackoverflow.com/questions/16177458/adding-a-button-with-onclick-function-via-javascript-jquery
    //https://www.w3schools.com/jsref/coll_table_rows.asp

    //alert(document.getElementById("tablaElementos").rows[numFila].children.item(3).innerHTML);

    //Cambiar td por input

    //var docFrag = document.createDocumentFragment();
    ////var input = document.createElement('input');
    ////input.value = this.textContent;
    ////this.removeChild(this.firstChild);
    ////docFrag.appendChild(input);
    ////this.appendChild(docFrag);


    var fila = document.getElementById("tablaElementos").rows[numFila];

    //editar que en vez de borrar los campos, los oculte, para volver a mostrarlos si se le da al boton cancelar
    var inputNombre = document.createElement("input");
    inputNombre.setAttribute("value", fila.children.item(1).innerHTML);
    inputNombre.setAttribute("id", "inputNombre");
    inputNombre.setAttribute("type", "text");
    fila.children.item(1).removeChild(fila.children.item(1).firstChild);
    fila.children.item(1).appendChild(inputNombre);

    var inputApellido = document.createElement("input");
    inputApellido.setAttribute("value", fila.children.item(2).innerHTML);
    inputApellido.setAttribute("id", "inputApellido");
    inputApellido.setAttribute("type", "text");
    fila.children.item(2).removeChild(fila.children.item(2).firstChild);
    fila.children.item(2).appendChild(inputApellido);

    var inputFechaNac = document.createElement("input");
    inputFechaNac.setAttribute("value", fila.children.item(3).innerHTML);
    inputFechaNac.setAttribute("id", "inputFechaNac");
    inputFechaNac.setAttribute("type", "datetime-local");
    fila.children.item(3).removeChild(fila.children.item(3).firstChild);
    fila.children.item(3).appendChild(inputFechaNac);

    var inputDireccion = document.createElement("input");
    inputDireccion.setAttribute("value", fila.children.item(4).innerHTML);
    inputDireccion.setAttribute("id", "inputDireccion");
    inputDireccion.setAttribute("type", "text");
    fila.children.item(4).removeChild(fila.children.item(4).firstChild);
    fila.children.item(4).appendChild(inputDireccion);

    var inputTelefono = document.createElement("input");
    inputTelefono.setAttribute("value", fila.children.item(5).innerHTML);
    inputTelefono.setAttribute("id", "inputTelefono");
    inputTelefono.setAttribute("type", "text");
    fila.children.item(5).removeChild(fila.children.item(5).firstChild);
    fila.children.item(5).appendChild(inputTelefono);

    //todo: lista departamentos
    //arrayNombres[i]["idDepartamento"]
    //var arrayDepartamentos = obtenerListaDepartamentos();

    var listaDepartamentos = document.createElement("select");
    listaDepartamentos.setAttribute("id", "listaDepartamentos");

    for (var i = 0; i < 4; i++)
    {
        var opcion = document.createElement("option");
        var idDep = arrayDepartamentos[i]["idDepartamento"];
        var nombre = arrayDepartamentos[i]["nombreDepartamento"];
        //opcion.setAttribute("value", idDep);
        //opcion.setAttribute("innerHTML", nombre);
        opcion.value = idDep;
        opcion.text = nombre;
        //if (fila.children.item(6).innerHTML == nombre) opcion.setAttribute("selected", "true");
        listaDepartamentos.appendChild(opcion);
    }
    fila.children.item(6).removeChild(fila.children.item(6).firstChild);
    fila.children.item(6).appendChild(listaDepartamentos);
}

function CrearEventosOnClickEditar() {
    var tabla = document.getElementById("tablaElementos");
    var fila = null;

    for (i = 1; i <= tabla.children.item(1).children.length; i++) {

        //fila = tabla.children.item(1).children.item(i);
        fila = tabla.rows[i];
        //alert(fila.children.item(7));
        fila.children.item(7).firstChild.addEventListener("click", clickEditar, false);

    }
}