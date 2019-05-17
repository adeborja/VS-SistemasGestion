window.onload = inicializaEventos;
var posicionIdPersona = 0;
var arrayDepartamentos;
//var posicionIdDepartamento = 0;
var lineaEditar = 1;
var urlPersonas = "https://apirestpersonasangel.azurewebsites.net/api/personas";
var urlDepartamentos = "https://apirestpersonasangel.azurewebsites.net/api/departamentos";

function inicializaEventos() {
    obtenerDatos();
}


function obtenerDatos() {
    
    var arrayPersonas;
    //var arrayDepartamentos;

    var miLlamada = new XMLHttpRequest();

    miLlamada.open("GET", urlPersonas);

    //Mientras viene
    miLlamada.onreadystatechange = function () {

        if (miLlamada.readyState == 4 && miLlamada.status == 200) {
            
            arrayPersonas = JSON.parse(miLlamada.responseText);

            //generarTabla(arrayPersonas);//, arrayDepartamentos);

            var nombresDepartamento = new XMLHttpRequest();

            nombresDepartamento.open("GET", urlDepartamentos);

            nombresDepartamento.onreadystatechange = function () {
                if (nombresDepartamento.readyState == 4 && nombresDepartamento.status == 200) {
                    arrayDepartamentos = JSON.parse(nombresDepartamento.responseText);

                    generarTabla(arrayPersonas, arrayDepartamentos);

                    CrearEventosOnClickEditar();

                    CrearEventosOnClickCancelar();

                    CrearEventosOnClickGuardar();

                    generarTablaNuevaPersona(arrayPersonas, arrayDepartamentos);
                    
                    botonesNuevaPersona();
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

    //Crea una tabla y un elemento para su cuerpo
    var tabla = document.getElementById("tablaElementos");
    

    //Claves del array
    var cols = 0;
    if (arrayPersonas != null && arrayPersonas.length > 0) cols = Object.keys(arrayPersonas[0]);
    else console.log("arrayPersonas no tiene elementos");

    var thead = document.createElement("thead");

    //Crea la hileras de la tabla para mostrar las claves
    var hilera = document.createElement("tr");

    for (var i = 0; i < cols.length; i++) {
        var thh = document.createElement("th");
        

        if (cols[i] == "idDepartamento") {
            textoTh = document.createTextNode("Departamento");
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
        
        //Crear las columnas
        for (var prop in arrayPersonas[0]) {
            
            //Crea un elemento td
            var celda = document.createElement("td");

            //Crear aqui un elemento y que texto celda sea hija
            var itemCelda = document.createElement("p");

            var textoCelda;
            

            switch (prop) {
                case "idPersona":

                    itemCelda.setAttribute("id", "idPersona" + (i + 1));

                    textoCelda = document.createTextNode(arrayPersonas[i][prop]);
                    //textoCelda.setAttribute("id", "idPersona");

                    break;

                case "nombre":

                    itemCelda.setAttribute("id", "nombre" + (i+1));
                    
                    textoCelda = document.createTextNode(arrayPersonas[i][prop]);
                    //textoCelda.setAttribute("id", "nombre");

                    break;

                case "apellidos":

                    itemCelda.setAttribute("id", "apellidos" + (i + 1));
                    
                    textoCelda = document.createTextNode(arrayPersonas[i][prop]);
                    //textoCelda.setAttribute("id", "apellidos");

                    break;

                case "fechaNacimiento":

                    itemCelda.setAttribute("id", "fechaNacimiento" + (i + 1));
                    
                    textoCelda = document.createTextNode(arrayPersonas[i][prop]);
                    //textoCelda.setAttribute("id", "fechaNacimiento");

                    break;

                case "direccion":

                    itemCelda.setAttribute("id", "direccion" + (i + 1));
                    
                    textoCelda = document.createTextNode(arrayPersonas[i][prop]);
                    //textoCelda.setAttribute("id", "direccion");

                    break;

                case "telefono":

                    itemCelda.setAttribute("id", "telefono" + (i + 1));
                    
                    textoCelda = document.createTextNode(arrayPersonas[i][prop]);
                    //textoCelda.setAttribute("id", "telefono");

                    break;

                case "idDepartamento":

                    itemCelda.setAttribute("id", "nombreDepartamento" + (i + 1));
                    
                    var aux = arrayPersonas[i]["idDepartamento"];
                    textoCelda = document.createTextNode(buscarNombreDeDepartamento(arrayDepartamentos, aux));
                    //textoCelda.setAttribute("id", "nombreDepartamento");

                    break;

                default:
                    itemCelda.setAttribute("id", "default" + (i + 1));
                    textoCelda = document.createTextNode(arrayPersonas[i][prop]);
                    break;
            }

            itemCelda.appendChild(textoCelda);

            celda.appendChild(itemCelda);


            hilera.appendChild(celda);
        }
        

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
        
        hilera.appendChild(btnEditar);

        var btnBorrar = document.createElement("tr");
        var txtBorrar = document.createElement("input");

        txtBorrar.setAttribute("numerofila", i + 1);
        txtBorrar.setAttribute("id", "btnBorrar");
        txtBorrar.setAttribute("type", "button");
        txtBorrar.setAttribute("value", "Borrar");
        txtBorrar.setAttribute("class", "mdl-button mdl-js-button mdl-button--raised mdl-button--colored");
        btnBorrar.appendChild(txtBorrar);
        hilera.appendChild(btnBorrar);


        var btnGuardar = document.createElement("tr");
        var txtGuardar = document.createElement("input");

        txtGuardar.hidden = true;
        txtGuardar.setAttribute("numerofila", i + 1);
        txtGuardar.setAttribute("id", "btnGuardar");
        txtGuardar.setAttribute("type", "button");
        txtGuardar.setAttribute("value", "Guardar");
        txtGuardar.setAttribute("class", "mdl-button mdl-js-button mdl-button--raised mdl-button--colored");
        btnGuardar.appendChild(txtGuardar);
        hilera.appendChild(btnGuardar);


        var btnCancelar = document.createElement("tr");
        var txtCancelar = document.createElement("input");

        txtCancelar.hidden = true;
        txtCancelar.setAttribute("numerofila", i + 1);
        txtCancelar.setAttribute("id", "btnCancelar");
        txtCancelar.setAttribute("type", "button");
        txtCancelar.setAttribute("value", "Cancelar");
        txtCancelar.setAttribute("class", "mdl-button mdl-js-button mdl-button--raised mdl-button--colored");
        btnCancelar.appendChild(txtCancelar);
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
    var numeroFila = this.getAttribute("numerofila");

    //alert(numFila);

    //se ha cambiado numeroFila por i+1
    //Cambia la visibilidad de los botones al hacer click en el boton de Editar
    document.getElementById("tablaElementos").rows[numeroFila].children.item(7).firstChild.hidden = true;
    document.getElementById("tablaElementos").rows[numeroFila].children.item(8).firstChild.hidden = true;
    document.getElementById("tablaElementos").rows[numeroFila].children.item(9).firstChild.hidden = false;
    document.getElementById("tablaElementos").rows[numeroFila].children.item(10).firstChild.hidden = false;


    //https://stackoverflow.com/questions/16177458/adding-a-button-with-onclick-function-via-javascript-jquery
    //https://www.w3schools.com/jsref/coll_table_rows.asp


    var fila = document.getElementById("tablaElementos").rows[numeroFila];

    //editar que en vez de borrar los campos, los oculte, para volver a mostrarlos si se le da al boton cancelar
    var inputNombre = document.createElement("input");
    inputNombre.setAttribute("value", fila.children.item(1).firstChild.innerHTML);
    inputNombre.setAttribute("id", "inputNombre" + numeroFila);
    inputNombre.setAttribute("type", "text");

    //Para borrar el elemento anterior
    //fila.children.item(1).removeChild(fila.children.item(1).firstChild);

    //Para ocultar el elemento anterior
    fila.children.item(1).firstChild.hidden = true;

    fila.children.item(1).appendChild(inputNombre);


    var inputApellido = document.createElement("input");
    inputApellido.setAttribute("value", fila.children.item(2).firstChild.innerHTML);
    inputApellido.setAttribute("id", "inputApellido" + numeroFila);
    inputApellido.setAttribute("type", "text");
    //Para ocultar el elemento anterior
    fila.children.item(2).firstChild.hidden = true;
    fila.children.item(2).appendChild(inputApellido);

    var inputFechaNac = document.createElement("input");
    inputFechaNac.setAttribute("value", fila.children.item(3).firstChild.innerHTML);
    inputFechaNac.setAttribute("id", "inputFechaNac" + numeroFila);
    inputFechaNac.setAttribute("type", "datetime-local");
    //Para ocultar el elemento anterior
    fila.children.item(3).firstChild.hidden = true;
    fila.children.item(3).appendChild(inputFechaNac);

    var inputDireccion = document.createElement("input");
    inputDireccion.setAttribute("value", fila.children.item(4).firstChild.innerHTML);
    inputDireccion.setAttribute("id", "inputDireccion" + numeroFila);
    inputDireccion.setAttribute("type", "text");
    //Para ocultar el elemento anterior
    fila.children.item(4).firstChild.hidden = true;
    fila.children.item(4).appendChild(inputDireccion);

    var inputTelefono = document.createElement("input");
    inputTelefono.setAttribute("value", fila.children.item(5).firstChild.innerHTML);
    inputTelefono.setAttribute("id", "inputTelefono" + numeroFila);
    inputTelefono.setAttribute("type", "text");
    //Para ocultar el elemento anterior
    fila.children.item(5).firstChild.hidden = true;
    fila.children.item(5).appendChild(inputTelefono);
    
    var listaDepartamentos = document.createElement("select");
    listaDepartamentos.setAttribute("id", "listaDepartamentos" + numeroFila);

    for (var i = 0; i < arrayDepartamentos.length; i++)
    {
        var opcion = document.createElement("option");
        var idDep = arrayDepartamentos[i]["idDepartamento"];
        var nombre = arrayDepartamentos[i]["nombreDepartamento"];

        opcion.value = idDep;
        opcion.text = nombre;

        listaDepartamentos.appendChild(opcion);
    }
    //Para ocultar el elemento anterior
    fila.children.item(6).firstChild.hidden = true;
    fila.children.item(6).appendChild(listaDepartamentos);

    lineaEditar++;
}

function CrearEventosOnClickEditar() {
    var tabla = document.getElementById("tablaElementos");
    var fila = null;

    for (i = 1; i <= tabla.children.item(1).children.length; i++) {
        
        fila = tabla.rows[i];
        //var numeroFila = fila.children.item(7).firstChild.numeroFila;
        fila.children.item(7).firstChild.addEventListener("click", clickEditar, false);

    }
}


function clickCancelar() {
    var numeroFila = this.getAttribute("numerofila");

    var fila = document.getElementById("tablaElementos").rows[numeroFila];

    for (index = 1; index < 7; index++)
    {
        var item;// = document.getElementById("inputNombre" + numeroFila2);

        switch (index) {
            case 1:
                item = document.getElementById("inputNombre" + numeroFila);
                break;
            case 2:
                item = document.getElementById("inputApellido" + numeroFila);
                break;
            case 3:
                item = document.getElementById("inputFechaNac" + numeroFila);
                break;
            case 4:
                item = document.getElementById("inputDireccion" + numeroFila);
                break;
            case 5:
                item = document.getElementById("inputTelefono" + numeroFila);
                break;
            case 6:
                item = document.getElementById("listaDepartamentos" + numeroFila);
                break;
        }

        fila.children.item(index).firstChild.hidden = false;

        item.parentNode.removeChild(item);
    }

    //Visibilidad de botones
    fila.children.item(7).firstChild.hidden = false;
    fila.children.item(8).firstChild.hidden = false;
    fila.children.item(9).firstChild.hidden = true;
    fila.children.item(10).firstChild.hidden = true;
}


function CrearEventosOnClickCancelar() {
    var tabla = document.getElementById("tablaElementos");
    var fila = null;

    for (i = 1; i <= tabla.children.item(1).children.length; i++) {

        fila = tabla.rows[i];
        fila.children.item(10).firstChild.addEventListener("click", clickCancelar, false);

    }
}


function clickGuardar() {
    var numeroFila = this.getAttribute("numerofila");

    var fila = document.getElementById("tablaElementos").rows[numeroFila];

    var idPersona;
    var nombre;
    var apellido;
    var fechaNacimiento;
    var direccion;
    var telefono;
    var idDepartamento;

    for (index = 0; index < 7; index++) {

        switch (index) {
            case 0:
                //idPersona = document.getElementById("inputNombre" + numeroFila);
                idPersona = fila.children.item(index).firstChild.innerHTML; //Peta porque en este momento no existe este elemento.
                                                    //Solucion: crear los boxes donde se edita los datos de la persona
                break;
            case 1:
                //nombre = fila.children.item(index).children.item(1).innerHTML;
                nombre = document.getElementById("inputNombre" + numeroFila).value;
                break;
            case 2:
                apellido = document.getElementById("inputApellido" + numeroFila).value;
                break;
            case 3:
                fechaNacimiento = document.getElementById("inputFechaNac" + numeroFila).value;
                break;
            case 4:
                direccion = document.getElementById("inputDireccion" + numeroFila).value;
                break;
            case 5:
                telefono = document.getElementById("inputTelefono" + numeroFila).value;
                break;
            case 6:
                var lista = document.getElementById("listaDepartamentos" + numeroFila);

                idDepartamento = lista.options[lista.selectedIndex].value;
                break;
        }

        if(index>0) fila.children.item(index).firstChild.hidden = false;

        //item.parentNode.removeChild(item);
    }

    //Visibilidad de botones
    fila.children.item(7).firstChild.hidden = false;
    fila.children.item(8).firstChild.hidden = false;
    fila.children.item(9).firstChild.hidden = true;
    fila.children.item(10).firstChild.hidden = true;

    


    var clsPersona = function (id, nombre, apellido, fechaNac, direccion, telefono, idDep) {
        this.idPersona = id;
        this.nombre = nombre;
        this.apellidos = apellido;
        this.fechaNacimiento = fechaNac;
        this.direccion = direccion;
        this.telefono = telefono;
        this.idDepartamento = idDep;
    }

    var persona = new clsPersona(idPersona, nombre, apellido, fechaNacimiento, direccion, telefono, idDepartamento);

    //var array = [idPersona, nombre, apellido, fechaNacimiento, direccion, telefono, idDepartamento];

    //Eliminar los textbox
    for (index = 0; index < 6; index++) {
        var aux;

        switch (index) {
            case 0:
                aux = document.getElementById("inputNombre" + numeroFila);
                break;
            case 1:
                aux = document.getElementById("inputApellido" + numeroFila);
                break;
            case 2:
                aux = document.getElementById("inputFechaNac" + numeroFila);
                break;
            case 3:
                aux = document.getElementById("inputDireccion" + numeroFila);
                break;
            case 4:
                aux = document.getElementById("inputTelefono" + numeroFila);
                break;
            case 5:
                aux = document.getElementById("listaDepartamentos" + numeroFila);
                break;
        }

        aux.parentNode.removeChild(aux);
    }


    llamadaPUT(persona);

    //Mensaje de test
    //var msg = idPersona + ", " + nombre + ", " + apellido + ", " + fechaNacimiento + ",  " + direccion + ", " + telefono + ", " + idDepartamento;
    //alert(msg);
}


function CrearEventosOnClickGuardar() {
    var tabla = document.getElementById("tablaElementos");
    var fila = null;

    for (i = 1; i <= tabla.children.item(1).children.length; i++) {

        fila = tabla.rows[i];
        fila.children.item(9).firstChild.addEventListener("click", clickGuardar, false);

    }
}

function llamadaPUT(objeto) {
    var persona = JSON.stringify(objeto);
    //var persona2 = JSON.stringify({"idPersona": "9","nombre": "PostmanStudio","apellido": "Prueba","fechaNac": "1987-11-08T00:00:00","direccion": "Calle Larga","telefono": "666777888","idDepartamento": "1"});
    

    //generarTabla(arrayPersonas);//, arrayDepartamentos);

    var putPersona = new XMLHttpRequest();

    putPersona.open("PUT", urlPersonas, true);
    putPersona.setRequestHeader('Content-Type', 'application/json');

    putPersona.onreadystatechange = function () {
        //alert(putPersona.onreadystatechange);
        console.log(putPersona.readyState);

        if (putPersona.readyState == 4) {// && putPersona.status == 200) {
            alert(putPersona.status);

            //TODO: si el codigo es 200, cambiar los valores de los campos de la lista por los del textbox. Seguramente hay que mandar como parametro aqui numeroFila
        }
    };

    putPersona.send(persona);
}


function generarTablaNuevaPersona(arrayPersonas, arrayDepartamentos) {
    //Obtener referencia del elemento Body
    //var body = document.getElementsByTagName("body")[0];

    var div = document.getElementById("barraNuevaPersona");

    //Crea una tabla y un elemento para su cuerpo
    var tabla = document.getElementById("tablaNuevaPersona");


    //Claves del array
    var cols = 0;
    if (arrayPersonas != null && arrayPersonas.length > 0) cols = Object.keys(arrayPersonas[0]);
    else console.log("arrayPersonas no tiene elementos");

    var thead = document.createElement("thead");

    //Crea la hileras de la tabla para mostrar las claves
    var hilera = document.createElement("tr");

    for (var i = 0; i < cols.length; i++) {
        var thh = document.createElement("th");


        if (cols[i] == "idDepartamento") {
            textoTh = document.createTextNode("Departamento");
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

    //Crear la fila donde se encontrarán los textbox

    //Crea las hileras de la tabla
    hilera = document.createElement("tr");

    //Crear las columnas
    for (var prop in arrayPersonas[0]) {

        //Crea un elemento td
        var celda = document.createElement("td");

        //Crear aqui un elemento input para el textbox
        var itemCelda = null;

        var textoCelda = null;

        var listaDepartamentos = null;


        switch (prop) {
            case "idPersona":
                itemCelda = document.createElement("input");
                itemCelda.setAttribute("id", "nIdPersona");

                textoCelda = document.createTextNode("0");

                break;

            case "nombre":
                itemCelda = document.createElement("input");
                itemCelda.setAttribute("id", "nNombre");

                break;

            case "apellidos":
                itemCelda = document.createElement("input");
                itemCelda.setAttribute("id", "nApellidos");
                

                break;

            case "fechaNacimiento":
                itemCelda = document.createElement("input");
                itemCelda.setAttribute("id", "nFechaNacimiento");
                itemCelda.setAttribute("type", "datetime-local");

                break;

            case "direccion":
                itemCelda = document.createElement("input");
                itemCelda.setAttribute("id", "nDireccion");

                break;

            case "telefono":
                itemCelda = document.createElement("input");
                itemCelda.setAttribute("id", "nTelefono");

                break;

            case "idDepartamento":
                
                listaDepartamentos = document.createElement("select");
                listaDepartamentos.setAttribute("id", "nListaDepartamentos");

                for (var i = 0; i < arrayDepartamentos.length; i++) {
                    var opcion = document.createElement("option");
                    var idDep = arrayDepartamentos[i]["idDepartamento"];
                    var nombre = arrayDepartamentos[i]["nombreDepartamento"];

                    opcion.value = idDep;
                    opcion.text = nombre;

                    listaDepartamentos.appendChild(opcion);
                }

                break;

            default:
                itemCelda.setAttribute("id", "default");
                textoCelda = document.createTextNode(arrayPersonas[i][prop]);
                break;
        }

        if (itemCelda != null) {
            if (textoCelda != null) itemCelda.appendChild(textoCelda);
            celda.appendChild(itemCelda);
        }
        else {
            celda.appendChild(listaDepartamentos);
        }

        hilera.appendChild(celda);
    }


    hilera.cells[posicionIdPersona].hidden = true;

    //Añadir los botones necesarios
    var btnGuardar = document.createElement("tr");
    var txtGuardar = document.createElement("input");

    //txtGuardar.hidden = true;
    //txtGuardar.setAttribute("numerofila", i + 1);
    txtGuardar.setAttribute("id", "btnGuardarNuevaPersona");
    txtGuardar.setAttribute("type", "button");
    txtGuardar.setAttribute("value", "Guardar");
    txtGuardar.setAttribute("class", "mdl-button mdl-js-button mdl-button--raised mdl-button--colored");
    btnGuardar.appendChild(txtGuardar);
    hilera.appendChild(btnGuardar);


    var btnCancelar = document.createElement("tr");
    var txtCancelar = document.createElement("input");

    //txtCancelar.hidden = true;
    //txtCancelar.setAttribute("numerofila", i + 1);
    txtCancelar.setAttribute("id", "btnCancelarNuevaPersona");
    txtCancelar.setAttribute("type", "button");
    txtCancelar.setAttribute("value", "Cancelar");
    txtCancelar.setAttribute("class", "mdl-button mdl-js-button mdl-button--raised mdl-button--colored");
    btnCancelar.appendChild(txtCancelar);
    hilera.appendChild(btnCancelar);



    //agrega la hilera al final de la tabla (final del elemento tbody)
    tbody.appendChild(hilera);

    //posicionar tbody debajo del elemento tabla
    tabla.appendChild(tbody);


    div.appendChild(tabla);

    //body.appendChild(div);
}


function clickGuardarNuevaPersona() {

    //No ocultar ni refrescar la pagina, si da error se da un aviso, y si se hace bien refrescar la pagina

    //Recoger los datos de los campos


    //var numeroFila = this.getAttribute("numerofila");

    var fila = document.getElementById("tablaNuevaPersona").children.item(1).firstChild;

    var idPersona;
    var nombre;
    var apellido;
    var fechaNacimiento;
    var direccion;
    var telefono;
    var idDepartamento;

    for (index = 0; index < 7; index++) {

        switch (index) {
            case 0:
                //idPersona = document.getElementById("inputNombre" + numeroFila);
                idPersona = fila.children.item(index).firstChild.innerHTML; //Peta porque en este momento no existe este elemento.
                //Solucion: crear los boxes donde se edita los datos de la persona
                break;
            case 1:
                //nombre = fila.children.item(index).children.item(1).innerHTML;
                nombre = document.getElementById("nNombre").value;
                break;
            case 2:
                apellido = document.getElementById("nApellidos").value;
                break;
            case 3:
                fechaNacimiento = document.getElementById("nFechaNacimiento").value;
                break;
            case 4:
                direccion = document.getElementById("nDireccion").value;
                break;
            case 5:
                telefono = document.getElementById("nTelefono").value;
                break;
            case 6:
                var lista = document.getElementById("nListaDepartamentos");

                idDepartamento = lista.options[lista.selectedIndex].value;
                break;
        }

        if (index > 0) fila.children.item(index).firstChild.hidden = false;

        //item.parentNode.removeChild(item);
    }

    //Visibilidad de botones
    //fila.children.item(7).firstChild.hidden = false;
    //fila.children.item(8).firstChild.hidden = false;
    //fila.children.item(9).firstChild.hidden = true;
    //fila.children.item(10).firstChild.hidden = true;


    var clsPersona = function (id, nombre, apellido, fechaNac, direccion, telefono, idDep) {
        this.idPersona = id;
        this.nombre = nombre;
        this.apellidos = apellido;
        this.fechaNacimiento = fechaNac;
        this.direccion = direccion;
        this.telefono = telefono;
        this.idDepartamento = idDep;
    }

    var persona = new clsPersona(0, nombre, apellido, fechaNacimiento, direccion, telefono, idDepartamento);

    llamadaPOST(persona);

    //var msg = JSON.stringify(persona);
    //alert(msg);
    
}

//function CrearEventosOnClickGuardarNuevaPersona() {
//    var tabla = document.getElementById("tablaElementos");
//    var fila = null;

//    for (i = 1; i <= tabla.children.item(1).children.length; i++) {

//        fila = tabla.rows[i];
//        //var numeroFila = fila.children.item(7).firstChild.numeroFila;
//        fila.children.item(7).firstChild.addEventListener("click", clickEditar, false);

//    }
//}



function botonesNuevaPersona() {
    var boton = document.getElementById("btnNuevo");
    boton.addEventListener("click", clickBotonNuevaPersona, false);

    boton = document.getElementById("btnGuardarNuevaPersona");
    boton.addEventListener("click", clickGuardarNuevaPersona, false);

    boton = document.getElementById("btnCancelarNuevaPersona");
    boton.addEventListener("click", clickCancelarNuevaPersona, false);
    
}

function visibilidadNuevaPersona(visible) {
    var barra = document.getElementById("barraNuevaPersona");
    barra.hidden = visible;
}

function clickBotonNuevaPersona() {
    //visibilidadNuevaPersona(false);

    var barra = document.getElementById("barraNuevaPersona");

    if (barra.hidden == true) {
        visibilidadNuevaPersona(false);
    }
    else {
        clickCancelarNuevaPersona();
    }
}

function clickCancelarNuevaPersona() {
    //alert("Llamada a cancelarPersona");

    borrarCamposNuevaPersona();

    visibilidadNuevaPersona(true);
}

function llamadaPOST(objeto) {
    var persona = JSON.stringify(objeto);

    var postPersona = new XMLHttpRequest();

    postPersona.open("POST", urlPersonas, true);
    postPersona.setRequestHeader('Content-Type', 'application/json');

    postPersona.onreadystatechange = function () {
        //alert(putPersona.onreadystatechange);
        console.log(putPersona.readyState);

        if (postPersona.readyState == 4) {// && putPersona.status == 200) {
            alert(putPersona.status);
        }
    };

    postPersona.send(persona);
}


function borrarCamposNuevaPersona() {
    
    document.getElementById("nNombre").value = "";
    document.getElementById("nApellidos").value = "";
    document.getElementById("nFechaNacimiento").value = "";
    document.getElementById("nDireccion").value = "";
    document.getElementById("nTelefono").value = "";

    //var lista = document.getElementById("nListaDepartamentos");
    //lista.options[lista.selectedIndex].value = 1;

}
