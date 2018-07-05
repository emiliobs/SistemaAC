
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
       
            alert(this.nombre);

            var nombre = this.nombre;
            var descripcion = this.descripcion;
            var estado = this.estado;
            var action = this.action;
            var mensaje = '';

            $.ajax({

                type: "POST",
                url: action,
                data: { nombre, descripcion, estado },
                success: (response) => { }

            });
        
        

    }

}
