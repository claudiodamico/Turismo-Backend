document.getElementById('deleteReservaForm').addEventListener('submit', function(event) {
    event.preventDefault();

    const reservaId = document.getElementById('reservaId').value;
    const url = `http://localhost:5259/api/Reservas/${reservaId}`; 

    fetch(url, {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json',
            'Authorization': `Bearer ${localStorage.getItem('userToken')}` 
        }
    })
    .then(response => {
        if (!response.ok) {
            throw new Error('Error al eliminar la reserva: ' + response.statusText);
        }
        return response.json();
    })
    .then(() => {
        $('#successModal').modal('show');
        document.getElementById('deleteReservaForm').reset();
    })
    .catch(error => {
        console.error('Error al eliminar la reserva:', error);
        alert('Error al eliminar la reserva. Por favor, verifica los detalles e intenta de nuevo.');
    });
});
