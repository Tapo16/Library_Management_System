// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

const { type } = require("jquery");

// Write your JavaScript code.

function DataValid() { 

    var BookName = document.getElementById("BookName").value;
    var AuthorName = document.getElementById("AuthorName").value;
    var PublisherName = document.getElementById("PublisherName").value;
    var Dop = document.getElementById("Dop").value;
    var Stock = document.getElementById("Stock").value;
    var Cid = document.getElementById("Cid").value;
    var BookFile = document.getElementById("BookFile").value;

    if (BookName === "" || AuthorName === "" || PublisherName === "" || Dop === "" || Stock === "" || Cid === "" || BookFile === "") {
        alert("All Fields are mandatory");
        return false;
    }

    if (!(BookName >= "A" && BookName <= "Z") || (BookName >= "a" && BookName <= "z")) {
        alert("BookName should be start with letters");
        return false;
    }

    if (!(PublisherName >= "A" && PublisherName <= "Z") || (PublisherName >= "a" && PublisherName <= "z")) {
        alert("PublisherName should be start with letters");
        return false;
    }

    if (!(Stock >= 0 && Stock <= 50)) {
        alert("Stock should be start with 0 - 50");
        return false;
    }

    alert("Form Submitted Successfully");
    return true;
}


function RegPwd() { 

    var name = document.getElementById("name").value;
    var male = document.getElementById("male");
    var female = document.getElementById("female");
    var email = document.getElementById("email").value;
    var password = document.getElementById("password").value;
    var retypepaasword = document.getElementById("retypepaasword").value;

    var dob = document.getElementById("dob").value;
    var securityquestion = document.getElementById("securityquestion").value;
    var securityans = document.getElementById("securityans").value;

    if (name === "" || email === "" || password === "" || dob === "" || securityquestion === "" || securityans === "") {
        alert("all fields are mandatory");
        return false;
    }

    if (!((typeof(name) === "string") || (name >= "A" && name <= "Z") || (name >= 'a' && name <= 'z') || (name === ""))) {
        alert("Name should be in letters and string format");
        return false;
    }


    const Emailregex = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;

    var firstChar = email[0];

    if (!((firstChar >= "A" && firstChar <= "Z") || (firstChar >= "a" && firstChar <= "z"))) { 
        alert("Email should start with letters");
        return false;
    }

    if (!(Emailregex.test(email))){
        alert("Email should be in these format -- test@example.com");
        return false;
    }


    var PasswordRegex = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()_+=[\]{};':"\\|,.<>/?]).{8,}$/;

    if (!(PasswordRegex.test(password))) { 
        alert("Password must be at least 8 characters long and include one uppercase letter, one lowercase letter, one number, and one special character.")
        return false;
    }

    if (retypepaasword !== password) {
        alert("Password and RetypePassword should be same");
        return false;
    }

    if (!((typeof (securityans) === "string") || (securityans >= "A" && securityans <= "Z") || (securityans >= "a" && securityans <= "z"))){
        alert("Security Answers should be in string format and in letters");
        return false;
    }

    if ((male.checked == false) && (female.checked == false)) { 
        alert("Please select your gender");
        return false;
    }


    alert("Registration submitted");
    return true;
}



function ForgetPwd() { 

    var email = document.getElementById("Email").value;
    var password = document.getElementById("Password").value;
    var retypepaasword = document.getElementById("ReTypePaasword").value;
    var SecurityQuestion = document.getElementById("SecurityQuestion").value;
    var SecurityAns = document.getElementById("SecurityAns").value;


    if (email === "" || password === "" || retypepaasword === "" || SecurityQuestion === "" || SecurityAns === "") {
        alert("All fields are mandatory");
        return false;
    }

    const Emailregex = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;

    var firstChar = email[0];

    if (!((firstChar >= "A" && firstChar <= "Z") || (firstChar >= "a" && firstChar <= "z"))) {
        alert("Email should start with letters");
        return false;
    }

    if (!(Emailregex.test(email))) {
        alert("Email should be in these format -- test@example.com");
        return false;
    }


    var PasswordRegex = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()_+=[\]{};':"\\|,.<>/?]).{8,}$/;

    if (!(PasswordRegex.test(password))) {
        alert("Password must be at least 8 characters long and include one uppercase letter, one lowercase letter, one number, and one special character.")
        return false;
    }

    if (retypepaasword !== password) {
        alert("Password and RetypePassword should be same");
        return false;
    }

    if (!((typeof (securityans) === "string") || (securityans >= "A" && securityans <= "Z") || (securityans >= "a" && securityans <= "z"))) {
        alert("Security Answers should be in string format and in letters");
        return false;
    }


    alert(" Password Reset Success");
    return true;
}