$("#BtnDeletar").click(function (){
    event.preventDefault();
    
    let cpf = $("#CPFContribuinte").val();

    $.ajax({
        url: "https://localhost:44376/api/CalculoImpostos?",
        dataType: "json",
        method: "PUT",
    }).done(function (msg) {
        $(msg).each(function (i) {
            if (msg.erro == true) {
                alert(msg.Mensagem);
            }
            else {
                alert("Excluído com sucesso");
            }
        });
    }).fail(function (jqXHR, textStatus, msg) {
        alert("Erro de requisição");
    });

});