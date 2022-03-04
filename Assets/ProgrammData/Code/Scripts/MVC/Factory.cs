using System.Threading.Tasks;
using UnityEngine;

namespace Project.Scripts.MVC
{
    public class Factory : MonoBehaviour
    {
        protected Descriptions _descriptions;

        public GameObject CreateWithTask(Task<GameObject> prefab)
        {
            return Instantiate(prefab.Result);
        }
    }
}