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