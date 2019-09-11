var fake_account = [
    {
        name: "Pauline",
        lastname: "Dust",
        sex: "Femme",
        birthday: "21/04/1993",
        hashcode: 0,
        solde: 2349,
        type: 0,
        history: [
            {
                lieu: "MazeBank",
                object: "Vous avez acheter 29 bouteilles de coca-cola pour 239 $",
                tick: 0,
                gain: -239,
            }
        ],
        card: [
            {
                name: "Pauline",
                lastname: "Dust",
                hashcode: 0,
                secretcode: "3021",
                type: 0,
            },
            {
                name: "Pauline",
                lastname: "Dust",
                hashcode: 1,
                secretcode: "6208",
                type: 0,
            }
        ]
    },
    {
        name: "Gouvernement",
        lastname: "",
        sex: "",
        birthday: "11/09/1977",
        hashcode: 1,
        solde: 20000,
        type: 0,
        history: [
            {
                lieu: "Entreprise",
                object: "Vous avez acheter 1 tenue de service pour 1100 $",
                tick: 0,
                gain: -1100,
            },
            {
                lieu: "Entreprise",
                object: "Vous avez vendu 20 caisses de marchandises pour 11220 $",
                tick: 0,
                gain: 11220,
            }
        ]
    },
]



function ClearAccountListBank() {
    $(".listaccount").each(function (index) {
        if ($(this).data("id") == 3 || $(this).data("id") == 4)
            $(this).children(".account").remove();
    });

}


AccountListBankSearching("");

function AddAccountListBank(json) {
    var data = JSON.parse(json);

    $(".listaccount").each(function (index) {
        if ($(this).data("id") == 3) {
            for (var i = 0; i < data.length; i++)
                $(this).append("<div class='account'><p class='owner'>Compte en banque de "+data[i].name+" "+data[i].lastname+"</p><p class='id_account'>"+data[i].hashcode+"</p><button data-id='7' data-hashcode='"+data[i].hashcode+"' class='open'>Ouvrir</button></div>");
        }
        if ($(this).data("id") == 4) {
            for (var i = 0; i < data.length; i++)
                $(this).append("<div class='account'><p class='owner'>Compte en banque de "+data[i].name+" "+data[i].lastname+"</p><p class='id_account'>"+data[i].hashcode+"</p><button data-id='10' data-hashcode='"+data[i].hashcode+"' class='open'>Ouvrir</button></div>");
        }
    });
}

function AccountListBankSearching(val) {
    ClearAccountListBank();
    if (val == "")
        AddAccountListBank(JSON.stringify(fake_account));
    else
        AddAccountListBank(JSON.stringify(SortAccountListBank(JSON.stringify(fake_account), val)))
    OPENCLICKEVENT();
}

function OPENCLICKEVENT() {
    $(".open").each(function (index) {
        if ($(this).data("id") != 9) {
            $(this).unbind("click");
            $(this).click(function () {
                SetAllMenu(false);
                switch ($(this).data("id")) {
                    case 0:
                        menu[3] = true;
                        break;
                    case 1:
                        menu[3] = true;
                        break;
                    case 2:
                        menu[1] = true;
                        break;
                    case 3:
                        menu[2] = true;
                        break;
                    case 4:
                        menu[8] = true;
                        break;
                    case 5:
                        menu[9] = true;
                        break;
                    case 7:
                        menu[7] = true;
                        UPDATE_ACCOUNT_PAGE($(this).data("hashcode"));
                        break;
                    case 10:
                        menu[10] = true;
                        UPDATE_HISTORY_PAGE($(this).data("hashcode"));
                        break;
                }
                UpdateMenu();
            });
        }
    });
}


var current_data_account = null;

function UPDATE_ACCOUNT_PAGE(hashcode)
{
    var data = GET_ACCOUNT_BY_HASHCODE(hashcode);

    if (data == null)
        return;
    $("#i0").val(data.name);
    $("#i1").val(data.lastname);
    $("#i2").val(data.birthday);
    $("#i3").val(data.sex);
    current_data_account = data;
    $(".confirmaddaccount").text("Valider");
}

function GET_ACCOUNT_BY_HASHCODE(hashcode)
{
    for (var i = 0; i < fake_account.length; i++) {
        if (fake_account[i].hashcode == hashcode)
            return (fake_account[i]);
    }
    return null;
}

function UPDATE_HISTORY_PAGE(hashcode) {
    var data = GET_ACCOUNT_BY_HASHCODE(hashcode);

    if (data == null)
        return;
    CLEAR_HISTORY_LIST();
    $("#transactsolde").text(data.solde+" $");
    ADD_HISTORY_LIST(data);
}

function ADD_HISTORY_LIST(data)
{
    for (var i = 0; i < data.history.length; i++) {
        if (data.history[i].gain > 0)
            $(".historyspace").append("<div class='transacttest'><div class='transactionhistoryspace'><p class='transactionhistoryname' style='position: absolute; float: left;'>"+data.name+" "+data.lastname+"</p><p class='transactionhistoryname' style='position: absolute; left: 200px; float: left;'>20/08/2019 08:47</p><p class='transactionhistoryname' style='position: absolute; float: left; left: 430px; color: #52c495'>"+data.history[i].gain+" $</p></div><p class='transactobject' style='float: left;'>Lieux :</p><p class='transactobject' style='color: #FF8040'>"+data.history[i].lieu+"</p><p class='transactobject'>Object :</p><p class='transactobjectdesc'>"+data.history[i].object+"</p></div>");
        else
            $(".historyspace").append("<div class='transacttest'><div class='transactionhistoryspace'><p class='transactionhistoryname' style='position: absolute; float: left;'>"+data.name+" "+data.lastname+"</p><p class='transactionhistoryname' style='position: absolute; left: 200px; float: left;'>20/08/2019 08:47</p><p class='transactionhistoryname' style='position: absolute; float: left; left: 430px; color: #FF0000'>"+data.history[i].gain+" $</p></div><p class='transactobject' style='float: left;'>Lieux :</p><p class='transactobject' style='color: #FF8040'>"+data.history[i].lieu+"</p><p class='transactobject'>Object :</p><p class='transactobjectdesc'>"+data.history[i].object+"</p></div>");
    }
}

function CLEAR_HISTORY_LIST() {
    $(".historyspace").children(".transacttest").remove();
}


function STRCMP(str_a, str_b)
{
    var value = 0;
    for (var i = 0; i < str_b.length; i++) {
        for (var j = 0; j < str_a.length; j++) {
            value += str_b.toLowerCase().charCodeAt(i) - str_a.toLowerCase().charCodeAt(j);
        }
    }
    console.log(str_a.toLowerCase());
    console.log(str_b.toLowerCase());
    console.log(value);
    return value;
}

function SortAccountListBank(json, val)
{
    var data = JSON.parse(json);
    var sort = [];

    for (var i = 0; i < data.length; i++) {
        if (STRCMP(data[i].name, val) == 0)
            sort.push(data[i]);
    }
    return sort;
}


function GET_INDEX_BY_HASHCODE_ACCOUNT(hashcode)
{
    for (var i = 0; i < fake_account.length; i++) {
        if (fake_account[i].hashcode == hashcode)
            return i;
    }
    return -1;
}

function UpdateAccount() {

    if ($("#i0").val().length == 0 || $("#i1").val().length == 0 || $("#i2").val().length == 0 || $("#i3").val().length == 0)
    {
        alert("You cannot create account because field is not completed");
        return;
    }
    current_data_account.name = $("#i0").val();
    current_data_account.lastname = $("#i1").val();
    current_data_account.birthday = $("#i2").val();
    current_data_account.sex = $("#i3").val();
    data_tmp[GET_INDEX_BY_HASHCODE_ACCOUNT(current_data_account.hashcode)] = current_data_account;
    AccountListBankSearching("");
    SetAllMenu(false);
    UpdateMenu();
}

function CreateAccount() {
    var data = {
        name: "",
        lastname: "",
        sex: "",
        birthday: "",
        hashcode: fake_account.length,
        solde: 0,
        type: 0,
        history: [
        ],
        card: [
        ]
    }
    
    if ($("#i0").val().length == 0 || $("#i1").val().length == 0 || $("#i2").val().length == 0 || $("#i3").val().length == 0)
    {
        alert("You cannot create account because field is not completed");
        return;
    }
    data.name = $("#i0").val();
    data.lastname = $("#i1").val();
    data.birthday = $("#i2").val();
    data.sex = $("#i3").val();
    fake_account.push(data);
    AccountListBankSearching("");
    SetAllMenu(false);
    UpdateMenu();
}

function ResetAccountAddPage() {
    $(".input_add").each(function (index) {
        $(this).val("");
    });
    $(".confirmaddaccount").text("Confirmer");
    $(".listcardbancaire").children(".cardbancaire").remove();
}