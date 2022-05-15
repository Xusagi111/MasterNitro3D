using UnityEngine;
public enum StartLevel
{
    DinamicCreateLevel, OneScene, TwoScene
}
public class StarterToLevel : MonoBehaviour
{
    [SerializeField] private DataLevel _dataLEvel = new DataLevel(); 
    [SerializeField] private Material MaterialTwoDinamicRoad;
    [SerializeField] private Material MaterialFreeScene;
    public StartLevel startLevel;
    [SerializeField] private DontDestroy _dontDestroy;
    private GameManagerToScenesd _gameManagerToScene;
    void Awake()
    {
        _gameManagerToScene = FindObjectOfType<GameManagerToScenesd>(); 
        switch (_gameManagerToScene.startLevel)
        {
            case StartLevel.DinamicCreateLevel:
                _dataLEvel.DinamicCreateLevel.SetActive(true);
                RenderSettings.skybox = MaterialTwoDinamicRoad;
                break;
            case StartLevel.OneScene:
                _dataLEvel.prefabOneLevel.SetActive(true);
                RenderSettings.skybox = MaterialFreeScene;
                break;
            case StartLevel.TwoScene:
                _dataLEvel.PrefabTwoLevel.SetActive(true);
                break;
        }

    }
}
[System.Serializable]
public class DataLevel
{
    public GameObject DinamicCreateLevel;
    public GameObject prefabOneLevel;
    public GameObject PrefabTwoLevel;
}
