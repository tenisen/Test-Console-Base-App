namespace DatabaseModule;

using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.Data.Sqlite;

/*
    Targeting the sqlite.

    Online SQL database might required another structure.
*/

public class BasicDataBase : IDataBaseManager, ITableManager, IRecordManager
{
    private SqliteConnection _databaseConnection = new SqliteConnection();
    
    public string DatabaseName { get; set; } // Include Directory Here

    public SqliteConnection SafeConnection
    {
        get
        {
            if (_databaseConnection.State == System.Data.ConnectionState.Closed)
            {
                _databaseConnection.Open();
            }

            return _databaseConnection;
        }
    }


    public BasicDataBase(string databaseName)
    {
        DatabaseName = databaseName;
    }

    public BasicDataBase()
    {
        // Create dummy class.
    }

    // DB
    public virtual void CreateDatabase(string name)
    {
        // Create sqlite data base ( new data base)
        SqliteConnection connection = new SqliteConnection(
            $"Data Source = {DatabaseName};" +
            "New = True;" +
            "Compress = True;"
        );

        try
        {
            connection.Open();
            connection.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        // If successful, data base created.        
    }

    public virtual void DeleteDatabase(string name)
    {
        FileInfo file = new FileInfo(name);

        if (file.Exists)
        {
            // Delete File.
            try
            {
                file.Delete();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    public virtual void EditDatabase(string name, string newName)
    {
        // This function is made for rename data base I think
        // But the problem is renaming a database seem to just 
        //  copy all table from old db to the new one.

        throw new NotImplementedException();
    }

    public virtual bool VerifyDatabase(string dirName)
    {
        // Check that data base exist.
        FileInfo dir = new FileInfo(dirName);

        if (dir.Exists)
        {
            return true;
        }

        return false;
    }

    public void ConnectDataBase(string name)
    {
        if (_databaseConnection != null)
        {
            if (_databaseConnection.State != System.Data.ConnectionState.Closed)
            {
                return;
            }
        }

        _databaseConnection = new SqliteConnection($"Data Source = {DatabaseName};");

        _databaseConnection.Open();
    }

    // Table
    public virtual void AddTable(string tableName, Dictionary<string, DataBaseColumnEnum> values)
    {
        // Add Table
        var command = SafeConnection.CreateCommand();

        string command_text =
            $"CREATE TABLE {tableName} (" +
            "_id INTEGER PRIMARY KEY AUTOINCREMENT, ";

        foreach (var x in values)
        {
            if (x.Value == DataBaseColumnEnum.NULL)
            {
                command_text += $"\n{x.Key} TEXT ,";
            }
            else
                command_text += $"\n{x.Key} {x.Value.ToString()} NOT NULL,";
        }

        command_text.Remove(command_text.Length - 1, 1);
        command_text += ");";

        command.CommandText = command_text;

        command.ExecuteNonQuery();
    }

    public virtual void DeleteTable(string tableName)
    {
        // Delete Table
        var command = SafeConnection.CreateCommand();

        string command_text = $"DROP TABLE {tableName};";

        command.CommandText = command_text;

        command.ExecuteNonQuery();
    }

    public virtual void UpdateTableName(string oldName, string newName)
    {
        // Update Table Name
        var command = SafeConnection.CreateCommand();

        string command_text = $"ALTER TABLE {oldName} RENAME TO {newName};";

        command.CommandText = command_text;

        command.ExecuteNonQuery();
    }

    public IEnumerable<string> GetAllTable()
    {
        List<string> tables = new List<string>();

        var command = SafeConnection.CreateCommand();

        string command_text = "SELECT name FROM sqlite_master WHERE type = 'table' ORDER BY 1";

        command.CommandText = command_text;

        var reader = command.ExecuteReader();

        while (reader.Read())
        {
            string myreader = reader.GetString(0);
            tables.Add(myreader);
            Console.WriteLine(myreader);
        }

        return tables;
    }

    //Record manager
    public void InsertRecord(string tableName, Dictionary<string, object> recordData)
    {
        // Insert Record
        var command = SafeConnection.CreateCommand();

        string command_text =
            $"INSERT INTO {tableName} (";

        foreach (var x in recordData)
        {
            command_text += $"\n{x.Key},";
        }

        command_text.Remove(command_text.Length - 1, 1);
        command_text += ") VALUES (";

        foreach (var x in recordData)
        {
            command_text += $"\n'{x.Value}',";
        }

        command_text.Remove(command_text.Length - 1, 1);
        command_text += ");";

        command.CommandText = command_text;

        command.ExecuteNonQuery();
    }

    public void UpdateRecord(string tableName, int recordId, Dictionary<string, object> recordData)
    {
        // Update Record
        var command = SafeConnection.CreateCommand();

        string command_text =
            $"UPDATE {tableName} SET ";

        foreach (var x in recordData)
        {
            command_text += $"\n{x.Key} = '{x.Value}',";
        }

        command_text.Remove(command_text.Length - 1, 1);
        command_text += $" WHERE _id = {recordId};";

        command.CommandText = command_text;

        command.ExecuteNonQuery();
    }

    public void DeleteRecord(string tableName, int recordId)
    {
        // Delete Record
        var command = SafeConnection.CreateCommand();

        string command_text =
            $"DELETE FROM {tableName} WHERE _id = {recordId};";

        command.CommandText = command_text;

        command.ExecuteNonQuery();
    }

    public Dictionary<string,object> GetRecord(string tableName,int recordId)
    {
        // Get Record
        var command = SafeConnection.CreateCommand();

        string command_text =
            $"SELECT * FROM {tableName} WHERE _id = {recordId};";

        command.CommandText = command_text;

        var reader = command.ExecuteReader();

        Dictionary<string, object> record = new Dictionary<string, object>();

        while (reader.Read())
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                record[reader.GetName(i)] = reader.GetValue(i);
            }
        }

        return record;
    }

    Dictionary<string, object>[] QueryRecords(string tableName,string whereClause)
    {
        // Query Records
        var command = SafeConnection.CreateCommand();

        string command_text =
            $"SELECT * FROM {tableName} WHERE {whereClause};";

        command.CommandText = command_text;

        var reader = command.ExecuteReader();

        List<Dictionary<string, object>> records = new List<Dictionary<string, object>>();

        while (reader.Read())
        {
            Dictionary<string, object> record = new Dictionary<string, object>();

            for (int i = 0; i < reader.FieldCount; i++)
            {
                record[reader.GetName(i)] = reader.GetValue(i);
            }

            records.Add(record);
        }

        return records.ToArray();
    }
}

// Found a idea bug, if we were to create 1 instance class assigned to 1 db.
// Why we have to input the name of the data base ?
// Wouldn't it be just targeting that database. ?

// Create table following class.
// Record Manager based on class shouldn't 
// required to check the items I think.

// Putting | inside a text seems like a very dangerous move.
//  When using command prompt, the | is used as a pipe.
//  But when using sqlite, it is used as a OR operator.
//  So I think it is better to use another character.
