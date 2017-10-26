# razor advanced configuration #

### Where to start?

This guide assumes you are already familiar with the information included in README.md.

# razor advanced README

> This guide walks through the configuration of razor generated code distributed across multiple .NET assemblies in one integrated solution.

## Steps to setup a project using razor across multiple projects in a single solution.

### Schema

1. Import the database schema into the schema repository.

### Visual Studio Solution - razor test (RT)

1. Create an "ASP.NET Empty Web Application" using Visual Studio 2012.  (Project Name: RT.Web, Solution Name: RT)
2. Select "Use Visual Studio Development Server" option in the "Web" tab of project settings.
3. Add a "Class Library" project to the solution (Project Name: RT.DataLib).
4. Add a "Class Library" project to the solution (Project Name: RT.DataInterface).
5. Set "RT.Web" to the startup project.

### Interface - razor.interface.v3.vb.sqlserver (4.3.2) - (RT.DataInterface)

1. Select the "RT.DataInterface" project in the solution explorer.
2. Create a folder for the generated data classes.  (i.e. DataInterface)
3. Set "Show All Files" option in Visual Studio Solution Explorer
4. Add a new Item "My2ndGeneration Template" to the "DataInterface" folder.  (i.e. Tables.m2g) 
5. Set configuration structure for desired schema tables; save to generate.  (template: razor.interface.v3.vb.sqlserver)
6. Compile and verify.

### Data - razor.engine.vb.sqlserver (4.2.630), razor.gen.v3.vb.sqlserver (4.3.1) - (RT.DataLib)

1. Add a reference to "Newtonsoft.Json.dll" assembly.
2. Create a folder for the generated data classes.  (i.e. Data)
3. Set "Show All Files" option in Visual Studio Solution Explorer
4. Add a new Item "My2ndGeneration Template" to the "data" folder.  (i.e. Engine.m2g) 
5. Set configuration structure for desired schema; save to generate.  (template: razor.engine.vb.sqlserver)
6. Add a new Item "My2ndGeneration Template" to the "data" folder.  (i.e. Tables.m2g) 
7. Set configuration structure for desired schema tables; save to generate.  (template: razor.gen.vb.sqlserver)
8. Compile and verify.


### References 

1. Add a reference to RT.DataInterface from RT.Web
2. Add a reference to RT.DataLib from RT.Web

### Config - web.config, global.asax

1. Add a global.asax to set the database connection details.

``` 
Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
  [ApplicationNameSpaceGoesHere].razor.UtilSQLServer.SetConnection("server", "database", "user", "password", "application")
End Sub
```



