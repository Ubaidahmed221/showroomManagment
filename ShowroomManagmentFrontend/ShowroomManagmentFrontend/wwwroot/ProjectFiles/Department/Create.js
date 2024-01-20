
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
            data: JSON.stringify(obj),
            success: function (resp) {
                console.log(resp)

            }
        })

    }

})