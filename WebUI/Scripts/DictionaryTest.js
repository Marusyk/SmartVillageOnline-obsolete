
function GetAllEntities() {
    jQuery.support.cors = true;
    var Dict = $('#txtDictName').val();
    $.ajax({
        url: 'http://localhost:3761/api/' + Dict,
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            WriteResponse(data);
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}

function GetEntity() {
    jQuery.support.cors = true;
    var id = $('#txtId').val();
    var Dict = $('#txtDictName').val();
    $.ajax({
        url: 'http://localhost:3761/api/' + Dict + '/' + id,
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            ShowEntity(data);
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}

function AddEntity() {
    jQuery.support.cors = true;
    var Dict = $('#txtDictName').val();
    var entities = {
        Name: $('#txtaddName').val(),
        LastUpdUS: $('#txtaddUs').val(),
        LastUpdDT: $('#txtaddDtb').val(),
        CountryID: $('#StudentDropDown').val()
    };

    $.ajax({
        url: 'http://localhost:3761/api/' + Dict,
        type: 'POST',
        data: JSON.stringify(entities),
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            WriteResponse(data);
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}

function DeleteEntity() {
    jQuery.support.cors = true;
    var Dict = $('#txtDictName').val();
    var id = $('#txtdelId').val()

    $.ajax({
        url: 'http://localhost:3761/api/' + Dict + '/' + id,
        type: 'DELETE',
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            WriteResponse(data);
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}


function WriteResponse(entities) {
    var strResult = "<table class='table table-hover'><th>ID</th><th>Name</th><th>LastUpdUS</th><th>LastUpdDT</th>";
    $.each(entities, function (index, entity) {
        strResult += "<tr><td>" + entity.ID + "</td><td> " + entity.Name + "</td><td>" + entity.LastUpdUS + "</td><td>" + entity.LastUpdDT + "</td></tr>";
    });
    strResult += "</table>";
    $("#divResult").html(strResult);
}

function ShowEntity(entity) {
    if (entity != null) {
        var strResult = "<table class='table table-hover'><th>ID</th><th>Name</th><th>LastUpdUS</th><th>LastUpdDT</th>";
        strResult += "<tr><td>" + entity.ID + "</td><td> " + entity.Name + "</td><td>" + entity.LastUpdUS + "</td><td>" + entity.LastUpdDT + "</td></tr>";
        strResult += "</table>";
        $("#divResult").html(strResult);
    }
    else {
        $("#divResult").html("No Results To Display");
    }
}