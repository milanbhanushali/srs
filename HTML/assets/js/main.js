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


// var header = document.getElementById('abc')

// header.addEventListener('scroll',() =>{
//     console.log("hello");
//     header.classList.add('bg-dark')
//     header.classList.remove('bg-transparent')
// })

jQuery(document).click(function() {

});

jQuery('#nav-menu').click(function(event) {
    jQuery(".custom-mobile-navbar").collapse('hide');
    event.stopPropagation();
});
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

console.log("hello peter");