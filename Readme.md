# OKHOSTING.UI

A multi-platform UI framework. Create your apps once and deploye them on Windows, Linux, Mac OS X, iOS, Android, Windows Phone and Windows Store

[![Build status](https://ci.appveyor.com/api/projects/status/re4416t7tjld2d5g?svg=true)](https://ci.appveyor.com/project/okhosting/okhosting-ui)

[![Join the chat at https://gitter.im/okhosting/OKHOSTING.UI](https://badges.gitter.im/okhosting/OKHOSTING.UI.svg)](https://gitter.im/okhosting/OKHOSTING.UI?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

## Download 

```
PM> Install-Package OKHOSTING.UI
PM> Install-Package OKHOSTING.UI.CSS
PM> Install-Package OKHOSTING.UI.Net4.WebForms
PM> Install-Package OKHOSTING.UI.Net4.WinForms
PM> Install-Package OKHOSTING.UI.Net4.WPF
PM> Install-Package OKHOSTING.UI.Xamarin.Forms
```

* [Download OKHOSTING.UI on NuGet](https://www.nuget.org/packages/OKHOSTING.UI/)
* [Download OKHOSTING.UI.CSS on NuGet](https://www.nuget.org/packages/OKHOSTING.UI.CSS/)
* [Download OKHOSTING.UI.Net4.WebForms on NuGet](https://www.nuget.org/packages/OKHOSTING.UI.Net4.WebForms/)
* [Download OKHOSTING.UI.Net4.WinForms on NuGet](https://www.nuget.org/packages/OKHOSTING.UI.Net4.WinForms/)
* [Download OKHOSTING.UI.Net4.WPF on NuGet](https://www.nuget.org/packages/OKHOSTING.UI.Net4.WPF/)
* [Download OKHOSTING.UI.Xamarin.Forms on NuGet](https://www.nuget.org/packages/OKHOSTING.UI.Xamarin.Forms/)

## Features

* Create your apps in PCL and run them everywhere
* The UI is defined from code (XAML designer on the way)
* 100% native controls are used in all platforms
* You have only the "common" UI api surface among all platforms
* Supports click and doble click events

## Supported controls

### Regular controls

* Autocomplete
* Button
* Calendar
* CheckBox
* HyperLink
* Image
* Label
* ListPicker (equivalent to a DropDownList)
* PasswordTextBox
* TextArea
* TextBox

### Forms

* Create forms for user data input/output
* Create form fields for string, int, decimal, date, enum, bool, xml or any custom type you need
* Create forms to execute a method

## Examples

This examples are taken from https://github.com/okhosting/OKHOSTING.Sql/tree/master/test/OKHOSTING.Sql.Tests

### Create the schema (tables, indexes and foreign keys) from code

```csharp
var db = new Net4.MySql.DataBase() { ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["mysql"].ConnectionString };

var generator = new OKHOSTING.Sql.MySql.SqlGenerator();

// create customer table
Table customer = new Table("customer");
customer.Columns.Add(new Column() { Name = "Id", DbType = DbType.Int32, IsPrimaryKey = true, IsAutoNumber = true, Table = customer });
customer.Columns.Add(new Column() { Name = "Name", DbType = DbType.AnsiString, Length = 100, IsNullable = false, Table = customer });
customer.Columns.Add(new Column() { Name = "Country", DbType = DbType.Int32, IsNullable = false, Table = customer });
			
// create country table
Table country = new Table("country");
country.Columns.Add(new Column() { Name = "Id", DbType = DbType.Int32, IsPrimaryKey = true, IsAutoNumber = true, Table = country });
country.Columns.Add(new Column() { Name = "Name", DbType = DbType.AnsiString, Length = 100, IsNullable = false, Table = country });

// create a foreign key
ForeignKey countryFK = new ForeignKey();
countryFK.Table = customer;
countryFK.RemoteTable = country;
countryFK.Name = "FK_customer_country";
countryFK.Columns.Add(new Tuple<Column, Column>(customer["Country"], country["id"]));
countryFK.DeleteAction = countryFK.UpdateAction = ConstraintAction.Restrict;

// get SQL code for creating customer table
var sql = generator.Create(customer);

// execute that code and actually create table in DB
db.Execute(sql);

// same for country
sql = generator.Create(country);
db.Execute(sql);

// same for foreigk key
sql = generator.Create(countryFK);
db.Execute(sql);
```
### Reade the schema from the DataBase (Net4 only, thanks to DatabaseSchemaReader)

```csharp
//this way you can just read the existing tables from DB and then perform Insert, Select, Update or Delete operations
//on the tables without the need to manually creating schema like in the previous sample
Net4.MySql.DataBase db = new Net4.MySql.DataBase() { ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["mysql"].ConnectionString };
db.LoadSchema();
DataBaseSchema schema = db.Schema;
Table customerTable = schema["cuctomer"];
```

### Insert

```csharp
Insert insert2 = new Insert();
insert2.Table = country;
insert2.Values.Add(new ColumnValue(country["Id"], 1));
insert2.Values.Add(new ColumnValue(country["Name"], "Mexico"));

sql = generator.Insert(insert2);
int affectedRows2 = db.Execute(sql);
Assert.AreEqual(affectedRows2, 1);

Insert insert = new Insert();
insert.Table = customer;
insert.Values.Add(new ColumnValue(customer["Id"], 1));
insert.Values.Add(new ColumnValue(customer["Name"], "Angel"));
insert.Values.Add(new ColumnValue(customer["Country"], 1));

sql = generator.Insert(insert);
int affectedRows = db.Execute(sql);
Assert.AreEqual(affectedRows, 1);
```

### Select

```csharp
Select select = new Select();
select.Table = customer;
select.Columns.Add(new SelectColumn(customer["id"]));
select.Columns.Add(new SelectColumn(customer["Name"]));

// create a join between customer and country
SelectJoin join = new SelectJoin();
join.Table = country;
join.On.Add(new ColumnCompareFilter() { Column = customer["country"], ColumnToCompare = country["id"], Operator = Data.CompareOperator.Equal });
join.Columns.Add(new SelectColumn(country["name"], "countryName"));
join.JoinType = SelectJoinType.Inner;

select.Joins.Add(join);

sql = generator.Select(select);
var result = db.GetDataTable(sql);

// get results
foreach (IDataRow row in result)
{
	foreach (object obj in row)
	{
		Console.Write(obj);
	}
}
```

### Select Max (or any aggregation function)

```csharp

SelectAggregate selectMax = new SelectAggregate();
selectMax.Table = customer;
selectMax.AggregateColumns.Add(new SelectAggregateColumn(customer["Id"], SelectAggregateFunction.Maximum));

sql = generator.Select(selectMax);
int max = (int) db.GetScalar(sql);
```


### Update

```csharp
Update update = new Update();
update.Table = customer;
update.Set.Add(new ColumnValue(customer["Name"], "New company name"));
update.Where.Add(new ValueCompareFilter() { Column = customer["id"], ValueToCompare = 1 });

sql = generator.Update(update);
affectedRows = db.Execute(sql);
```

### Delete

```csharp
Delete delete = new Delete();
delete.Table = table;
delete.Where.Add(new ValueCompareFilter() { Column = table["Company"], ValueToCompare = "Monsters Inc. Corporate", Operator = Data.CompareOperator.Equal });

sql = generator.Delete(delete);
affectedRows = db.Execute(sql);
```