const burgerIcon = document.querySelector('#burgerIcon');
const mainNavbar = document.querySelector('#mainNavbar');

burgerIcon.addEventListener('click', () => {
    mainNavbar.classList.toggle('is-active');
});

document.addEventListener('DOMContentLoaded', () => {
    (document.querySelectorAll('.notification .delete') || []).forEach(($delete) => {
        const $notification = $delete.parentNode;

        $delete.addEventListener('click', () => {
            $notification.parentNode.removeChild($notification);
        });
    });
});

document.addEventListener('DOMContentLoaded', () => {
    (document.querySelectorAll('.modal .modal-close') || []).forEach(($close) => {
        const $modal = $close.parentNode;

        $close.addEventListener('click', () => {
            $modal.classList.toggle('is-active');
        });
    });
});