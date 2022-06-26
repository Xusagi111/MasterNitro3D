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
    [SerializeField] private BodyTilt _bodyTilt;
    [SerializeField] private GameObject _cinemachinCamera;
    private GameManagerToScenes _gameManagerToScene;
    
    public GameObject PLayerCar { get; set; }
    public GameObject PublicPlayerGameObject;
    public static int CurrentIndexMachin { get; set; }
   public void Awake()
    {
        _gameManagerToScene = FindObjectOfType<GameManagerToScenes>();
        switch (_gameManagerToScene.startLevel)
        {
            case StartLevel.DinamicCreateLevel:
                _dataLEvel.DinamicCreateLevel.SetActive(true);
                RenderSettings.skybox = MaterialTwoDinamicRoad;
              //  _cinemachinCamera.GetComponent<>() TODO ADD SINEMACHIN
                break;
            case StartLevel.OneScene:
                _dataLEvel.prefabOneLevel.SetActive(true);
                RenderSettings.skybox = MaterialFreeScene;
                break;
            case StartLevel.TwoScene:
                _dataLEvel.PrefabTwoLevel.SetActive(true);
                break;
        }
        //if (CurrentIndexMachin != 0)
        //{
        //    CurrentIndexMachin = 0;
        //}
        CreateCar(_gameManagerToScene.IndexCar);
    }
    public void CreateCar(int indexCar)
    {
        DictionaryPlayerCar dictionaryPlayerCar = FindObjectOfType<DictionaryPlayerCar>();
        for (int i = 0; i < dictionaryPlayerCar.InstanseCarPlayerS.Length; i++)
        {
            if (dictionaryPlayerCar.InstanseCarPlayerS[i].indexCar == indexCar)
            {
                PLayerCar = Instantiate(dictionaryPlayerCar.InstanseCarPlayerS[i].Car,Vector3.zero, Quaternion.identity);
                PLayerCar.transform.SetParent(_bodyTilt.gameObject.transform);
                PublicPlayerGameObject = PLayerCar;
                _bodyTilt.Body = PLayerCar.GetComponentInChildren<WellPlayerData>().gameObject.transform;
                break;
            }
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