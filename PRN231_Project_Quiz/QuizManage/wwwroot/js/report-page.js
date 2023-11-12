    $('#companySelect').on('select2:select', function () {
        var companySelectId = $('#companySelect').val();
        if (companySelectId == 0) {
            $('#projectDiv').hide();
            return;
        }
        $.ajax({
            url: '/ReportPages/SendReport?handler=CompanySelect',
            type: 'GET',
            data: { companySelectId: companySelectId },
            success: function (data) {
                // Cập nhật nội dung của div chứa danh sách project
                var html = '<option value="0" selected>Select Project</option>';
                var ProjectList = JSON.parse(data.listProject);
                for (var i = 0; i < ProjectList.length; i++) {
                    html += '<option value="' + ProjectList[i].ProjectId + '">' + ProjectList[i].ProjectName + '</option>'
                }

                $('#projectSelect').html(html);
                $('#projectDiv').show();
            },
            error: function (xhr, status, error) {
                console.log(xhr.responseText);
            }
        });
    });
