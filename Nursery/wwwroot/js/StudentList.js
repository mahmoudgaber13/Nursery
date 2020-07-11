//var dataTable;

//$(document).ready(function () {
//    LoadDataTable();
//});

//function LoadDataTable()
//{
//    dataTable = $("#DT_load").dataTable({
//        "ajax": {
//            "url": "/api/Students",
//            "type": "GET",
//            "datatype": "json"
//        },
//        "Columns": [
//            { "data": "name", "width": "30%" },
//            { "data": "address", "width": "30%" },
//            { "data": "phone", "width": "30%" },
//            {
//                "data": "id",
//                "render": function (data) {
//                    return
//                    `<div class="text-center">
//                        <a href="/Students/Edit?id=${data}" class="btn btn-success text-white" style="cursor:pointer; width:100px" >
//                            Edit
//                        </a>
//                        &nbsp;
//                        <a  class="btn btn-danger text-white" style="cursor:pointer; width:100px" >
//                            Delete
//                        </a>
//                    </div>`;
//                }, "width": "30%"
//            }
//        ],
//        "language": {
//            "emptyTable": "no data found"
//        },
//        "width": "100%"
//    });
//}

var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/Students",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "name", "width": "20%" },
            { "data": "address", "width": "20%" },
            { "data": "phone", "width": "20%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                        <a href="/Students/Upsert?id=${data}" class='btn btn-success text-white' style='cursor:pointer; width:70px;'>
                            Edit
                        </a>
                        &nbsp;
                        <a class='btn btn-danger text-white' style='cursor:pointer; width:70px;'
                            onclick=Delete('/api/Students?id='+${data})>
                            Delete
                        </a>
                        </div>`;
                }, "width": "40%"
            }
        ],
        "language": {
            "emptyTable": "no data found"
        },
        "width": "100%"
    });
}

function Delete(url) {
    swal({
        title: "Are you sure?",
        text: "Once deleted, you will not be able to recover",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
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
        }
    });
}