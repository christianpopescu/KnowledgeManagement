function loadContent(page) {
    fetch(page)
    .then(response => {
        if (!response.ok) {
            throw new Error(`HTTP error! Status: ${response.status}`);
        }
        return response.text();
    })
    .then(data => {
        document.getElementById('content').innerHTML = data;
    })
    .catch(error => console.error('Error loading the page:', error));
}