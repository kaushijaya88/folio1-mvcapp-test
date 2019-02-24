var Globals = (function () {

    //global function to call ajax posts
    var ajaxPost = function (url, data, successF, errorF) {
        $.ajax({
            type: "POST",
            url: url,
            data: data,
            dataType: "JSON",
            success: function (dto) {
                successF(dto);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                if (jqXHR != null) {
                    var code = jqXHR.status;
                }
            }
        })
    }

    //global function to call ajax gets
    var ajaxGet = function (url, data, successF, errorF) {
        $.ajax({
            type: "GET",
            url: url,
            data: data,
            dataType: "JSON",
            success: function (dto) {
                successF(dto);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                if (jqXHR != null) {
                    var code = jqXHR.status;
                }
            }
        })
    }

    var confirmDialog = function (message, yesF, noF, e) {
        $('<div></div>').appendTo('body')
            .html('<div><h6>' + message + '?</h6></div>')
            .dialog({
                modal: true, title: 'Delete message', zIndex: 10000, autoOpen: true,
                width: 'auto', resizable: false,
                buttons: {
                    Yes: function () {
                        $(this).dialog("close");
                        yesF(e);
                    },
                    No: function () {

                        $(this).dialog("close");
                        if (noF != null) {
                            noF();
                        }
                    }
                },
                close: function (event, ui) {
                    $(this).remove();
                }
            });
    };

    var clearInputControls = function (form) {
        $($('#dialogClass').find("input[type=text], input[type=number]")).val("");
        $($('#dialogStudent').find("input[type=text], input[type=number]")).val("");
        $('.classerror').text("");
    }

    return {
        ajaxGet: ajaxGet,
        ajaxPost: ajaxPost,
        confirmDialog: confirmDialog,
        clearInputControls: clearInputControls
    };

})();