(function () {
    const tokenUrl = '/api/auth';  // Token alacağın endpoint
    fetch(tokenUrl, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({
            kuser: 'admin',
            kpass: '123456'
        })
    })
        .then(response => response.json())
        .then(data => {
            const token = data.authToken;
            if (token) {
                const bearerToken = `${token}`;
                window.localStorage.setItem('jwt-token', bearerToken);

                const checkUIInterval = setInterval(() => {
                    if (window.ui && window.ui.preauthorizeApiKey) {
                        window.ui.preauthorizeApiKey('Bearer', bearerToken);
                        clearInterval(checkUIInterval);
                    }
                }, 100);

            }
        })
        .catch(error => {
            console.error('Error fetching token:', error);
        });
})();
