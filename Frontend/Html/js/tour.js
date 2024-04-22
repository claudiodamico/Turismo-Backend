
const apiUrl = 'http://localhost:5259/api/Tour';

// Función que carga los tours y los muestra en la página
function cargarTours() {
    fetch(apiUrl)
    .then(response => response.json())
    .then(tours => {
        const contenedorTours = document.getElementById('tour-list');
        contenedorTours.innerHTML = ''; 

        tours.forEach(tour => {
            const div = document.createElement('div');
            div.className = 'tour';
            div.innerHTML = `
                <h3>${tour.nombre}</h3> 
                <p>Destino: ${tour.destino}</p>
                <p>Fecha Salida: ${new Date(tour.fechaInicio).toLocaleDateString()} - Regreso: ${new Date(tour.fechaFin).toLocaleDateString()}</p>
                <p>Precio: $${tour.precio.toFixed(2)}</p>
            `;
            contenedorTours.appendChild(div);
        });
    })
    .catch(error => console.error('Error al cargar los tours:', error));
}

window.addEventListener('load', cargarTours);
