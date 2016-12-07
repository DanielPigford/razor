# razor #

razor is a set of handlebar templates to build .NET source code based on database schemas.  The goal of the templates are to generate 100% source code based on the .NET framework.  No third party database components are required to use the generated source code.

### How do I get set up? ###

* Register for an M2G account (my2ndgeneration.com)
* Upload your database schema using M2G upload tool
* Select a razor template and database tables
* Generate source code
* Download zip file
* Add to your solution

Alternately you can download M2G Desktop (Windows only) and use the templates directly on your development workstation.  See my2ndgeneration.com for details.

# razor README

> A local installation of M2G Desktop is requried to complete the procedure below.

## Steps to setup a project using razor in a single web project.

### Schema

1. Import the database schema into the schema repository.

### Visual Studio Solution

1. Create an "ASP.NET Empty Web Application" using Visual Studio 2012.
2. Select "Use Visual Studio Development Server" option in the "Web" tab of project settings.

### Data - razor.engine.vb.sqlserver (4.2.629), razor.gen.vb.sqlserver (4.2.878)

1. Add a reference to "Newtonsoft.Json.dll" assembly.
2. Create a folder for the generated data classes.  (i.e. Data)
3. Set "Show All Files" option in Visual Studio Solution Explorer
4. Add a new Item "My2ndGeneration Template" to the "data" folder.  (i.e. Engine.m2g) 
5. Set configuration structure for desired schema; save to generate.  (template: razor.engine.vb.sqlserver)
6. Add a new Item "My2ndGeneration Template" to the "data" folder.  (i.e. Tables.m2g) 
7. Set configuration structure for desired schema tables; save to generate.  (template: razor.gen.vb.sqlserver)
8. Compile and verify.

### Core - razor.core.filldata (4.2.5)

1. Create a folder for the generated core classes.  (i.e. Core)
2. Set "Show All Files" option in Visual Studio Solution Explorer
3. Add a new Item "My2ndGeneration Template" to the "core" folder.  (i.e. Core.m2g) 
4. Set configuration structure for desired schema tables; save to generate.  (template: razor.core.filldata)
5. Compile and verify.

### REST - razor.rest.service (4.2.5)

1. Add a reference to "System.ServiceModel" assembly.
2. Add a reference to "System.ServiceModel.Web" assembly.
3. Create a folder for the generated rest classes.  (i.e. REST)
4. Set "Show All Files" option in Visual Studio Solution Explorer
5. Add a new Item "My2ndGeneration Template" to the "rest" folder.  (i.e. Rest.m2g) 
6. Set configuration structure for desired schema tables; save to generate.  (template: razor.rest.service)
7. Compile and verify.

### Kendo 

The Kendo UI javascript interface components pull data using the razor.rest.service provider.

#### Grid - razor.kendo.grid.js (4.2.5)

1. Create a folder for the generated grid files.  (i.e. Grid)
2. Set "Show All Files" option in Visual Studio Solution Explorer
3. Add a new Item "My2ndGeneration Template" to the "grid" folder.  (i.e. Grid.m2g) 
4. Set configuration structure for desired schema tables; save to generate.  (template: razor.kendo.grid.js)
5. Compile and verify.

#### ComboBox - razor.kendo.combobox.js (4.2.2)

1. Create a folder for the generated combobox files.  (i.e. ComboBox)
2. Set "Show All Files" option in Visual Studio Solution Explorer
3. Add a new Item "My2ndGeneration Template" to the "combobox" folder.  (i.e. ComboBox.m2g) 
4. Set configuration structure for desired schema tables; save to generate.  (template: razor.kendo.combobox.js)
5. Set the values for DISPLAYCOLUMNNAMEGOESHERE and IDCOLUMNNAMEGOESHEREMUSTBENUMERIC in the javascript file.
6. Compile and verify.

### Config - web.config, global.asax

1. Add a global.asax to set the database connection details.

``` 
Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
  [ApplicationNameSpaceGoesHere].razor.UtilSQLServer.SetConnection("server", "database", "user", "password", "application")
End Sub
```

2. Set system.serviceModel configuration settings.

```
<system.serviceModel>
<behaviors>
  <serviceBehaviors>
    <behavior name="">
      <serviceMetadata httpGetEnabled="true" httpsGetEnabled="true" />
      <serviceDebug includeExceptionDetailInFaults="false" />
    </behavior>
  </serviceBehaviors>
</behaviors>
<serviceHostingEnvironment aspNetCompatibilityEnabled="false"
  multipleSiteBindingsEnabled="true" />
</system.serviceModel>
```

3. Set the system.web configuration settings.

```
<system.web>
  <authentication mode="Windows" />
  <authorization>
   <allow users="?"/>
  </authorization>
</system.web>
```



