// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const hamBurger = document.getElementById('hamBurger');
const navMenu = document.getElementById('navMenu');
const closeNav = document.getElementById('closeNav');

hamBurger.addEventListener('click', () => {
    navMenu.style.transform = 'translateX(0)';
});

closeNav.addEventListener('click', () => {
    navMenu.style.transform = 'translateX(100%)';
});