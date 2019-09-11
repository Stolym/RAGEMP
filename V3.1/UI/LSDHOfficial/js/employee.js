var data_tmp = [
    {
        name: "Jade",
        lastname: "Older",
        hashcode: 0,
        permission: 2,
        grade: "Valid",
    },
]

var current_data = null;

$(() => {
    $(".add_button").each(function (index) {
        if ($(this).attr("id") == null)
            return;
        if ($(this).attr("id") == "a0") {
            $(this).unbind("click");
            $(this).click(function () {
                if ($(this).text() == "Ajouter")
                    ADD_NEW_EMPLOYEE();
                else if ($(this).text() == "Valider")
                    VALID_EMPLOYEE(current_data);
            });
        }
        
    })
})

function VALID_EMPLOYEE(employee)
{
    $(".input_add").each(function (index) {
        switch ($(this).data("id")) {
            case 0:
                employee.name = $(this).val();
                break;
            case 1:
                employee.lastname = $(this).val();
                break;
            case 2:
                employee.permission = parseInt($(this).val());
                break;
            case 3:
                employee.grade = $(this).val();
                break;
        }
    });
    if (CHECK_IF_DATA_IS_GOOD(employee) == false)
        return;
    data_tmp[GET_INDEX_BY_HASHCODE(employee.hashcode)] = employee;
    UPDATE_EMPLOYEE_LIST(JSON.stringify(data_tmp));
    SetAllMenu(false);
    UpdateMenu();
}

function GET_INDEX_BY_HASHCODE(hashcode)
{
    for (var i = 0; i < data_tmp.length; i++) {
        if (data_tmp[i].hashcode == hashcode)
            return i;
    }
    return -1;
}

function CLEAR_EMPLOYEE_PAGE() {
    $(".input_add").val("");
}

function CLEAR_EMPLOYEE_LIST() {
    $(".listaccount").each(function (index) {
        if ($(this).data("id") == 6)
            $(this).children(".account").remove();
    })
}


function ADD_NEW_EMPLOYEE() {
    var employee = {
        name: "",
        lastname: "",
        hashcode: 0,
        permission: 0,
        grade: "",
    };

    employee.hashcode = data_tmp.length;
    $(".input_add").each(function (index) {
        switch ($(this).data("id")) {
            case 0:
                employee.name = $(this).val();
                break;
            case 1:
                employee.lastname = $(this).val();
                break;
            case 2:
                employee.permission = parseInt($(this).val());
                break;
            case 3:
                employee.grade = $(this).val();
                break;
        }
    });
    if (CHECK_IF_DATA_IS_GOOD(employee) == false)
        return;
    data_tmp.push(employee);
    UPDATE_EMPLOYEE_LIST(JSON.stringify(data_tmp));
    SetAllMenu(false);
    UpdateMenu();
}

var grade_list = [
    "Test",
    "Valid",
];

function CHECK_GRADE_BY_LIST(grade) {
    for (var i = 0; i < grade_list.length; i++) {
        if (grade_list[i] == grade)
            return true;
    }
    return false;
}

function CHECK_IF_DATA_IS_GOOD(employee) {
    console.log(employee);
    if (employee.name.length == 0 || employee.lastname.length == 0 || employee.grade.length == 0 || CHECK_GRADE_BY_LIST(employee.grade) == false) {
        alert("Input not good");
        return false;
    }
    return true;
}

UPDATE_EMPLOYEE_LIST(JSON.stringify(data_tmp));

function UPDATE_EMPLOYEE_LIST(json) {
    var data = JSON.parse(json);

    CLEAR_EMPLOYEE_LIST();
    if (data == null)
        return;
    for (var i = 0; i < data.length; i++) {
        ADD_EMPLOYEE_LIST(data[i]);    
    }
    ADD_EVENT_EMPLOYEE_LIST();
}

function UPDATE_EMPLOYEE_LIST_SORTED(json, val)
{
    var data = JSON.parse(json);
    var sort = []

    for (var i = 0; i < data.length; i++) {
        if (STRCMP(data[i].name, val) == 0)
            sort.push(data[i]);
    }
    CLEAR_EMPLOYEE_LIST();
    for (var i = 0; i < sort.length; i++) {
        ADD_EMPLOYEE_LIST(sort[i]);    
    }
    ADD_EVENT_EMPLOYEE_LIST();
}

function ADD_EVENT_EMPLOYEE_LIST() {
    $(".open").each(function (index) {
        if ($(this).data("id") == 9) {
            $(this).unbind("click");
            $(this).click(function () {
                    console.log($(this).data("id"));
                    UPDATEMENUINDEX($(this).data("id"));
                    UPDATE_EMPLOYEE_PAGE($(this).parent(".account").data("json"));
            });
        }
    });
}

function UPDATE_EMPLOYEE_PAGE(data)
{
    $("#a0").text("Valider");
    $(".input_add").each(function (index) {
        switch ($(this).data("id")) {
            case 0:
            $(this).val(data.name);
            break;
            case 1:
            $(this).val(data.lastname);
            break;
            case 2:
            $(this).val(data.permission);
            break;
            case 3:
            $(this).val(data.grade);
            break;
        }
    });
    current_data = data;
}

function ADD_EMPLOYEE_LIST(data)
{
    $(".listaccount").each(function (index) {
        if ($(this).data("id") == 6) {
            $(this).append("<div class='account'><p class='owner'>Owner "+data.lastname+" "+data.name+"</p><p class='id_account'>"+data.hashcode+"</p><button data-id='9' class='open'>Ouvrir</button></div>");
            $(".account").last().data("json", data);
        }
    });
}