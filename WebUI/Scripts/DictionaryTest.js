
GetDictionary();
function GetAllEntities() {
    jQuery.support.cors = true;
    var Dict = $('#sysDictList :selected').text();
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
    var Dict = $('#sysDictList :selected').text();
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
    var Dict = $('#sysDictList :selected').text();
    if(Dict == 'Region')
    {
        var entities = {
            Name: $('#txtaddName').val(),
            CountryID: $('#linked1').val()
        };
    } else
    if (Dict == 'District') {
        var entities = {
            Name: $('#txtaddName').val(),
            RegionID: $('#linked1').val()
        };
    } else
    if (Dict == 'City') {
        var entities = {
            Name: $('#txtaddName').val(),
            RegionID: $('#linked3').val(),
            DistrictID: $('#linked2').val(),
            CityTypeID: $('#linked1').val()
        };
    } else
    {
        var entities = {
            Name: $('#txtaddName').val()
        };
    }


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
    var Dict = $('#sysDictList :selected').text();
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
    $('#lblResult').show();
}

function ShowEntity(entity) {
    if (entity != null) {
        var strResult = "<table class='table table-hover'><th>ID</th><th>Name</th><th>LastUpdUS</th><th>LastUpdDT</th>";
        strResult += "<tr><td>" + entity.ID + "</td><td> " + entity.Name + "</td><td>" + entity.LastUpdUS + "</td><td>" + entity.LastUpdDT + "</td></tr>";
        strResult += "</table>";
        $("#divResult").html(strResult);
        $('#lblResult').show();
    }
    else {
        $("#divResult").html("No Results To Display");
    }
}

function GetDictionary() {
    jQuery.support.cors = true;
    $.ajax({
        type: "get",
        url: "http://localhost:3761/api/Dictionary",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        data: {},
        success: function (result) {
            $.each(result, function (i) {
                $('#sysDictList').append($('<option></option>').val(result[i].ID).html(result[i].Name));
            });
        },
        failure: function () {
            alert("Error");
        }
    });
}

function GetRelatedEntities(name, comp) {
    jQuery.support.cors = true;
    $.ajax({
        type: "get",
        url: "http://localhost:3761/api/" + name,
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        data: {},
        success: function (result) {
            $(comp).empty();
            $.each(result, function (i, result) {
                $(comp).append($('<option></option>').val(result.ID).html(result.Name));
            });
        },
        failure: function () {
            alert("Error");
        }
    });
}

function GetStructur() {
    jQuery.support.cors = true;
    var name = $('#sysDictList :selected').text();
    if (name == 'Region' || name == 'District') {
        // where exists 1 related objects
        if (name == 'Region')
            name = 'Country';
        else name = 'Region';
        $('#trLinked1').show();
        $('#lblLinked1').text(name + ':');
        GetRelatedEntities(name, '#linked1');
        $('#trLinked2').hide();
        $('#lblLinked2').empty();
        $('#linked2').empty();
        $('#trLinked3').hide();
        $('#lblLinked3').empty();
        $('#linked3').empty();
    }
    else
        if (name == 'City') {
            // where exists 3 related objects
            $('#trLinked1').show();
            $('#lblLinked1').text("Type:");
            GetRelatedEntities("CityType", '#linked1');

            $('#trLinked2').show();
            $('#lblLinked2').text("District:");
            GetRelatedEntities("District", '#linked2');

            $('#trLinked3').show();
            $('#lblLinked3').text("Region:");
            GetRelatedEntities("Region", '#linked3');
        }
        else {
            // clear and hide
            $('#trLinked1').hide();
            $('#lblLinked1').empty();
            $('#linked1').empty();
            $('#trLinked2').hide();
            $('#lblLinked2').empty();
            $('#linked2').empty();
            $('#trLinked3').hide();
            $('#lblLinked3').empty();
            $('#linked3').empty();
        }

};