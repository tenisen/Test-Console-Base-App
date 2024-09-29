namespace DatabaseModule;
// Copyright © 2024 Ten. All rights reserved.

using System.Collections.Generic;

interface  ITableManager
{
    void AddTable(string tableName, Dictionary<string, DataBaseColumnEnum> values);
    
    void DeleteTable(string tableName);
    
    // void Update(string tableName, string[] values);
    
    void UpdateTableName(string oldName,string newName);
    
    // IEnumerable<string> Get(string tableName, string[] values);

    IEnumerable<string> GetAllTable();
}