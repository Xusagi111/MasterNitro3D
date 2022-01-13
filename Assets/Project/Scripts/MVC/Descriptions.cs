using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Project.Scripts.MVC
{
    [CreateAssetMenu(fileName = "Descriptions", menuName = "Descriptions/DescriptRoad")]
    public class Descriptions : ScriptableObject
    {
        [SerializeField] private AssetReference _oneRoadPrefab;
        [SerializeField] private AssetReference _twoRoadPrefab;

        [SerializeField] private int _countRoad;

        public AssetReference OneRoadPrefab => _oneRoadPrefab;

        public AssetReference TwoRoadPrefab => _twoRoadPrefab;

        public int CountRoad => _countRoad;

        public async Task<GameObject> GetView(AssetReference reference)
        {
            return await Addressables.InstantiateAsync(reference).Task;
        }

    }
}