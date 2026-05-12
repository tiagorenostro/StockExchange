namespace OrderGenerator.API.Constants;

public static class Status
{
    public const char New = 'N';
    
    #region Order
    
    public const char Liquidation = 'L';
    public const char Executed = 'E';
    public const char Rejected = 'R';
    public const char Outher = 'O';

    #endregion
    
    #region Share
    
    public const char Flat = 'F';
    public const char Long = 'L';
    
    #endregion
}