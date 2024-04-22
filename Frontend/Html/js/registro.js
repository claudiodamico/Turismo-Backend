document.getElementById('registerForm').addEventListener('submit', function(event) {
    event.preventDefault();

    const email = document.getElementById('email').value;
    const password = document.getElementById('password').value;

    const url = 'http://localhost:5259/api/cuentas/registrar'; 

    fetch(url, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ email: email, password: password })
    })
    .then(response => {
        if (!response.ok) {
            throw new Error('Error en el registro: ' + response.statusText);
        }
        return response.json();
    })
    .then(data => {
        console.log('Registro exitoso:', data);
        $('#successModal').modal('show');
        document.getElementById('registerForm').reset();
        window.location.href = 'index.html';
    })
    .catch(error => {
        console.error('Error al registrar el usuario:', error);
        alert('Error al registrar el usuario. Por favor, verifica tus datos y prueba de nuevo.');
    });
});

function redirectToIndex() {
    window.location.href = 'index.html';
}
