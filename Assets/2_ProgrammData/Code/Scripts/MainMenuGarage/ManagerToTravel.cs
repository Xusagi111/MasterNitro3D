using System.Collections;
using UnityEngine;

public class ManagerToTravel : MonoBehaviour
{
    private GameManagerToScenes _gameManagerToScenes { get; set; }
    [field: SerializeField] private GarageController  _garageController { get; set; } //Прокинуть руками

    void Start()
    {
        StartCoroutine(enumerator());
    }
    private IEnumerator enumerator()
    {
        yield return new WaitForSeconds(2f);
        _gameManagerToScenes = FindObjectOfType<GameManagerToScenes>();

        ControllerLevelToPlayer.EventCalculationGlasses?.Invoke(_gameManagerToScenes.CurrentGlassesToTravel);
        _garageController.instanseSavePlayerState.Money += _gameManagerToScenes.CurrentMoneyToTravel;

        //Reset.
        _gameManagerToScenes.CurrentGlassesToTravel = 0;
        _gameManagerToScenes.CurrentMoneyToTravel = 0;
    }
}
