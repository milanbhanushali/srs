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


var header = document.getElementById('abc')

header.addEventListener('scroll',() =>{
    header.classList.add('bg-dark')
    header.classList.remove('bg-transparent')
})

console.log("hello peter");