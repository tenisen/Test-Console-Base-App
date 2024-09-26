namespace DatabaseModule;
// Copyright © 2024 Ten. All rights reserved.
interface  ITableManager
{
    void Add(string tableName, string[] values);
    
    void Delete(string tableName, string[] values);
    
    void Update(string tableName, string[] values);
    
    void UpdateTableName(string oldName,string newName);
    
    IEnumerable<string> Get(string tableName, string[] values);

    IEnumerable<string> GetAll(string tableName);
}