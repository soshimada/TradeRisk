function VerificarRiscoCOntroller(data) {
    debugger
    fetch('Trade/VerificarRisco', {
        method: 'post',
        headers: { 'Content-Type': 'application/json' },
        body:  JSON.stringify(data)
    })
        .then(response => {
            response.json()
                .then(data => {
                    alert(data);

                });
        })
        .catch(erro => {
            console.log("Ocorreu um erro no sistema. Detalhes: " + erro);
        });
}