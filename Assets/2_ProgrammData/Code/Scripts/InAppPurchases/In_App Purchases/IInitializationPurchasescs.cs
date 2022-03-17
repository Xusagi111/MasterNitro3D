using System.Collections.Generic;

public interface IInitializationPurchasescs<T> : IGetDataToIistPurchases<T>
{
    public bool Getinizialization(int indexIdCurrentPurchases);
    public void TransferCurrentProduct<T>(T product);
    
}
   