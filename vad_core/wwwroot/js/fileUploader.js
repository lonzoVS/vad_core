function uploadFiles(inputId) {
    var input = document.getElementById(inputId);
    var files = input.files;
    var formData = new FormData();

    formData.append("files", files[0]);

    var fileExtensionIsValid = getExtension(input.value)
    if (fileExtensionIsValid === false) {
        //add some fancy-shmancy control instead of alert; 
        alert("File extension is not valid!");
        return false;
    }

    $.ajax(
        {
            url: "/uploader",
            data: formData,
            processData: false,
            contentType: false,
            type: "POST",
            success: function (result) {
                if (result.status === "success") {
                    console.log(result.filePath);
                    $.ajax({
                        url: "/audioprocess/Process",
                        type: "POST",
                        data: JSON.stringify(result.filePath),
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (result) {
                            if (result.status === "error")
                            {
                                alert("File extension is not valid!");
                            }
                        },
                        error: function () {
                            alert('error');
                        }
                    });
                }


            }
        }
    );
}

function getExtension(filename)
{
    var re = /(?:\.([^.]+))?$/;
    var ext = re.exec(filename)[1];
    if (ext === "wav" || ext === "mp3")
        return true;
    else
        return false;
}

