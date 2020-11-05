$("#BtnSalvar").click(function (){
    event.preventDefault();
    
    let cpf = $("#CPFContribuinte").val();
    let nome = $("#NomeContribuinte").val();
    let rendaBruta = $("#RendaBruta").val();
    let dependentes = $("#NumeroDependentes").val();

    $.ajax({
        url: "https://localhost:44376/api/CalculoImpostos?cpf="+cpf+"&nome="+nome+"&renda="+rendaBruta+"&dependentes="+dependentes,
        dataType: 'json',
        method: 'POST',
    }).done(function (msg) {
        $(msg).each(function (i) {
            if (msg.erro == true) {
                alert(msg.Mensagem);
            }
            else {
                alert("Cadastrado com sucesso");
            }
        });
    }).fail(function (jqXHR, textStatus, msg) {
        alert("Erro de requisição");
    });

});
