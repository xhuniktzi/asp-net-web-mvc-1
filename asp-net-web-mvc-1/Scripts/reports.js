// DOM Elements
const btnModalClient = document.getElementById('btnModalClient');
const modalSelectClient = document.getElementById('modalSelectClient');
const btnSearchClientByName = document.getElementById('btnSearchClientByName');
const inputNameClient = document.getElementById('inputNameClient');
const tableClients = document.getElementById('tableClients');
const hideClientId = document.getElementById('hideClientId');
const ClientName = document.getElementById('ClientName');
const ClientNit = document.getElementById('ClientNit');
const btnSearchClientByNit = document.getElementById('btnSearchClientByNit');
const inputNitClient = document.getElementById('inputNitClient');

const btnModalProduct = document.getElementById('btnModalProduct');
const modalSelectProduct = document.getElementById('modalSelectProduct');
const btnSearchProductByName = document.getElementById('btnSearchProductByName');
const inputNameProduct = document.getElementById('inputNameProduct');
const tableProducts = document.getElementById('tableProducts');
const hideProductId = document.getElementById('hideProductId');
const ProductCode = document.getElementById('ProductCode');
const ProductName = document.getElementById('ProductName');

const btnModalBranch = document.getElementById('btnModalBranch');
const modalSelectBranch = document.getElementById('modalSelectBranch');
const btnSearchBranchByName = document.getElementById('btnSearchBranchByName');
const inputNameBranch = document.getElementById('inputNameBranch');
const tableBranches = document.getElementById('tableBranches');
const hideBranchId = document.getElementById('hideBranchId');
const BranchName = document.getElementById('BranchName');
const BranchDirection = document.getElementById('BranchDirection');

// global vars
const baseUrl = "http://localhost:5000";

// event listeners
btnModalClient.addEventListener('click', (e) => {
    e.preventDefault();
    modalSelectClient.classList.toggle('is-active');
});

btnModalProduct.addEventListener('click', (e) => {
    e.preventDefault();
    modalSelectProduct.classList.toggle('is-active');
});

btnModalBranch.addEventListener('click', (e) => {
    e.preventDefault();
    modalSelectBranch.classList.toggle('is-active');
});

btnSearchClientByNit.addEventListener('click', searchClients);
btnSearchClientByName.addEventListener('click', searchClients);

btnSearchProductByName.addEventListener('click', () => {
    tableProducts.querySelectorAll('*').forEach(n => n.remove());
    let url;

    if (!inputNameProduct.value) {
        url = `${baseUrl}/products/`;
    } else {
        url = `${baseUrl}/products/findByName/${encodeURI(inputNameProduct.value)}`;
    }

    fetch(url, {
        method: 'GET'
    })
    .then((res) => {
        if (res.ok) {
            return res.json();
        }
    })
    .then((res) => {
        for (let e of res) {
            const row = document.createElement('tr');
            tableProducts.appendChild(row);

            const id = document.createElement('td');
            id.classList.add('is-hidden');
            id.innerText = e.product_Id;
            row.appendChild(id);

            const code = document.createElement('td');
            code.innerText = e.code;
            row.appendChild(code);

            const name = document.createElement('td');
            name.innerText = e.name;
            row.appendChild(name);

            row.addEventListener('click', selectProduct);
        }
    })
});

btnSearchBranchByName.addEventListener('click', () => {
    tableBranches.querySelectorAll('*').forEach(n => n.remove());
    let url;

    if (!inputNameBranch.value) {
        url = `${baseUrl}/branches/`;
    } else {
        url = `${baseUrl}/branches/findByName/${encodeURI(inputNameBranch.value)}`;
    }

    fetch(url, {
        method: 'GET'
    })
    .then((res) => {
        if (res.ok) {
            return res.json();
        }
    })
    .then((res) => {
        for (let e of res) {
            const row = document.createElement('tr');
            tableBranches.appendChild(row);

            const id = document.createElement('td');
            id.classList.add('is-hidden');
            id.innerText = e.branch_Id;
            row.appendChild(id);

            const name = document.createElement('td');
            name.innerText = e.name;
            row.appendChild(name);

            const direction = document.createElement('td');
            direction.innerText = e.direction;
            row.appendChild(direction);

            row.addEventListener('click', selectBranch);
        }
    })
});

//functions
function selectClient() {
    hideClientId.value = parseInt(this.children[0].innerText);
    ClientName.value = this.children[1].innerText
    ClientNit.value = this.children[2].innerText
    modalSelectClient.classList.toggle('is-active');
}

function selectProduct() {
    hideProductId.value = parseInt(this.children[0].innerText);
    ProductCode.value = this.children[1].innerText
    ProductName.value = this.children[2].innerText
    modalSelectProduct.classList.toggle('is-active');
}

function selectBranch() {
    hideBranchId.value = parseInt(this.children[0].innerText);
    BranchName.value = this.children[1].innerText
    BranchDirection.value = this.children[2].innerText
    modalSelectBranch.classList.toggle('is-active');
}

function searchClients() {
    tableClients.querySelectorAll('*').forEach(n => n.remove());
    const name = inputNameClient.value;
    const nit = inputNitClient.value;
    const url = `${baseUrl}/clients/findByNameAndNit?name=${name}&nit=${nit}`;

    fetch(url, {
        method: 'GET'
    })
    .then((res) => {
        if (res.ok) {
            return res.json();
        }
    })
    .then((res) => {
        for (let e of res) {
            const row = document.createElement('tr');
            tableClients.appendChild(row);

            const id = document.createElement('td');
            id.classList.add('is-hidden');
            id.innerText = e.client_Id;
            row.appendChild(id);

            const name = document.createElement('td');
            name.innerText = e.name;
            row.appendChild(name);

            const nit = document.createElement('td');
            nit.innerText = e.nit;
            row.appendChild(nit);

            row.addEventListener('click', selectClient);
        }
    })
}