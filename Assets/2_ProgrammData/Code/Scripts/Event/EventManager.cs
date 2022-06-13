using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    public static EventMoney OptionsMenuEvent { get; set; } = new EventMoney();
    public static EventPushList EventPushOn = new EventPushList();
    public static EventClassDisplayToUi EventDisplayUi = new EventClassDisplayToUi();
    public static CarS_Player EventAllGarageCarsThePlayer = new CarS_Player();
    public static EventSaveStatePlyer EventSaveStatePlyer = new EventSaveStatePlyer();  
}
public class EventMoney : GameEvent
{
    public int value;
}
public class EventClassDisplayToUi : GameEvent 
{
    public int Power;
    public int Speed;
    public int Control;
}
public class EventPushList : GameEvent
{
    public int indexCarMachin;
}
public class EventSaveStatePlyer : GameEvent
{
    public int Money;
    public int Diamons;
    public int Level;
}
public class StateToLevel: GameEvent
{
    public int Money;
    public int DriiftGlasses;
} 
