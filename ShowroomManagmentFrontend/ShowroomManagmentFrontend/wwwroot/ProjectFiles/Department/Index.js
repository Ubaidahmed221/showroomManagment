
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
          
            console.log(data.Response);

            for (let item of data.Response) {
                $('.mytable tbody').append(`
                <tr>
                <td>${item.Name}</td>
                 <td>${item.Description}</td>
                
                </tr>
                `);

            }       
            //$(function () {
            //    $("#example1").DataTable({
            //        "responsive": true, "lengthChange": false, "autoWidth": false,
            //        "buttons": ["copy", "csv", "excel", "pdf", "print", "colvis"]
            //    }).buttons().container().appendTo('#example1_wrapper .col-md-6:eq(0)');

            //});
           

        }

    });

}