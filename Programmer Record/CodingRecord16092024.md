# Programmer Record Date: 16092024

## NLog

Current Status :
- Added nlog into the project
- Use LoggerBaseClass to wrap nlog function.

Current Bug ( ID = 001 ): 
- Added nlog class, added NLog.config file.
- Test with nlog doesn't create the log file ( NLog.log )  

Current Bug Fixed ( ID = 001 )
- NLog.LogManager.Configuration = new NLog.Config.XmlLoggingConfiguration("Nlog.config");
- Using this line of code will config using the file in the assembly folder.
- linux won't auto config perhaps.

NLog Configuration
- Need add achieve
- Add format
- Add Files.

# Modules Records

Keep track of our current module.

## Logging Module (namespace LoggerModule)

Currently Related Class :

- LoggerModuleManager
- ILogger
- LoggerBaseClass
 
## Database Module (namepsace DatabaseModule)

### Currently Related Class : 

> Interface
- IDataBaseManager
- ITableManager
- IRecordManager

> Basic implementation for above interface
- BasicDataBaseManager

> Enum (for sqlite column type control (incomplete, still can improve))
- DataBaseColumn

### Not Yet Used : 

DataBaseAttribute
    
    Future would like to implement this like a serializer tag, which could use and automatically create table and save into sqlite/SQL but future might need another control class with generic type T & Reflection to do this.

