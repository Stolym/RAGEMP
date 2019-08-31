var data = {
    Debug: true,
    Value: [20, 50, 20, 50],
}

$("#ugly").click(function() {
   $(this).val($(this).val() == "0" ? "1" : "0"); 
});

$("#valid").click(function () {
    $("input").each(function (index) {
        if (index == 0)
            data.Debug = $(this).val() == "1" ? true : false;
        else
            data.Value[index - 1] = parseInt($(this).val());
    });
    GetFileBuffer();
    //mp.trigger("CEFDEBUGCOMMAND", JSON.stringify(data));
});


function GetFileBuffer() {
    
    var fileReader = new FileReader();
    fileReader.onload = function () {
        var data = fileReader.result;
        console.log(data);
    };
    fileReader.readAsDataURL($("#UploadFile").prop("files")[0]);
    
}