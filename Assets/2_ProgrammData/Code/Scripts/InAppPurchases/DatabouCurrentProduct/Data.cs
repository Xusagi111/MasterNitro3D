using System.Collections.Generic;
using UnityEngine;

public abstract class Data: IInitializationPurchasescs<Buy>
{
    private int[] Index = new int[3];
    private int _enumIdToBuy;

    public bool Getinizialization(int indexIdCurrentPurchases)
    {
        throw new System.NotImplementedException();
    }

    public List<Buy> GetList()
    {
        throw new System.NotImplementedException();
    }

    public void TransferCurrentProduct<T>(T product)
    {
        throw new System.NotImplementedException();
    }
}


