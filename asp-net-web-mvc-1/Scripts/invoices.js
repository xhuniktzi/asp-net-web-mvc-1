// DOM Elements
const btnModalClient = document.getElementById('btnModalClient');
const modalSelectClient = document.getElementById('modalSelectClient');
const btnSearchClientByName = document.getElementById('btnSearchClientByName');
const inputNameClient = document.getElementById('inputNameClient');
const tableClients = document.getElementById('tableClients');
const btnSearchClientByNit = document.getElementById('btnSearchClientByNit');
const inputNitClient = document.getElementById('inputNitClient');

const btnModalBranch = document.getElementById('btnModalBranch');
const modalSelectBranch = document.getElementById('modalSelectBranch');
const btnSearchBranchByName = document.getElementById('btnSearchBranchByName');
const inputNameBranch = document.getElementById('inputNameBranch');
const tableBranches = document.getElementById('tableBranches');

const btnModalProduct = document.getElementById('btnModalProduct');
const modalSelectProduct = document.getElementById('modalSelectProduct');
const btnSearchProductByName = document.getElementById('btnSearchProductByName');
const inputNameProduct = document.getElementById('inputNameProduct');
const tableProducts = document.getElementById('tableProducts');
const ProductCode = document.getElementById('ProductCode');
const ProductName = document.getElementById('ProductName');
const ProductPrice = document.getElementById('ProductPrice');
const btnAddProduct = document.getElementById('btnAddProduct');
const ProductQuantity = document.getElementById('ProductQuantity');

// global vars
const baseUrl = "http://localhost:5000";

// execute on startup
history.pushState(null, "", location.href.split("?")[0]);

// event listeners
btnModalClient.addEventListener('click', (e) => {
    e.preventDefault();
    modalSelectClient.classList.toggle('is-active');
});

btnModalBranch.addEventListener('click', (e) => {
    e.preventDefault();
    modalSelectBranch.classList.toggle('is-active');
});

btnModalProduct.addEventListener('click', (e) => {
    e.preventDefault();
    modalSelectProduct.classList.toggle('is-active');
});

btnSearchClientByNit.addEventListener('click', searchClients);
btnSearchClientByName.addEventListener('click', searchClients);

//btnSearchClientByName.addEventListener('click', () => {
//    tableClients.querySelectorAll('*').forEach(n => n.remove());
//    let url;

//    if (!inputNameClient.value) {
//        url = `${baseUrl}/clients/`;
//    } else {
//        url = `${baseUrl}/clients/findByName/${encodeURI(inputNameClient.value)}`;
//    }

//    fetch(url, {
//        method: 'GET'
//    })
//    .then((res) => {
//        if (res.ok) {
//            return res.json();
//        }
//    })
//    .then((res) => {
//        for (let e of res) {
//            const row = document.createElement('tr');
//            tableClients.appendChild(row);

//            const id = document.createElement('td');
//            id.classList.add('is-hidden');
//            id.innerText = e.client_Id;
//            row.appendChild(id);

//            const name = document.createElement('td');
//            name.innerText = e.name;
//            row.appendChild(name);

//            const nit = document.createElement('td');
//            nit.innerText = e.nit;
//            row.appendChild(nit);

//            row.addEventListener('click', selectClient);
//        }
//    })
//});

//btnSearchClientByNit.addEventListener('click', () => {
//    tableClients.querySelectorAll('*').forEach(n => n.remove());
//    let url;

//    if (!inputNitClient.value) {
//        url = `${baseUrl}/clients/`;
//    } else {
//        url = `${baseUrl}/clients/findByNIt/${encodeURI(inputNitClient.value)}`;
//    }

//    fetch(url, {
//        method: 'GET'
//    })
//    .then((res) => {
//        if (res.ok) {
//            return res.json();
//        }
//    })
//    .then((res) => {
//        for (let e of res) {
//            const row = document.createElement('tr');
//            tableClients.appendChild(row);

//            const id = document.createElement('td');
//            id.classList.add('is-hidden');
//            id.innerText = e.client_Id;
//            row.appendChild(id);

//            const name = document.createElement('td');
//            name.innerText = e.name;
//            row.appendChild(name);

//            const nit = document.createElement('td');
//            nit.innerText = e.nit;
//            row.appendChild(nit);

//            row.addEventListener('click', selectClient);
//        }
//    })
//});

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

btnSearchProductByName.addEventListener('click', (e) => {
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

            const price = document.createElement('td');
            price.classList.add('has-text-right');
            price.innerText = new Intl.NumberFormat('es-GT', {style: 'currency', currency: 'GTQ'}).format(e.price);
            row.appendChild(price);

            row.addEventListener('click', selectProduct);
        }
    })
});

btnAddProduct.addEventListener('click', (e) => {
    e.preventDefault();
    const quantity = parseInt(ProductQuantity.value);
    const code = ProductCode.value;
    location.replace(`?quantity=${quantity}&productCode=${encodeURI(code)}`);
});

//functions
function selectClient() {
    location.replace(`?clientId=${parseInt(this.children[0].innerText)}`);
}

function selectBranch() {
    location.replace(`?branchId=${parseInt(this.children[0].innerText)}`);
}

function selectProduct() {
    ProductCode.value = this.children[1].innerText
    ProductName.value = this.children[2].innerText
    ProductPrice.value = this.children[3].innerText
    modalSelectProduct.classList.toggle('is-active');
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