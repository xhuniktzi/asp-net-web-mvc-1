const burgerIcon = document.querySelector('#burgerIcon');
const mainNavbar = document.querySelector('#mainNavbar');

burgerIcon.addEventListener('click', () => {
    mainNavbar.classList.toggle('is-active');
});