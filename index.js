var Connection = require('tedious').Connection;
var config = {
    userName: 'TCSWebOEApp',
    password: 'TCSWebOEApp',
    server: 'goccvse10.goc.loc',
    // If you are on Microsoft Azure, you need this:  
    //options: {encrypt: true, database: 'TCSWebOE'}  
    options: { instanceName: 'sql2008', database: 'TCSWebOE' }
};
var connection = new Connection(config);
connection.on('connect', function (err) {
    // If no error, then good to proceed.  
    console.log("Connected");
    process.exit(-1);
});


