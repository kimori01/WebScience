$("#NgaySinh").datepicker({ autoclose: true, format: 'dd/mm/yyyy' });
$("#NgayDangKy").datepicker({ autoclose: true, format: 'dd/mm/yyyy' });
$("#NgayCongBo").datepicker({ autoclose: true, format: 'dd/mm/yyyy' });

$(function () {
    var ajaxFromSubmit = function (e) {
        var $from = $(this);

        var options = {
            url: $from.attr("action"),
            type: $from.attr("method"),
            data: $from.serialize()
        };

        $.ajax(options).done(function (data) {
            var $target = $($from.attr("data-otf-target"));
            $target.replaceWith(data);
        });

        return false;
    };
  
    $("from[data-otf-ajax='true']").submit(ajaxFromSubmit);
   
})

//Load Data function
function seachData(table_search) {
    $.ajax({
        url: "/DeTai/TimKiemLyLich?table_search=" + table_search + "",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            html += '<tr>';
            html += '<th>MaLyLich</th>';
            html += '<th>HoVaTen</th>';
            html += '<th>MaHocHam</th>';
            html += '<th>MaHocVi</th>';
            html += '<th></th>';
            html += '</tr>';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td class="nr">' + item.MaLyLich + '</td>';
                html += '<td>' + item.HoVaTen + '</td>';
                html += '<td>' + item.MaHocHam + '</td>';
                html += '<td>' + item.MaHocVi + '</td>';
                html += '<td><button type="button" class="btn btn-block btn-default btn-sm btnSelect" data-dismiss="modal">Chọn</button></td>';
                html += '</tr>';
            });
            $('.tbody').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

$(document).ready(function () {
    // code to read selected table row cell data (values).
    $("#myTable").on('click', '.btnSelect', function () {
        // get the current row
        var currentRow = $(this).closest("tr");
        var col1 = currentRow.find("td:eq(0)").text(); // get current row 1st TD value
        var col2 = currentRow.find("td:eq(1)").text(); // get current row 2nd TD
        var col3 = currentRow.find("td:eq(2)").text(); // get current row 3rd TD

        $("#TacGia").val(col2);
        $("#IdMaLyLich").val(col1);
    });
});

//function getlylich() {
//    var $item = $(this).closest("tr").find(".nr").text(); 
//    alert($item);
//}

//$('#ids').click(function () {
//    //var productId = $(this).closest("tr").find("td").eq(0).text();
//    alert('111111');
//});