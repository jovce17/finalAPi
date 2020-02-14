// Data
let url = 'http://localhost:44342/api/CityAsync/';
let token = localStorage.getItem('token');

// Selectors
let cityBody = document.querySelector('#city-body');
let saveBtn = document.querySelector('#city-modal-save');
let cityNameInput = document.querySelector('#new-city-input');

// Functions
const saveCity = async () => {
   let returnMessage;
   let Name = cityNameInput.value;
   if(!Name){
      returnMessage = `Invalid Entry!`
   } else {
      let cityObj = {name: Name};
      let opt = {
         method: 'POST',
         headers: {
            'Content-Type': 'application/json-patch+json',
            'Authorization': `Bearer ${token}`
          },
          body: JSON.stringify(cityObj)
      };
      let response = await fetch(url, opt);
      let result = await response.json();
      console.log(result);
      returnMessage = 'Succesful Operation!';
      getCities();
   }
   console.log(returnMessage);
}

const render = data => {
   let inner = '';
   data.forEach(city => {
      inner += 
      `
      <tr>
         <td>${city.id}</td>
         <td>${city.name}</td>
      </tr>
      `
   })
   cityBody.innerHTML = inner;
}

const getCities = async () => {
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

// Event Listeners
saveBtn.addEventListener('click', saveCity)

// Init
getCities();