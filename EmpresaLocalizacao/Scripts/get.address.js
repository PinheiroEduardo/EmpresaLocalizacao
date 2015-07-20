
function localizacaoCallBack(jsonAddress) {
    var address = jsonAddress.Logradouro +
        " - " + jsonAddress.Numero +
        " - " + jsonAddress.Cidade +
        " - " + jsonAddress.Cep;

    converterEndereco(address);
}

$(document).ready(function () {
    $("#EmpresaId").change(function () {
        localizacao($(this).val());
    });
});