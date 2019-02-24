$(function () {
    ClassManagement.initializePopup();
    StudentManagement.initializePopup();

    ClassManagement.populateClassList();
    StudentManagement.populateStudentList();

}).on('click', '#tblClassData tbody tr', function (event) {
    var data = $('#tblClassData').DataTable().row(this).data();
    ClassManagement.tableRowClick(data);
}).on('click', '.editClass', function (event) {
    event.stopPropagation();
    var data = $('#tblClassData').DataTable().row($(this).closest('tr')).data();
    ClassManagement.showEditClassPopup(data);
    
}).on('click', '#addClass', function (event) {
    event.stopPropagation();
    ClassManagement.showAddClassPopup();
}).on('click', '#saveClassButton', function (event) {
    event.stopPropagation();
    if ($('#dialogClass').valid()) {
        ClassManagement.updateOrAddClassDetails();
    }
    return false;
}).on('click', '.deleteClass', function (event) {
    event.stopPropagation();
    var data = $('#tblClassData').DataTable().row($(this).closest('tr')).data();
    Globals.confirmDialog('Are you sure you want to delete this class and its students',
        function () { ClassManagement.deleteClass(data.id) }, null, event);
}).on('click', '.editStudent', function (event) {
    event.stopPropagation();
    var data = $('#tblStudentData').DataTable().row($(this).closest('tr')).data();
    StudentManagement.showEditStudentPopup(data);
}).on('click', '#addStudent', function (event) {
    event.stopPropagation();
    StudentManagement.showAddStudentPopup();
}).on('click', '#saveStudentButton', function (event) {
    event.stopPropagation();
    if ($('#dialogStudent').valid()) {
        StudentManagement.updateOrAddStudentDetails();
    }
    return false;
}).on('click', '.deleteStudent', function (event) {
    event.stopPropagation();
    var data = $('#tblStudentData').DataTable().row($(this).closest('tr')).data();
    Globals.confirmDialog('Are you sure you want to delete this student',
        function () { StudentManagement.deleteStudent(data.id) }, null, event);
});