namespace DatabaseModule;

/*
    Test implement attribute like serialize. Do I need a namespace one ?
*/

// This attribute is just for creating a identifier for marked sql to identify
// important members;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
public class DataBaseAttribute : Attribute
{
    public DataBaseAttribute()
    {

    }
}