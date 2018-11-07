(function () {
    $(function () {
        getEmployees();
    });
    function getEmployees() {
        var getEmployees = $('.getEmployees');
        getEmployees.on('click touchend', function () {
            
            let id = $(".employee").val();
            let url = "http://localhost:51019/api/Employee/";
            if (id != "") {
                url=url+id
            }
            $.ajax({
                type: "GET",
                url: url,
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    if (id == "") {

                        var html = '<table class="dataTable">';
                        html += '<thead><tr>';
                        var flag = 0;
                        $.each(data[0], function (index, value) {
                            html += '<th>' + index + '</th>';
                        });
                        html += '</tr></thead>';
                        html += '<tfoot><tr>';
                        var flag = 0;
                        $.each(data[0], function (index, value) {
                            html += '<th>' + index + '</th>';
                        });
                        html += '</tr></tfoot><tbody>';
                        $.each(data, function (index, value) {
                            html += '<tr>';
                            html += '<td>' + value.salary + '</td>';
                            html += '<td>' + value.id + '</td>';
                            html += '<td>' + value.name + '</td>';
                            html += '<td>' + value.role.name + '</td>';
                            html += '</tr>';
                        });
                        html += '</tbody></table>';
                        $('.data').html(html);
                        $(".dataTable").DataTable();
                    } else {
                        var html = '<ul>';
                         html += '<li><strong>salary</strong>: '+data.salary+'</li>';
                        html += '<li><strong>id</strong>:' + data.id +'</li>';
                        html += '<li><strong>name</strong>: ' + data.name +'</li>';
                        html += '<li><strong>Role</strong>: ' + data.role.name +'</li>';
                         html += '</ul >';

                        $('.data').html(html, function () {
                        })
                    }
                },
                error: function () {
                    toastr.error('Employee doesn\' exists', 'Error', {
                        timeOut: 5000,
                        positionClass: 'toast-top-full-width',
                    });
                }
            });

        }
        )
    };
    
})();