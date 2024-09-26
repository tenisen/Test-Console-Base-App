namespace DatabaseModule;

public interface IDataBaseManager
{
    // Need Data Base Manager Functions

    void CreateDatabase(string name);
    
    void DeleteDatabase(string name);

    void EditDatabase(string name, string newName);

    bool VerifyDatabase(string dirName);

    void ConnectDataBase(string name);
    
}   