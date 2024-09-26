namespace DatabaseModule;

using System;
using System.Data.Sqlite;


/*
    Targeting the sqlite.

    Online SQL database might required another structure.
*/

public class BasicDataBase : IDataBaseManager, ITableManager
{


    public string DatabaseName { get; set; }

    public BasicDataBase(string databaseName)
    {
        DatabaseName = databaseName;
    }

    public BasicDataBase()
    {
        // ...
    }

    // DB
    public virtual void CreateDatabase(string name)
    {
        throw new NotImplementedException();
    }

    public virtual void DeleteDatabase(string name)
    {
        throw new NotImplementedException();
    }

    public virtual void EditDatabase(string name, string newName)
    {
        throw new NotImplementedException();
    }

    public virtual bool VerifyDatabase(string dirName)
    {
        throw new NotImplementedException();
    }

    // Table
    public virtual void Add(string tableName, string[] values)
    {
        throw new NotImplementedException();
    }

    public virtual void Delete(string tableName, string[] values)
    {
        throw new NotImplementedException();
    }

    public virtual IEnumerable<string> Get(string tableName, string[] values)
    {
        throw new NotImplementedException();
    }

    public virtual IEnumerable<string> GetAll(string tableName)
    {
        throw new NotImplementedException();
    }

    public virtual void Update(string tableName, string[] values)
    {
        throw new NotImplementedException();
    }

    public virtual void UpdateTableName(string oldName, string newName)
    {
        throw new NotImplementedException();
    }
}