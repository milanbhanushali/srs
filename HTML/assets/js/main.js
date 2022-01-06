const navMenu = document.getElementById('nav-menu'),
toggleMenu = document.getElementById('toggle-menu'),
closeMenu = document.getElementById('close-menu')


toggleMenu.addEventListener('click',() => {
    navMenu.classList.toggle('custom-show')
})
closeMenu.addEventListener('click',() => {
    navMenu.classList.remove('custom-show')
})
