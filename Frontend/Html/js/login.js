
document.getElementById('loginForm').addEventListener('submit', function(event) {
    event.preventDefault();

    const email = document.getElementById('email').value;
    const password = document.getElementById('password').value;

    const url = 'http://localhost:5259/api/Cuentas/login'; // Asegúrate de usar la URL correcta de tu API

    fetch(url, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ email: email, password: password })
    })
    .then(response => {
        if (!response.ok) {
            throw new Error('Error en la autenticación: ' + response.statusText);
        }
        return response.json();
    })
    .then(data => {
        console.log('Login exitoso:', data);
        localStorage.setItem('userToken', data.token); 
        window.location.href = 'index.html'; 
    })    
    .catch(error => {
        $('#errorModal').modal('show');
        document.getElementById('loginForm').reset();
    });
});

function redirectToIndex() {
    window.location.href = 'index.html';
}