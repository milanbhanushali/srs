

//#region This Jquery will check input field for postal code
$(document).ready(function () {
    $("#btnCheckPostalCode").click(function () {
        var inputVal = $("#txtPostalCode").val();
        var gfg = $.isNumeric(inputVal);
        if (inputVal.length == 0) {
            $("#error").text("Please enter postal code");
        }
        else if (!gfg)
            $("#error").text("Postal code should be in numbers");
    });

    function validateEmail($email) {
        var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
        return emailReg.test($email);
    }

    $("#btnLogin").click(function () {
        var emailAddress = $("#txtEmail").val();
        var loginPassword = $("#txtPassword").val();
        if (emailAddress.length == 0 && loginPassword.length == 0) {
            $("#loginError").text("Please enter email and password");
        }
        else if (emailAddress.length == 0) {
            $("#loginError").text("Please Enter Email Address");
        }
        else if (loginPassword.length == 0) {
            $("#loginError").text("Please Enter Password");
        }
        else if (!validateEmail(emailAddress))
            $("#loginError").text("Please Enter Valid Email Address");
    });

    $("#btnForgotForm").click(function () {
        var emailAddress = $("#txtForgottedEmail").val();
        var loginPassword = $("#txtForgottedPassword").val();
        var confirmPassword = $("#txtForgottedConfirmPassword").val();
        if (emailAddress.length == 0 && loginPassword.length == 0) {
            $("#errForgotEmailPassword").text("Please enter email and password");
        }
        else if (emailAddress.length == 0) {
            $("#errForgotEmailPassword").text("Please Enter Email Address");
        }
        else if (loginPassword.length == 0) {
            $("#errForgotEmailPassword").text("Please Enter Password");
        }
        else if (confirmPassword.length == 0) {
            $("#errForgotEmailPassword").text("Please Enter Confirm Password");
        }
        else if (!validateEmail(emailAddress)) {
            $("#errForgotEmailPassword").text("Please Enter Valid Email Address");
        }
        else if (loginPassword != confirmPassword) {
            $("#errForgotEmailPassword").text("Password & Confirm Password should be equal");
        }
            
    });

    $("#btnBookNow").on("click", function () {
        if ($("#userID").val() == "") {
            showLoginModel();
            return;
        }
    })

    function showLoginModel() {
        $('#LoginModel').modal('show');
    }


});
//#endregion


(function () {
    'use strict'

    var forms = document.querySelectorAll('.needs-validation')


    Array.prototype.slice.call(forms)
        .forEach(function (form) {
            form.addEventListener('submit', function (event) {
                if (!form.checkValidity()) {
                    event.preventDefault()
                    event.stopPropagation()
                }

                form.classList.add('was-validated')
            }, false)
        })
})()

const navMenu = document.getElementById('nav-menu'),
toggleMenu = document.getElementById('toggle-menu'),
closeMenu = document.getElementById('close-menu'),
btnBookNow = document.getElementById('btnBookNow'),
btnLogin = document.getElementById('btnLogin'),
btnBecomeHelper = document.getElementById('btnBecomeHelper')

toggleMenu.addEventListener('click',() => {
    navMenu.classList.toggle('custom-show')
    btnBookNow.classList.remove('custom-bg-green-btn')
    btnLogin.classList.remove('custom-bg-green-btn')
    btnBecomeHelper.classList.remove('custom-bg-green-btn')
})


closeMenu.addEventListener('click',() => {
    navMenu.classList.remove('custom-show')
})


$(function () {
    $(document).scroll(function () {
      var $nav = $(".navbar-fixed-top");
      var $logoimg = $(".custom-navbar-full-image-logo");
      var $activebtn = $(".border-btn");
      var $ulnavmargin = $(".custom-mobile-navbar");
      var $header = $("header");

      $nav.toggleClass('scrolled', $(this).scrollTop() > $nav.height());
      $logoimg.toggleClass('scrolled', $(this).scrollTop() > $nav.height());
      $activebtn.toggleClass('scrolled',$(this).scrollTop() > $nav.height());
      $ulnavmargin.toggleClass('scrolled',$(this).scrollTop() > $nav.height());
      $header.toggleClass('scrolled',$(this).scrollTop() > $nav.height());
    });
  });
