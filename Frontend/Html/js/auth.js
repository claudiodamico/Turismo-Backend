document.addEventListener('DOMContentLoaded', toggleProtectedElements);

function toggleProtectedElements() {
    const userToken = localStorage.getItem('userToken');
    const protectedElements = document.querySelectorAll('.auth-protected');

    if (userToken) {
        protectedElements.forEach(el => el.style.display = 'block');
    } else {
        protectedElements.forEach(el => el.style.display = 'none');
    }
}

function logout() {
    localStorage.removeItem('userToken');
    window.location.href = 'index.html'; 
}
