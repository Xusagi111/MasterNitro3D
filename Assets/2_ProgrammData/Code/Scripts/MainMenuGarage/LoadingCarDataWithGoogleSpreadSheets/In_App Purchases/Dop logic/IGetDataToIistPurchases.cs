using System.Collections.Generic;

interface IGetDataToIistPurchases: IController
{
    public List<Buy> GetList();
}

