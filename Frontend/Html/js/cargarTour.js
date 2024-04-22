
document.addEventListener('DOMContentLoaded', function() {
    const form = document.getElementById('formCrearTour');
    form.addEventListener('submit', function(event) {
        event.preventDefault();
        enviarTour();
    });
});

function enviarTour() {
    const url = 'http://localhost:5259/api/Tour';
    const form = document.getElementById('formCrearTour');
    const tourData = {
        nombre: form.elements['nombre'].value,
        destino: form.elements['destino'].value,
        fechaInicio: form.elements['fechaInicio'].value,
        fechaFin: form.elements['fechaFin'].value,
        precio: form.elements['precio'].value
    };

    fetch(url, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(tourData)
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
        document.getElementById('formCrearTour').reset();
    })
    .catch(error => {
        console.error('Error al crear el tour:', error);
        alert("Error al crear el tour: " + error.message); 
    });
}

function redirectToIndex() {
    window.location.href = 'index.html';
}

function cerrarModal() {
    $('#successModal').modal('hide');
}



