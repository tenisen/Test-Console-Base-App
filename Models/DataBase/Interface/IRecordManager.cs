namespace DatabaseModule;

public interface IRecordManager<T> 
{
    void InsertRecord(string tableName, Dictionary<string, object> recordData); // Column name and value
    
    void UpdateRecord(string tableName, int recordId, Dictionary<string, object> newValues);
    
    void DeleteRecord(string tableName, int recordId);
    
    T GetRecord(string tableName, int recordId);
    
    IEnumerable<T> QueryRecords(string tableName, string whereClause, Dictionary<string, object> parameters);

}