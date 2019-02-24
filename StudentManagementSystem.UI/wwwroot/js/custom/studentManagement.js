//modlar pattern for managing student class
var StudentManagement = (function () {

    //invoke student table
    var populateStudentList = function () {
        $('#tblStudentData').dataTable({
            "serverSide": true,
            "order": [[1, "asc"]],
            "bPaginate": false,
            "searching": false, "paging": false, "info": false,
            "ajax": {
                "url": "/StudentManagement/GetStudentListAsync",
                "data": function (d) {
                    d.Id = $("#hiddenId").val();
                },
                "dataSrc": "data"
            },
            "columns": [
                { "data": "id", "orderable": true, "visible": false },
                {
                    mRender: function (data, type, row) {
                        if (row.gpa >= 3.2) {
                            return '<span class="nameClass">' + row.fullName + '</span><span class="starClass">&#9733;</span>'
                        } else {
                            return '<span>' + row.fullName + '</span>'
                        }
                    }
                },
                { "data": "age", "orderable": true, "visible": true },
                { "data": "gpa", "orderable": true, "visible": true },
                {
                    mRender: function (data, type, row) {
                        return '<a class="editStudent" data-id="' + row.id + '">Edit</a>'
                    }, "orderable": false
                },
                {
                    mRender: function (data, type, row) {
                        return '<a class="deleteStudent" data-id="' + row.id + '">Delete</a>'
                    }, "orderable": false
                }
            ]
        });
    }

    var initializePopup = function () {
        $('#dialogStudent').dialog({
            dialogClass: "noOverlayDialog",
            autoOpen: false,
            draggable: false,
            resizable: false,
            modal: true
        });
    }

    //get id from hidden value
    var getId = function () {
        return $("#hiddenId").val();
    }

    //show edit stdent popup
    var showEditStudentPopup = function (data) {
        Globals.clearInputControls($('#dialogStudent'));
        $('[aria-describedby=dialogStudent] .ui-dialog-title').text('Edit Student');
        $('#dialogStudent').data('id', data.id).dialog('open');
        $("#firstName").val(data.firstName);
        $("#lastName").val(data.lastName);
        $("#ageId").val(data.age);
        $("#gpaId").val(data.gpa);
    }

    var showAddStudentPopup = function () {
        Globals.clearInputControls($('#dialogStudent'));
        $('[aria-describedby=dialogStudent] .ui-dialog-title').text('Add Student');
        $('#dialogStudent').data('id', 0).dialog('open');
    }

    //update student details
    var updateOrAddStudentDetails = function () {
        var data = getStudentFormValues();
        Globals.ajaxPost("/StudentManagement/UpdateOrAddStudentAsync", {
            Id: data.Id, FirstName: data.FirstName, LastName: data.LastName,
            Age: data.Age, Gpa: data.Gpa, ClassId: data.ClassId
        }, function (dto) {
            if (dto.responseCode == 1) {
                $('#dialogStudent').dialog('close');
                refreshStudentTable();
            } else {
                $('.classerror').text(dto.errorMessage);
            }

        }, function (dto) {
        });
    }

    //delete student details
    var deleteStudent = function (id) {
        Globals.ajaxPost("/StudentManagement/DeleteClassAsync", { Id: id }, function (dto) {
            refreshStudentTable();
        }, null);
    }

    var refreshStudentTable = function () {
        $(".studentRow").removeClass("studentRow");
        $('#tblStudentData').DataTable().ajax.reload();
    }

    var hideStudentTable = function () {
        $('#tblStudentData').DataTable().ajax.reload();
    }

    var showStudentTable = function () {
        $('#tblStudentData').DataTable().ajax.reload();
    }

    //get values from student form
    var getStudentFormValues = function () {
        return {
            FirstName: $("#firstName").val(), LastName: $("#lastName").val(), Age: $("#ageId").val(),
            Gpa: $("#gpaId").val(), Id: $("#dialogStudent").data('id'), ClassId: $("#hiddenId").val()
        };
    }

    return {
        deleteStudent: deleteStudent,
        updateOrAddStudentDetails: updateOrAddStudentDetails,
        showEditStudentPopup: showEditStudentPopup,
        showAddStudentPopup: showAddStudentPopup,
        populateStudentList: populateStudentList,
        initializePopup: initializePopup,
        refreshStudentTable: refreshStudentTable
    };

})();