var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
   dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/admin/ongs"
        },
        "columns": [
            { "data": "createdAt", "width": "20%" },
            { "data": "name", "width": "30%" },
            { "data": "cnpj", "width": "10%" },
            { "data": "responsibleName", "width": "20%" },
            { "data": "approved", "width": "10%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <div class="text-center">
                            <a href="/admin/revisar/${data}" class="btn btn-success text-white" style="cursor: pointer">
                                <i class="fas fa-edit"></i>
                            </a>
                        </div>
                    `;
                }, "width": "10%"
            }
        ]
    });
}

function Delete(url) {
    swal({
        title: "Are you sure you want to Delete?",
        text: "You will not be able to restore the data!",
        icon: "warning",
        buttons: true,
        dangerMode: true,
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    } else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}