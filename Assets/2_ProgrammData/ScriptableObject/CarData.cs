using UnityEngine;
public enum CarType
{
    MachinYelloy1 = 123,
    Chevrolet_camaro2 = 256,
    Dodge3 = 324,
    Mazda_rx4 = 478,
    Mustang_hoomigan5 = 555,
    Toyota_supra6 = 123
}
[CreateAssetMenu(fileName = "CarData", menuName = "CarDataprefab")]
public class CarData :ScriptableObject
{ 
    public GameObject CarPrefab;
    public CarType Cartype;
}
