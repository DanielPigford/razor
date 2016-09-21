var Connection = require('tedious').Connection;
var Request = require('tedious').Request;
var TYPES = require('tedious').TYPES;

var config = {
    userName: 'razortest',
    password: 'razortest',
    server: 'goccvse10.goc.loc',
    options: { instanceName: 'sql2008', database: 'razor_test' }
};

var connection = new Connection(config);

connection.on('connect', function (err) {
    // If no error, then good to proceed.  
    console.log("Connected");
    executeStatement();
});

connection.on('debug', function(text) {
    console.log(text);
  }
);

function executeStatement() {
    request = new Request("SELECT TOP 15 * FROM razor_data_types;", function (err) {
        if (err) {
            console.log(err);
        }
    });
    var result = "";
    request.on('row', function (columns) {
        columns.forEach(function (column) {
            if (column.value === null) {
                console.log('NULL');
            } else {
                result += column.value + " ";
            }
        });
        console.log(result);
        result = "";
    });

    request.on('done', function (rowCount, more) {
        console.log(rowCount + ' rows returned');
    });
    connection.execSql(request);
}

