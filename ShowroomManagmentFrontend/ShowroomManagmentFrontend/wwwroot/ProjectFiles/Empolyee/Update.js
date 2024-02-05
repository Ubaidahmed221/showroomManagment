
function editvalidationControls() {
    var isEmpty = false;
    var name = $('#edittxtName').val();
    if (name == '' || name == null) {
        isEmpty = true
        $('#editerrorName').text("This is a Required Feild")
        $('#edittxtName').addClass('is-invalid')
    }
    return isEmpty;
}
$('#edittxtName').on('change', function () {
    var val = $(this).val();
    if (val == '' || val == null) {
        $('#editerrorName').text("This is a Required Feild")
        $('#edittxtName').addClass('is-invalid')
    } else {
        $('#editerrorName').empty();
        $('#edittxtName').removeClass('is-invalid')
    }
})



$('#btnUpdate').on('click', function () {
    if (!editvalidationControls()) {
        var name = $('#edittxtName').val();
        var desc = $('#edittxtDesc').val();
        var id = $('#iddepart').val();

        var obj = {
            "Id" : id,
            "Name": name,
            "Description": desc
        }
        console.log(JSON.stringify(obj));
        console.log(obj);
        $.ajax({
            url: APIURLs.department_UpdateDepartment,
            type: 'POST',
            contentType: 'application/json',
            datatype: 'json',
            data: JSON.stringify(obj),
            success: function (resp) {
                console.log(resp);
                if (resp.ErrorMessage != null || resp.ErrorMessage != '') {
                    console.log('action fire');
                    Swal.fire({
                        title: "Action Successfull!",
                        text: "Department has been Updated!",
                        icon: "success",
                        isConfirmed: "OK",
                    })
                        .then((result) => {
                            window.location.reload();

                        });

                }

            }
        })

   }

})