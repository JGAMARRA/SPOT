$(document).ready(function () {
    //$('#myTable').DataTable();
    $('#myTable').DataTable({
        "processing": true, // for show progress bar  
        "serverSide": true, // for process server side  
        "filter": true, // this is for disable filter (search box)  
        "orderMulti": false, // for disable multiple column at once  
        "pageLength": 5, 
        "ajax": {
            "url": "/Moneda/GetAll",
            "type": "GET",
            "datatype": "json"
        },  
        "columns": [
            { "data": "IdMoneda" },
            { "data": "Descripcion" }
      
        ]
    });
});