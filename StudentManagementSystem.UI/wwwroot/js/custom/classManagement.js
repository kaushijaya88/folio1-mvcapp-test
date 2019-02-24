//modlar pattern for managing class
var ClassManagement = (function () {

    //invoke class list
    var populateClassList = function () {
        $('#tblClassData').dataTable({
            "serverSide": true,
            "order": [[1, "asc"]],
            "bPaginate": false,
            "searching": false, "paging": false, "info": false,
            "ajax": {
                "url": "/ClassManagement/GetClassListAsync",
                "dataSrc": "data"
            },
            "columns": [
                { "data": "id", "visible": false },
                { "data": "className", "orderable": true, "visible": true },
                { "data": "location", "orderable": true, "visible": true },
                { "data": "teacherName", "orderable": true, "visible": true },
                {
                    mRender: function (data, type, row) {
                        return '<a class="editClass" data-id="' + row.id + '">Edit</a>'
                    }, "orderable": false
                },
                {
                    mRender: function (data, type, row) {
                        return '<a class="deleteClass" data-id="' + row.id + '">Delete</a>'
                    }, "orderable": false
                }
            ]
        });
    }

    //initialize class popup
    var initializePopup = function () {
        $('#dialogClass').dialog({
            dialogClass: "noOverlayDialog",
            autoOpen: false,
            draggable: false,
            resizable: false,
            modal: true
        });
    }

    //make the edit popup visible
    var showEditClassPopup = function (data) {
        Globals.clearInputControls($('#dialogClass'));
        $('[aria-describedby=dialogClass] .ui-dialog-title').text('Edit Class');
        $('#dialogClass').data('id', data.id).dialog('open');
        $("#ClassName").val(data.className);
        $("#LocationName").val(data.location);
        $("#TeacherName").val(data.teacherName);
    }

    var showAddClassPopup = function () {
        Globals.clearInputControls($('#dialogClass'));
        $('[aria-describedby=dialogClass] .ui-dialog-title').text('Add Class');
        $('#dialogClass').data('id', 0).dialog('open');
    }

    //update class details
    var updateOrAddClassDetails = function () {
        var data = getClassFormValues();
        Globals.ajaxPost("/ClassManagement/UpdateOrAddClassAsync", { Id: data.Id, ClassName: data.Name, Location: data.Location, TeacherName: data.Teacher },
            function (dto) {
                $('#dialogClass').dialog('close');
                refreshClassTable();
            }, function (dto) {
            });
    }

    //delete class
    var deleteClass = function (id) {
        Globals.ajaxPost("/ClassManagement/DeleteClassAsync", { Id: id }, function (dto) {
            refreshClassTable();
        }, null);
    }

    //when click on table class row
    var tableRowClick = function (data) {
        $("#labelId").text(data.className);
        $("#hiddenId").val(data.id);
        if ($("#hiddenId").val() > 0)
            StudentManagement.refreshStudentTable();
    }

    //reload the class table
    var refreshClassTable = function () {
        $('#tblClassData').DataTable().ajax.reload();
    }

    //get values from class form
    var getClassFormValues = function () {
        return {
            Name: $("#ClassName").val(), Location: $("#LocationName").val(),
            Teacher: $("#TeacherName").val(), Id: $("#dialogClass").data('id')
        };
    }

    return {
        tableRowClick: tableRowClick,
        deleteClass: deleteClass,
        updateOrAddClassDetails: updateOrAddClassDetails,
        showEditClassPopup: showEditClassPopup,
        showAddClassPopup: showAddClassPopup,
        populateClassList: populateClassList,
        initializePopup: initializePopup
    };

})();