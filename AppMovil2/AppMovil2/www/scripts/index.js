// Si quiere una introducción sobre la plantilla En blanco, vea la siguiente documentación:
// http://go.microsoft.com/fwlink/?LinkID=397704
// Para depurar código al cargar la página en cordova-simulate o en dispositivos o emuladores Android: inicie la aplicación, establezca puntos de interrupción 
// y ejecute "window.location.reload()" en la Consola de JavaScript.
(function () {
    "use strict";

    document.addEventListener( 'deviceready', onDeviceReady.bind( this ), false );

    function onDeviceReady() {
        // Controlar la pausa de Cordova y reanudar eventos
        document.addEventListener( 'pause', onPause.bind( this ), false );
        document.addEventListener( 'resume', onResume.bind( this ), false );
        
        // TODO: Cordova se ha cargado. Haga aquí las inicializaciones que necesiten Cordova.
        document.getElementById("btnBuscar").addEventListener('click', BuscarUsuario, false);
        document.getElementById("btnCargar").addEventListener('click', CargarLista, false);


    };

    function onPause() {
        // TODO: esta aplicación se ha suspendido. Guarde el estado de la aplicación aquí.
    };

    function onResume() {
        // TODO: esta aplicación se ha reactivado. Restaure el estado de la aplicación aquí.
    };

    function BuscarUsuario() {
        var usuario = document.getElementById("txtNombre").value;
        if (usuario == "") {
            document.getElementById("divResultado").innerHTML = "ingrese un usuario!";
        } else {
            //agregando evento Ajax
            $.ajax({
                type: "GET",
                url: "https://jsonplaceholder.typicode.com/users?username=" + usuario,
                crossDomain: true,
                cahce: false,
                success: function (result) {
                    document.getElementById("divResultado").innerHTML = "Bienvenido: " + result[0].name;
                },
                error: function (result) {
                    alert("Ocurrio un problema. Por favor Comuniquese con el administrador del sistema. Gracias.");
                }
            });
        }
    }
    function CargarLista() {
        var cadena = "<table border=0 cellpadding=2 cellspacing=0><tr><th>Nombre</th><th>Direccion</th><th>Telefono</th></tr>";
        //agregando evento Ajax
        $.ajax({
            type: "GET",
            url: "https://jsonplaceholder.typicode.com/users" ,
            crossDomain: true,
            cahce: false,
            contentType: "application/json; charset=utf-8",
            async: false,
            dataType: "json",
            success: function (result) {
                $.each(result, function (i, field) {
                    cadena = cadena + "<tr>" + "<td>" + field.name + "</td><td>" + field.address.street + "</td><td>" + field.phone + "</td>" + "</tr>";
                });
                cadena = cadena + "</table>";
                $("#divLista").append(cadena);
            },
            error: function (result) {
                alert("Ocurrio un problema. Por favor Comuniquese con el administrador del sistema. Gracias.");
            }
        });
    }
} )();