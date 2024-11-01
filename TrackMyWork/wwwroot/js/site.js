// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const hamBurger = document.getElementById('hamBurger');
const navMenu = document.getElementById('navMenu');
const closeNav = document.getElementById('closeNav');
const overlay = document.getElementById('overlay');
const body = document.querySelector('body');
const accordian = document.querySelector('#accordian');
const accordianPanel = document.querySelector("#panel");


hamBurger.addEventListener('click', () => {
    navMenu.style.transform = 'translateX(0)';
    body.classList.add('bodyFixed');
    overlay.classList.remove('hidden')

});
// defining close nav function
const closeMenu = () => {
    console.log('closenav called')
    navMenu.style.transform = 'translateX(100%)';
    body.classList.remove('bodyFixed');
    overlay.classList.add('hidden')
}

closeNav.addEventListener('click', closeMenu);
overlay.addEventListener('click', closeMenu)
accordian.addEventListener(
    "click", () => {
        panel.classList.toggle('display-hidden')
    }
)
