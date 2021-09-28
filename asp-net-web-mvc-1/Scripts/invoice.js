// DOM Elements
const btnModalClient = document.getElementById('btnModalClient');
const modalSelectClient = document.getElementById('modalSelectClient');
const btnSearchClientByName = document.getElementById('btnSearchClientByName');
const inputNameClient = document.getElementById('inputNameClient');
const tableClients = document.getElementById('tableClients');
const hideClientId = document.getElementById('hideClientId');
const ClientName = document.getElementById('ClientName');
const ClientNit = document.getElementById('ClientNit');
// global vars
const baseUrl = "http://localhost:5000";

// event listeners
btnModalClient.addEventListener('click', (e) => {
    e.preventDefault();
    modalSelectClient.classList.toggle('is-active');
});


btnSearchClientByName.addEventListener('click', () => {
    tableClients.querySelectorAll('*').forEach(n => n.remove());
    let url;

    if (!inputNameClient.value) {
        url = `${baseUrl}/clients/`;
    } else {
        url = `${baseUrl}/clients/findByName/${encodeURI(inputNameClient.value)}`;
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
});

//functions
function selectClient() {
    hideClientId.value = parseInt(this.children[0].innerText);
    ClientName.value = this.children[1].innerText
    ClientNit.value = this.children[2].innerText
    modalSelectClient.classList.toggle('is-active');
}