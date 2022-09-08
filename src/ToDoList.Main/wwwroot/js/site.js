function deleteToDo(i)
{
    $.ajax({
        url: 'Home/Delete',
        type: 'DELETE',
        data: {
        id: i
        },
        success: function () {
            window.location.reload();
        }
    });
}

function populateForm(i)
{
    $.ajax({
        url: 'Home/PopulateForm',
        type: 'GET',
        data: {
            id: i
        },
        dataType: 'json',
        success: function (response) {
            $("#ToDo_Name").val(response.name);
            $("#ToDo_Id").val(response.id);
            $("#form-button").val("Update ToDo");
            $("#form-action").attr("action", "/Home/Update");
        }
    });
}
