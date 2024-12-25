namespace DatabaseModule;


public enum DataBaseColumnEnum
{
    TEXT,
    INTEGER,
    REAL,
    BLOB,
    NUMERIC 
}

/*
    This enum used in DataBaseColumn class.

    The sql version is a little but more complex,
    currently we use this sqlite lite version first.
*/

// Understand NULL as TEXT NULL first.
// If we need NULL integer or others at one point.
// Add enum for nullable and create new interface.

// Other settings such as 
//      PRIMARY KEY
//      AUTOINCREMENT
//      NOT NULL
//      DEFAULT
// are ignore first.