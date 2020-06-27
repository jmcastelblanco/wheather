$(document).ready(function () {

    $("#DepartmentID").change(function () {
        $("#CityID").empty();
        $("#CityID").append('<option value="0">[Seleccione una ciudad...]</option>');
        $.ajax({
            type: 'POST',
            url: Url,
            dataType: 'json',
            data: { DepartmentID: $("#DepartmentID").val() },
            success: function (data) {
                $.each(data, function (i, data) {
                    $("#CityID").append('<option value="'
                        + data.CityID + '">'
                        + data.Name + '</option>');
                });
            },
            error: function (ex) {
                alert('Fallo la carga de ciudades.' + ex + Url);
            }
        });
        return false;
    })

    $("#CountryID").change(function () {
        $("#DepartmentID").empty();
        $("#DepartmentID").append('<option value="0">[Seleccione un departamento...]</option>');
        $.ajax({
            type: 'POST',
            url: Url2,
            dataType: 'json',
            data: { CountryID: $("#CountryID").val() },
            success: function (data3) {
                $.each(data3, function (i, data3) {
                    $("#DepartmentID").append('<option value="'
                        + data3.DepartmentID + '">'
                        + data3.Name + '</option>');
                });
            },
            error: function (ex) {
                alert('Fallo la carga de departamentos.' + ex);
            }
        });
        return false;
    })
    
});