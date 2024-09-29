namespace DatabaseModule;


public enum DataBaseColumnEnum
{
    TEXT,
    INTEGER,
    REAL,
    BLOB,
    NULL 
}

// Understand NULL as TEXT NULL first.
// If we need NULL integer or others at one point.
// Add enum for nullable and create new interface.

// Other settings such as 
//      PRIMARY KEY
//      AUTOINCREMENT
//      NOT NULL
//      DEFAULT
// are ignore first.