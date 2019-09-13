
var list_contact = [  ];

var data_a = {
    Name: "Maupassant",
    Number: "223111222",
};

var data_b = {
    Name: "Bruce Bader",
    Number: "225511222",
};

var data_c = {
    Name: "Ak Scotch",
    Number: "223111882",
};

var data_d = {
    Name: "Zino RPZ",
    Number: "223111332",
};


list_contact.push(data_a);
list_contact.push(data_b);
list_contact.push(data_c);
list_contact.push(data_d);

$(() => {
    CreateAlphabetsort();
    UpdateListContact();
})


function CreateAlphabetsort() {
    for (var i = 0; i < 26; i++) {
        $(".listcontact").append("<div class='lettercontact'><p class='lcontact'>"+String.fromCharCode(65+i)+"</p></div>");
    }
}

function UpdateListContact() {
    
    for (var i = 0; i < list_contact.length; i++) {
        $(".lettercontact").each(function (index) {
           if (list_contact[i].Name.charCodeAt(0) < 65+index+1 && list_contact[i].Name.charCodeAt(0) >= 65+index) {
               $(this).after("<div class='ccontact'><p class='cname'>"+list_contact[i].Name+"</p><button class='cbutton'>C</button><button class='cbutton'>M</button><button class='cbutton'>+</button></div>");

           }

        });
    }
}