![PlusLog](https://user-images.githubusercontent.com/25779434/72088050-ae746b00-32c6-11ea-9655-6529a3583e51.png)

Simple library to logging events in the .NET/.NET Core Framework applications.

## :mag: Features
- This project is a .NET Standard 2.0 library built using Visual Studio 2017
- Support both .NET Framework 4.5 > 4.x and .NET Core Framework 2.x
- Allow events logging in multiple targets such file, database and mail
- Use a single configuration file (pluslog.config) to set the information of the targets

## :pushpin: Target Applications
This library is aimed at .NET/.NET Core applications
   
## :wrench: Setup
1. Add the reference to the project.

2. Create the **pluslog.config** file.
   
   **Note:**
   
   In the case of desktop applications (Console / Winforms), create the **pluslog.config** file in the path where the application's .exe is  located.

   In the case of web applications (ASP.NET), create the **pluslog.config** file in the root directory of the current application.

3. Add the following structure:
```xml
<?xml version="1.0" encoding="utf-8" ?> 
<configuration>
  <!--FileLogger settings-->
  <fileSettings> 
    <file name="Log.txt" path="C:\" />
  </fileSettings>
  <!--DbLogger settings-->
  <dbSettings>
    <connection name="Conn1" type="SQLSERVER" server="server" database="db" user="user1" password="test" />   
  </dbSettings>
  <!--MailLogger settings-->
  <mailSettings>
    <smtp host="smtp.gmail.com" enablessl="true" port="587" />
    <sender email="sender@gmail.com" password="pass" />
    <receiver email="receiver@gmail.com" />
  </mailSettings>
</configuration>
```
   **Note:**
   In case you only need one of the targets, just add the settings section of that target in the file.

## :pencil2: Usage

- **FileLogger**

1. Create a static variable to have access to the logger.
```csharp
public static FileLogger log = LogHelper.GetFileLogger();
```
2. Use the variable to create the events.
```csharp
log.Debug("Test");
log.Success("Test");
log.Info("Test");
log.Warning("Test");
log.Error("Test");
```

![PlusLog_File_Test](https://user-images.githubusercontent.com/25779434/72093206-31022800-32d1-11ea-8c42-1d361deaca06.png)

- **DbLogger**
1. Create a static variable to have access to the logger, specify the connection that the logger will use.
```csharp
public static DbLogger log = LogHelper.GetDbLogger("Conn1");
```
2. Use the variable to create the events.
```csharp
log.Debug("Test");
log.Success("Test");
log.Info("Test");
log.Warning("Test");
log.Error("Test");
```

![PlusLog_SQLServer_Test](https://user-images.githubusercontent.com/25779434/72093332-6870d480-32d1-11ea-8edd-882d36048ae3.png)

**Note:** To use the DbLogger the following table must exist in the specified database:
```sql
CREATE TABLE dbo.LOG_t001(
        log_Id INTEGER IDENTITY(1,1),
        log_Event CHAR(10) NULL,
        log_Date DATETIME NULL,
        log_Message VARCHAR(250) NULL,
        PRIMARY KEY(log_Id));
```

- **MailLogger**
1. Create a static variable to have access to the logger.
```csharp
public static MailLogger log = LogHelper.GetMailLogger();
```
2. Use the variable to create the events.
```csharp
log.Debug("MailLogger Test","Lorem Ipsum is simply dummy text....");
log.Success("MailLogger Test","Lorem Ipsum is simply dummy text....");
log.Info("MailLogger Test","Lorem Ipsum is simply dummy text....");
log.Warning("MailLogger Test","Lorem Ipsum is simply dummy text....");
log.Error("MailLogger Test","Lorem Ipsum is simply dummy text....");
```

![PlusLog_Mail_Test](https://user-images.githubusercontent.com/25779434/72094224-26e12900-32d3-11ea-84db-e910bf93b4db.png)

## :memo: License
This project is licensed under MIT License.
