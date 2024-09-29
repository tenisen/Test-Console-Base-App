namespace DatabaseModule;

public interface IRecordManager
{
    void InsertRecord(string tableName, Dictionary<string, object> recordData); // Column name and value
    
    void UpdateRecord(string tableName, int recordId, Dictionary<string, object> newValues);
    
    void DeleteRecord(string tableName, int recordId);
    
    Dictionary<string, object> GetRecord(string tableName, int recordId);
    
    Dictionary<string, object>[] QueryRecords(string tableName,string whereClause);
}