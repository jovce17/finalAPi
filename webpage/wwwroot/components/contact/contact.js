// Helper Variables
let url = 'http://localhost:44342/api/ContactAsync/';
let token = localStorage.getItem('token');
// Selectors
let contactBody = document.querySelector('#contact-body');

//Functions


const render = data => {
   let tableInner = '';
   data.forEach(contact => {
      tableInner += 
      `
      <tr>
         <td>${contact.id}</td>
         <td>${contact.name} ${contact.surname}</td>
         <td>${contact.uid}</td>
         <td>${contact.idcardNumber}</td>
         <td>${contact.email}</td>
      </tr>
      `
   })
   contactBody.innerHTML = tableInner;
}

const getContacts = async () => {
   let opt = {
      method: 'GET',
      headers: {
         'Content-Type': 'application/json-patch+json',
         'Authorization': `Bearer ${token}`
       }
   }
   let response = await fetch(url, opt);
   let result = await response.json();
   render(result);
}

// Init
getContacts();