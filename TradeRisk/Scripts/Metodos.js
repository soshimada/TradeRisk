var btnAddTrade = document.getElementById('btnAddTrade');
var btnVerificarRIsk = document.getElementById('btnVerificarRIsk');
var divTable = document.getElementById('divTable');
var lblCategorias = document.getElementById('lblCategorias');


var listTrade = [];

btnAddTrade.addEventListener("click", function (e) {
    divTable.removeAttribute("hidden"); 
    e.preventDefault();
    listTrade.push(
        {
            Sector: document.getElementById('txtSetor').value, Value: parseFloat(document.getElementById('txtValue').value)
        });
    LimparCampos();

    PreencherGrid(listTrade);

});

btnVerificarRIsk.addEventListener("click", function () {
    VerificarRiscoCOntroller(listTrade);
});

function LimparCampos() {
    document.getElementById('txtSetor').value = "";
    document.getElementById('txtValue').value = "";
}

function PreencherGrid(data) {    
    $('#tbTRade').DataTable({
        data: data,
        destroy: true,
        columns: [
            { data: "Sector" },
            { data: "Value" }            
        ],
        select: {
            style: 'single'
        },   
        "language": {
            "info": "Página _PAGE_ a _PAGES_",
            "infoEmpty": "Mostrando 0 de 0",
            "lengthMenu": "Mostrando _MENU_  por página",
            "search": "Busca:",
            "zeroRecords": "Não contém registros",
            "paginate": {
                "first": "Primeira",
                "last": "Última",
                "next": "Próxima",
                "previous": "Anterior"
            }
        }     
    });
}

function DestroiTable() {
   
    var table = $('#tbTRade').DataTable();
    table.destroy();
    PreencherGrid(listTrade);
}

function PreencherCategoriasRetorno(data) {
    lblCategorias.innerHTML  = data;
}