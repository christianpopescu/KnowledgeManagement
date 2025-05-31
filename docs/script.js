function loadContent(page) {
    fetch(page)
    .then(response => {
        if (!response.ok) {
            throw new Error(`HTTP error! Status: ${response.status}`);
        }
        return response.text();
    })
    .then(data => {
        // Convert relative image paths to absolute paths
        const basePath = page.substring(0, page.lastIndexOf("/"));
        data = data.replace(/src="img\//g, `src="${basePath}/img/`);
        
        document.getElementById('content').innerHTML = data;
    })
    .catch(error => console.error('Error loading the page:', error));
}