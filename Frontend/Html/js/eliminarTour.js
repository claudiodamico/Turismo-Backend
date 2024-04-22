document.getElementById('deleteTourForm').addEventListener('submit', function(event) {
    event.preventDefault();

    const tourId = document.getElementById('tourId').value;
    const url = `http://localhost:5259/api/Tours/${tourId}`; 

    fetch(url, {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json',
            'Authorization': `Bearer ${localStorage.getItem('userToken')}` 
        }
    })
    .then(response => {
        if (!response.ok) {
            throw new Error('Error al eliminar el tour: ' + response.statusText);
        }
        return response.json();
    })
    .then(() => {
        $('#successModal').modal('show');
        document.getElementById('deleteTourForm').reset(); 
    })
    .catch(error => {
        console.error('Error al eliminar el tour:', error);
        alert('Error al eliminar el tour. Por favor, verifica los detalles e intenta de nuevo.');
    });
});
