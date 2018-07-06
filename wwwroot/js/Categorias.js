
class Categorias
{
    
    constructor(nombre, descripcion, estado, action)
    {
        this.nombre = nombre;
        this.descripcion = descripcion;
        this.estado = estado;
        this.action = action;
        
    };

    agregarCategoria()
    {
        if (this.nombre == "") {
            document.getElementById('Nombre').focus();

            alert('Por favor ingrese un Nombre.');

            return; 

        }

        if (this.descripcion == "") {
            document.getElementById('Descripcion').focus();
            alert('Por favor ingrese na Descripción.');

            return;
        }

        if (this.estado == "0") {
                document.getElementById('Estado').focus();
                alert('Por favor seleccione un Estado.');
            //document.getElementById("mensaje").innerHTML = "Seleccione un estado";           
            return;
        }
       
            //alert(this.nombre);

            var nombre = this.nombre;
            var descripcion = this.descripcion;
            var estado = this.estado;
            var action = this.action;
            var mensaje = '';

            $.ajax({

                type: "POST",
                url: action,
                data: { nombre, descripcion, estado },
                success: (response) => {

                    $.each(response, (index, val) => {

                        mensaje = val.code;
                        
                    });

                    if (mensaje === "Save")
                    {
                        this.restablecer();
                    }
                    else
                    {
                        //document.getElementById("mensaje").innerHTML("No se puede guardar la Categoria");
                        alert('No se puede guaradr la Categoria');
                    }

                    //console.log(response);

                }

            });                

    }

    filtrarDatos(numPagina)
    {
        var valor = this.nombre;
        var action = this.action;

        if (valor == "")
        {
            valor = "null";
        }

        $.ajax({

            type: "POST",
            url: action,
            data: { valor, numPagina },
            success: (response) => {

                console.log(response);
                $.each(response, (index, val) => {  

                    $('#resultSearch').html(val[0]);
                    $('#paginado').html(val[1]);

                });

            }

        });
    }

    restablecer()
    {
        document.getElementById('Nombre').value = "";
        document.getElementById('Descripcion').value = "";
        document.getElementById('mensaje').innerHTML = "";
        document.getElementById('Estado').selectedIndex = 0; 
        $('#modalAC').modal('hide');
    }

}
