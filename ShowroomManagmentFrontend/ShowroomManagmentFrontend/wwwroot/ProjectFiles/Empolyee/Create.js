
$(document).ready(function () {
    LoadDepartment();
});
function validationControls() {
    var isEmpty = false;
    var name = $('#txtName').val();
    if (name == '' || name == null) {
        isEmpty = true
        $('#errorName').text("This is a Required Feild")
        $('#txtName').addClass('is-invalid')
    }
    return isEmpty;
}
$('#txtName').on('change', function () {
    var val = $(this).val();
    if (val == '' || val == null) {
        $('#errorName').text("This is a Required Feild")
        $('#txtName').addClass('is-invalid')
    } else {
        $('#errorName').empty();
        $('#txtName').removeClass('is-invalid')
    }
})


$('#btnSubmit').on('click', function () {
    if (!validationControls()) {
    var name = $('#txtName').val();
        var desc = $('#txtDesc').val();

        var obj = {
            "Name": name,
            "Description" : desc
        }
        console.log(obj);
        $.ajax({
            url: APIURLs.department_AddDepartments,
            type: 'POST',
            contentType: 'application/json',
            datatype: 'json',
            data: JSON.stringify(obj),
            success: function (resp) {
                if (resp.ErrorMessage != null || resp.ErrorMessage != '') {
                    console.log('action fire');
                    Swal.fire({
                        title: "Action Successfull!",
                        text: "Department has been Created!",
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
function LoadDepartment() {

    $.ajax({
        url: APIURLs.department_GetDepartments,
        type: 'GET',
        data: null,
        success: function (resp) {
            var data = JSON.parse(resp);

            // Clear existing options in the select element
            $('.form-control.select2bs4').empty();

            // Iterate over the response data and append options to the select element
            for (let item of data.Response) {
                $('.form-control.select2bs4').append(`<option value="${item.Id}">${item.Name}</option>`);
            };

            $('.form-control.select2bs4').select2();
        }

    });

}

