
document.getElementById('reservaForm').addEventListener('submit', function(event) {
    event.preventDefault(); // Prevenir el envío normal del formulario

    const cliente = document.getElementById('cliente').value;
    const fechaReserva = document.getElementById('fechaReserva').value;
    const tourId = document.getElementById('tourId').value;

    console.log('Enviar reserva:', { cliente, fechaReserva, tourId });

    fetch('http://localhost:5259/api/Reserva', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({ cliente, fechaReserva, tourId })
    })
    .then(response => {
        if (!response.ok) {
            return response.text().then(text => {
                throw new Error(`HTTP error! status: ${response.status}, message: ${text}`);
            });
        }
        return response.json();
    })
    .then(data => {
        $('#successModal').modal('show');
        document.getElementById('reservaForm').reset();
    })
    .catch(error => {
        console.error('Error al crear la reserva:', error);
        alert("Error al crear la reserva: " + error.message);
    });
});

function showSuccessModal() {
    var myModal = new bootstrap.Modal(document.getElementById('successModal'), {
        keyboard: false
    });
    myModal.show();
}

function redirectToIndex() {
    window.location.href = 'index.html';
}
