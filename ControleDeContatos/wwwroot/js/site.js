// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//let table = new DataTable('#table-contactos');
$(document).ready(function () {
    getDatatable("table-contactos")
    getDatatable("table-usuarios")

    $(".btn-total-contatos").click(function () {
        //Recuperando o ID e visualizar no console do navegador
        var usuarioId = $(this).attr("usuario-id");
        //console.log(usuarioId);
        //REQUISIÇÃO AJAX
        $.ajax({
            type: "GET",
            url: "/Usuario/ListarContatosPorUsuarioId/" + usuarioId,
            success: function(result){
                $("#listaContatosUsuario").html(result);
                $("#modalContatosUsuario").modal("show");
                getDatatable("table-contactos-usuario");
          }});
    });
})

function getDatatable(id) {
    $('#'+id).DataTable({
        "ordering": true,
        "paging": true,
        "searching": true,
        "oLanguage": {
            "sEmptyTable": "Nenhum registro encontrado na tabela",
            "sInfo": "Mostrar _START_ até _END_ de _TOTAL_ registros",
            "sInfoEmpty": "Mostrar 0 até 0 de 0 Registros",
            "sInfoFiltered": "(Filtrar de _MAX_ total registros)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "Mostrar _MENU_ registros por página",
            "sLoadingRecords": "Carregando...",
            "sProcessing": "Processando...",
            "sZeroRecords": "Nenhum registro encontrado",
            "sSearch": "Pesquisar",
            "aPaginate": {
                "sNext": "Próximo",
                "sPrevious": "Anterior",
                "sFirst": "Primeiro",
                "sLast": "Último"
            },
            "aAria": {
                "sSortAscending": ": Ordenar colunas de forma ascendente",
                "sSortDescending": ": Ordenar colunas de forma descendente"
            }
        }
    });
}


// Aquela Mensagem Alerta De Sucesso e Erro
$('.close-alert').click(function() {
    $('.alert').hide('hide')
});


//Forçar Logout Automático ao Voltar
window.onload = function()
{
    if(window.history && window.history.pushState)
    {
        window.history.pushState(null, null, window.location.href);
        window.onpopstate = function()
        {
            //window.location.replace("/Login/Index");
            window.location.reload();
        };
    }
};