var dataTable;

$(document).ready(function () {
    cargarDatatable();
});


function cargarDatatable() {
    dataTable = $("#tblCiclos").DataTable({
        "ajax": {
            "url": "/admin/ciclos/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "id", "width": "30%" },
            { "data": "anioAcademico", "width": "30%" },
     
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                            <a href='/Admin/Ciclos/Edit/${data}' class='btn btn-success btn-sm text-white' style='cursor:pointer; width:50px;'>
                            <i class='fas fa-edit'></i> Editar
                            </a>
                            &nbsp;
                            <a onclick=Delete("/Admin/Ciclos/Delete/${data}") class='btn btn-danger btn-sm text-white' style='cursor:pointer; width:50px;'>
                            <i class='fas fa-trash-alt'></i> Borrar
                            </a>
                            `;
                }, "width": "15%"
            }
        ],
        "language": {
            "emptyTable": "No hay registros"
        },
        "width": "100%"
    });
}


function Delete(url) {
    swal({
        title: "¿Esta seguro de borrar?",
        text: "¡Este contenido no se puede recuperar!",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Si, ¡borrar!",
        closeOnconfirm: true
    }, function () {
        $.ajax({
            type: 'DELETE',
            url: url,
            success: function (data) {
                if (data.success) {
                    toastr.success(data.message);
                    dataTable.ajax.reload();
                }
                else {
                    toastr.error(data.message);
                }
            }
        });
    });
}
