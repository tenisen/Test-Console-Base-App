namespace DatabaseModule;

public class DataBaseColumn
{
    public string Name { get;private set; }

    public DataBaseColumnEnum DataBaseDataType { get; set; }

    public bool NullAble { get;private set; }

    public bool AutoIncrement { get;private set; }

    public bool Default { get;private set; }

    public bool PrimaryKey { get; set; }

    public object? DefaultValue { get;private set; }

    public DataBaseColumn(
        string Name,
        DataBaseColumnEnum DataBaseDataType = DataBaseColumnEnum.TEXT,
        bool NullAble = false,
        bool AutoIncrement = false,
        bool Default = false,
        bool PrimaryKey = false,
        object? DefaultValue = null)
    {
        this.Name = Name;
        this.DataBaseDataType = DataBaseDataType;
        this.NullAble = NullAble;
        this.AutoIncrement = AutoIncrement;
        this.PrimaryKey = PrimaryKey;

        if(Default)
        {
            if(DefaultValue == null)
            {
                throw new Exception("Default value is null");
            }

            if(!VerifyDefaultValue(DataBaseDataType, DefaultValue))
            {
                throw new Exception("Default value is not valid");
            }

            this.Default = Default;
            this.DefaultValue = DefaultValue;
        }
    }

    private static   bool VerifyDefaultValue(DataBaseColumnEnum DataBaseDataType,object DefaultValue)
    {
        switch(DataBaseDataType)
        {
            case DataBaseColumnEnum.INTEGER:
                return DefaultValue is int;
            case DataBaseColumnEnum.REAL:
                return DefaultValue is double || DefaultValue is float;
            case DataBaseColumnEnum.TEXT:
                return DefaultValue is string;
            case DataBaseColumnEnum.BLOB:
                return DefaultValue is byte[];
            case DataBaseColumnEnum.NUMERIC:
                bool numericCheck = true;
                if(DefaultValue is string s)
                {
                    numericCheck = double.TryParse(s, out double numericValue);
                }
                return DefaultValue is int || DefaultValue is double || DefaultValue is float || numericCheck;
                /*
                    ~~Pseudo Codes

                    If not string
                        numericCheck = true
                    If String
                        If is not numeric value
                            numericCheck = false
                        If is numeric value
                            numericCheck = true    
                */
            default:
                return false;
        }
        // The condition here can be changed to predicate for future adding conditions.
    }
}