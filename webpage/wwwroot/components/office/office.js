// Data
let url = 'http://localhost:44342/api/OfficeAsync/';
let token = localStorage.getItem('token');

 
// Selectors
 let officeBody = document.querySelector('#office-body');

 // Functions

 let render = (data) => {
    let inner = '';
    data.forEach(office => {
      inner += 
      `
      <tr>
         <td>${office.id}</td>
         <td>${office.name}</td>
         <td>${office.city.value}</td>
      </tr>
      `
    })
    officeBody.innerHTML = inner;
 }

const getOffices = async () => {
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

 getOffices();


