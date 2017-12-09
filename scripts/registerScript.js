/*var btnLogin = document.getElementById("Login");

btnLogin.onclick = function Reg() {
    var name = $("#User").val();
    var pass = $("#Pass").val();
    var verifiedPassword = $("#verifiedPassword").val();
    var mail = $("#Email").val();

    var encPass = encrypt(3333, pass);
}

function encrypt(key, value) {
    var result = "";
    for (i = 0; i < value.length; ++i) {
        result += String.fromCharCode(key[i % key.length] ^ value.charCodeAt(i));
    }
    return result;
}



function decrypt() {
    var result = "";
    for (i = 0; i < value.length; ++i) {
        result += String.fromCharCode(key[i % key.length] ^ value.charCodeAt(i));
    }
    return result;
}*/

$(document).ready(function () {
   $.validator.setDefaults({
        highlight: function (element) {
            $(element).closest('.form-group').addClass('has-error');
        },
            unhighlight: function (element) {
            $(element).closest('.form-group').removeClass('has-error');
        }
    });    
    

    /*$.validator.addMethod('strongPassword', function (value, element) {
        return this.optional(element) || (value.lenght >= 6 && /\d/.test(value) && /[a-z]/i.test(value));
    }, 'your password must be at least 6 characters long and contain at least one digit and one latter.')*/

    // validate signup form on keyup and submit
    $("#registerForm").validate({
        rules: {
            User: {
                required: true,
                minlength: 2
            },
            Pass: {
                required: true,
                minlength: 6
            },
            verifiedPassword: {
                required: true,
                minlength: 6,
                equalTo: "#Pass"
            },
            Email: {
                required: true,
                email: true
            },
        },
        messages: {
            User: {
                required: "Enter a username",
                minlength: jQuery.validator.format("Enter at least {0} characters"),
            },
            Pass: {
                required: "Provide a password",
                minlength: jQuery.validator.format("Enter at least {0} characters"),

            },
            verifiedPassword: {
                required: "Repeat your password",
                minlength: jQuery.validator.format("Enter at least {0} characters"),
                equalTo: "Enter the same password as above"
            },
            Email: {
                required: "Please enter a valid email address",
            },
        },

        /*
        // specifying a submitHandler prevents the default submit, good for the demo
        submitHandler: function () {
            event.preventDefault();
            alert("submitted!");

            alert("OK");
            var apiUrl = "api/Users";
            // Send an AJAX request
            var player = {
                UserName: $("#User").val(),
                pass: $("#Pass").val(),
                mail: $("#Email").val()
            };


            $.post(apiUrl, player).done(function (data) {

                if (data != null) {

                    alert(data);
                }
            });
        },*/

        success: function () {

            document.getElementById("Login").onclick = function sub() {
                event.preventDefault();
                alert("submitted!");

                alert("OK");
                var apiUrl = "../api/Users";
                // Send an AJAX request
                var player = {
                    UserName: $("#User").val(),
                    pass: $("#Pass").val(),
                    mail: $("#Email").val()
                };


                $.post(apiUrl, player).done(function (data) {

                    if (data != null) {

                        alert(data);
                        if (data == "Success") {
                            sessionStorage.setItem("Username", player.UserName);
                            window.location.href = "./menuPage.html";
                        }
                        else {
                            alert("Error Register");
                        }
                    }
                });
            }
           
        }
    });
    
});