<% 
/*
=========================================================================
	
	EntitySpaces 2010 
	Persistence Layer and Business Objects for Microsoft .NET 
	Copyright 2005 - 2010 EntitySpaces, LLC 
	EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC 
	http://www.entityspaces.net 

	This template is bound by the EntitySpaces License Agreement which 
	is located here: 

	http://www.entityspaces.net/portal/License/tabid/97/Default.aspx
	
=========================================================================
*/
%><%@ TemplateInfo 
	UniqueID="7CE37C5B-536D-4057-BC6B-37015D3C451F" 
	UserInterfaceID="491990CE-9355-46c8-93FC-E2EC8956BC41"
	Title="Kendo GridJS Classes"   
	Description="Generates the Kendo Grid JavaScript classes" 
	Namespace="Kendo.Grid.JavaScript" 
	Author="Daniel Pigford"
	Version="2012.0.0.0"
	RequiresUI="True" %><%
string outputDirectory = (string)esMeta.Input["OutputPath"];

string upToPrefix = "";
if(esMeta.esPlugIn.UseUpToPrefix)
{
	upToPrefix = esMeta.esPlugIn.sUpToPrefix;
}

//===============================================================
// Execute our SubTemplates ....
//===============================================================
//System.Diagnostics.Debugger.Break();

ITable table = null;
IView  view  = null;
string comma = ",";
int index = 0;
ArrayList list = null;

ArrayList entities = esMeta.Input["Entities"] as ArrayList;
string entityType = (string)esMeta.Input["EntityType"];
string databaseName = (string)esMeta.Input["Database"];
bool hierarchical = (bool)esMeta.Input["GenerateHierarchicalModel"];
bool selectedTablesOnly = (bool)esMeta.Input["GenerateHierarchicalModelSelectedTablesOnly"];
bool lazyLoad = (bool)esMeta.Input["GenerateHierarchicalLazyLoadSupport"];
bool restAPI = (bool)esMeta.Input["GenerateRestAPI"];
string servicePath = (string)esMeta.Input["ServicePath"];

IDatabase database = esMeta.Databases[databaseName];
	
foreach(string tableOrView in entities)
{
	if(entityType == EntitySpaces.MetadataEngine.dbEntityType.Tables.ToString())
	{
		table = database.Tables[tableOrView];
		
		esMeta.Input["View"] = null;
		esMeta.Input["Table"] = table;
		esMeta.Input["Columns"] = table.Columns;
	}
	else 
	{
		view = database.Views[tableOrView];
		
		esMeta.Input["Table"] = null;
		esMeta.Input["View"] = view;	
		esMeta.Input["Columns"] = view.Columns;
	}
	
	esPluginSource source = new esPluginSource(esMeta, table, view);
	esMeta.Input["Source"] = source;
	
	//----------------------------------------
	// Begin actual template execution
	//----------------------------------------	
	string path = this.Template.Header.FilePath;%>//===============================================================================
//                    EntitySpaces Studio by EntitySpaces, LLC
//             Persistence Layer and Business Objects for Microsoft .NET
//             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
//                          http://www.entityspaces.net
//===============================================================================
// EntitySpaces Version : <%=esMeta.esPlugIn.esVersion%>
// EntitySpaces Driver  : <%=esMeta.esPlugIn.esDriver%>
// Date Generated       : <%=DateTime.Now.ToString()%>
//===============================================================================

// ACTIVE VARIABLES
var MetaDataSchema_<%=source.Entity%> = setMetaDataSchema_<%=source.Entity%>();
var MetaDataColumns_<%=source.Entity%> = setMetaDataColumns_<%=source.Entity%>();
var MetaDataColumnIndices_<%=source.Entity%> = setMetaDataColumnIndices_<%=source.Entity%>();
var MetaDataSources_<%=source.Entity%> = null;
if (typeof setMetaDataSources_<%=source.Entity%> == 'function') {
	MetaDataSources_<%=source.Entity%> = setMetaDataSources_<%=source.Entity%>();
}

// DEFAULT / STATIC VARIABLES
var MetaDataSchema_Default_<%=source.Entity%> = setMetaDataSchema_<%=source.Entity%>();
var MetaDataColumns_Default_<%=source.Entity%> = setMetaDataColumns_<%=source.Entity%>();
var MetaDataColumnIndices_Default_<%=source.Entity%> = setMetaDataColumnIndices_<%=source.Entity%>();
var MetaDataSources_Default_<%=source.Entity%> = null
if (typeof setMetaDataSources_<%=source.Entity%> == 'function') {
	MetaDataSources_Default_<%=source.Entity%> = setMetaDataSources_<%=source.Entity%>();
}

// FUNCTIONS
function setMetaDataSchema_<%=source.Entity%>() {
return {
    "model": {
        "id": "key-column-name-goes-here",
        "fields": { <% 
	index = 0;
	comma = ",";
	foreach(IColumn col in source.Columns)
	{
		if(++index == source.Columns.Count) 
		{
			comma = "";
		} %>
			"<%=col.PropertyName%>": {
			"type": "string",
			"editable": false,
			"nullable": false
			}<%=comma%> <%}%>
		}
    }
}
}

function setMetaDataColumns_<%=source.Entity%>() {
return [ <% 
	index = 0;
	comma = ",";
	foreach(IColumn col in source.Columns)
	{
		if(++index == source.Columns.Count) 
		{
			comma = "";
		}
%>
	{
		"encoded": true,
		"field": "<%=col.PropertyName%>",
		"filterable": true,
		"format": null,
		"groupable": false,
		"hidden": false,
		"locked": false,
		"lockable": true,
		"menu": true,
		"sortable": true,
		"template": null,
		"title": "<%=col.PropertyName%>",
		"width": 125
	}<%=comma%>	<%}%>
]
}

function setMetaDataColumnIndices_<%=source.Entity%>() {
return { <% 
	index = 0;
	comma = ",";
	foreach(IColumn col in source.Columns)
	{
		if(++index == source.Columns.Count) 
		{
			comma = "";
		} %>
 idx<%=col.PropertyName%>: <%= index - 1 %><%=comma%>  <%}%>
}}

<%
// Write out the Service Interface
string filepath = source.Entity + ".js";
this.SaveToFile(filepath, output.ToString(), false);
this.ClearOutput();
}%>
<script runat="template">

private string SaveToFile(string fileName, string text, bool generateSingleFile)
{
	if(!generateSingleFile)
	{
		string path = (string)esMeta.Input["OutputPath"];
		
		string fname = path;
		if (!fname.EndsWith("\\")) 
			fname += "\\";

		Directory.CreateDirectory(path);		

		fname += fileName;

		using (StreamWriter sw = System.IO.File.CreateText(fname)) 
		{
			sw.Write(text);
		}

		return "";
	}
	else
	{
		return text;
	}
}

public class HierarchicalProperty
{
	public HierarchicalProperty(string type, string name, string entityOrCollection)
	{
		this.theType = type;
		this.theName = name;
		this.EntityOrCollection = entityOrCollection;
	}
	
	public string theType;
	public string theName;
	public string EntityOrCollection;
}

private bool HasAutoIncrement(EntitySpaces.MetadataEngine.ITable table)
{
	EntitySpaces.MetadataEngine.IColumn col = table.PrimaryKeys[0];
	EntitySpaces.MetadataEngine.IPropertyCollection props = table.Properties;
	
	if(col.IsAutoKey)
	{
		return true;
	}
	
	switch(esMeta.DriverString)
	{
		case "ORACLE":
			EntitySpaces.MetadataEngine.IProperty prop = props["AUTOKEY:" + col.Name];
			if(prop != null)
			{
				return true;
			}
			break;
		
		case "SQL":
			if(col.HasDefault && col.Default == "(newid())")
			{
				return true;
			}
			break;
			
		default:
			break;
	}
	
	return false;
}

private bool IsBinaryManyToMany(EntitySpaces.MetadataEngine.TableRelation tr)
{
	if(tr.IsManyToMany)
	{
		if(tr.ForeignTable.PrimaryKeys.Count == 2)
		{
			return true;
		}
		
		if(tr.ForeignTable.ForeignKeys.Count == 2)
		{
			return true;
		}
	}
	
	return false;
}

private ArrayList GetHierarchicalProperties(ITable table, ArrayList entities, bool selectedTablesOnly, string upToPrefix)
{
	ArrayList hierarchicalProperties = new ArrayList();

	foreach(IForeignKey fk in table.ForeignKeys )
	{
		EntitySpaces.MetadataEngine.TableRelation tr = new EntitySpaces.MetadataEngine.TableRelation(table, fk);
		
		if(selectedTablesOnly)
		{
			if(!entities.Contains(tr.PrimaryTable.FullName) || !entities.Contains(tr.ForeignTable.FullName))
			{
				continue;
			}
		}

		// One to One with primary table
		if(tr.IsOneToOne && !tr.IsDirect)
		{
			string objName = esMeta.esPlugIn.EntityRelationName(tr.ForeignTable);
			
			// HERE
			hierarchicalProperties.Add(new HierarchicalProperty(esMeta.esPlugIn.Entity(tr.ForeignTable.Name), objName, "entity"));
		}
		// One to One with foreign table
		if(tr.IsOneToOne && tr.IsDirect)
		{
			string objName = upToPrefix + esMeta.esPlugIn.EntityRelationName(tr.ForeignTable);
			
			// HERE
			hierarchicalProperties.Add(new HierarchicalProperty(esMeta.esPlugIn.Entity(tr.ForeignTable.Name), objName, "entity"));
		}
		// Many to Many
		if ((IsBinaryManyToMany(tr) && !selectedTablesOnly) ||
			(IsBinaryManyToMany(tr) && selectedTablesOnly && 
			 entities.Contains(tr.CrossReferenceTable.FullName)))
		{
			string objName = upToPrefix + esMeta.esPlugIn.CollectionRelationName(tr.CrossReferenceTable, tr.ForeignTable);
			string manyName = esMeta.esPlugIn.CollectionRelationName(tr.PrimaryTable, tr.ForeignTable);
			
			// HERE
			hierarchicalProperties.Add(new HierarchicalProperty(esMeta.esPlugIn.Collection(tr.CrossReferenceTable.Name), objName, "collection"));				
		}
		// Zero to Many
		if(tr.IsZeroToMany)
		{
			string objName = "";
			if(tr.IsSelfReference)
			{
				objName = esMeta.esPlugIn.CollectionRelationName(tr.ForeignTable, tr.PrimaryColumns[0], tr.IsSelfReference);
			}
			else
			{
				objName = esMeta.esPlugIn.CollectionRelationName(tr.ForeignTable, tr.ForeignColumns[0], tr.IsSelfReference);
			}
			
			// HERE
			hierarchicalProperties.Add(new HierarchicalProperty(esMeta.esPlugIn.Collection(tr.ForeignTable.Name), objName, "collection"));				
		}
		// Many to One
		if(tr.IsManyToOne)
		{
			string objName = upToPrefix + esMeta.esPlugIn.EntityRelationName(tr.ForeignTable, tr.PrimaryColumns[0], tr.IsSelfReference);
			
			// HERE
			hierarchicalProperties.Add(new HierarchicalProperty(esMeta.esPlugIn.Entity(tr.ForeignTable.Name), objName, "entity"));				
		}
	}

	return hierarchicalProperties;
}
</script>