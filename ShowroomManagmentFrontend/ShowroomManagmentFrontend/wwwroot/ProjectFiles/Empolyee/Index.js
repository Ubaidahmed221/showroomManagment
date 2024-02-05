
$(document).ready(function () {
    LoadData();
});

//-----------------------------------  LOAD DATA FROM API ---------------------------

function LoadData() {

    $.ajax({
        url: APIURLs.department_GetDepartments,
        type: 'GET',
        data: null,
        success: function (resp) {
            var data = JSON.parse(resp);
          
            for (let item of data.Response) {
                $('#example1 tbody').append(`
                <tr>
                <td>${item.Name}</td>
                 <td>${item.Description}</td>
                 <td>
                 <input hidden value="${item.Id}" />
                 <button  class="btn btn-info btn-sm btnEdit" >Edit</button>
                 <input hidden value="${item.Id}" />
                 <button  class="btn btn-danger btn-sm btnDelete" >Delete</button>
                 </td>
                </tr>
                `);

            }    
            $(function () {
                $("#example1").DataTable({
                    dom: 'lBfrtip',
                    "responsive": true, "lengthChange": false, "autoWidth": false,
                    "buttons": ["copy", "csv", "excel", "pdf", "print", "colvis"]
                }).buttons().container().appendTo('#example1_wrapper .col-md-6:eq(0)');

            });          

        }

    });

}

    $('body').on("click", '.btnDelete', function () {
        var id = $(this).prev().val();
        console.log(id);
    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to Delete this record!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: APIURLs.department_DeleteDepartment + '/' + id,
                type: 'Get',
                success: function (resp) {
                    if (resp.ErrorMessage != null || resp.ErrorMessage != '') {
                        Swal.fire({
                            title: "Deleted!",
                            text: "Your record has been deleted.",
                            icon: "success"
                        })
                            .then((result) => {
                                window.location.reload();

                            });
                    }
                }

            });
          
        }
    });
    });

$('body').on("click", '.btnEdit', function () {
    var id = $(this).prev().val();
    $('#edit-lg').modal('show');

    $.ajax({
        url: APIURLs.department_GetDepartmentById + '/' + id,
        type: 'GET',        
        success: function (resp) {
            var data = JSON.parse(resp);
            $('#iddepart').val(data.Response.Id);
            $('#edittxtName').val(data.Response.Name);
            $('#edittxtDesc').val(data.Response.Description);

        },
        error: function (xhr, status, error) {
            console.log(status);
            console.log(error);
            console.error("AJAX request failed:", status, error);
            // Handle the error, e.g., show an error message to the user
        }

    });

    console.log(id);

});