// DOM objects
const btnSelectClient = document.getElementById('BtnSelectClient');
const modalClient = document.getElementById('ModalClient');

const btnSelectBranch = document.getElementById('BtnSelectBranch');
const modalBranch = document.getElementById('ModalBranch');

const btnSelectProduct = document.getElementById('BtnSelectProduct');
const modalProduct = document.getElementById('ModalProduct');

const clientName = document.getElementById('ClientName');
const clientNit = document.getElementById('ClientNit');

// Event Listeners
btnSelectClient.addEventListener('click', () => {
    modalClient.classList.toggle('is-active');
});

btnSelectBranch.addEventListener('click', () => {
    modalBranch.classList.toggle('is-active');
});

btnSelectProduct.addEventListener('click', () => {
    modalProduct.classList.toggle('is-active');
});
