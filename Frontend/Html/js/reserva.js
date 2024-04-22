document.addEventListener('DOMContentLoaded', function() {
    fetchReservas();
});

function fetchReservas() {
    fetch('http://localhost:5259/api/Reserva')
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok ' + response.statusText);
            }
            return response.json();
        })
        .then(reservas => {
            const lista = document.getElementById('reservas');
            lista.innerHTML = ''; // Limpiar lista actual
            reservas.forEach(reserva => {
                lista.innerHTML += `
                    <li>Cliente: ${reserva.cliente}, Fecha de Reserva: ${new Date(reserva.fechaReserva).toLocaleDateString()}, Tour: ${reserva.tourId}</li>
                `;
            });
        })
        .catch(error => console.error('There has been a problem with your fetch operation:', error));
}

