using UnityEngine;

namespace Project.Scripts.MVC
{
    public class Starter : MonoBehaviour
    {
        [SerializeField] private Descriptions _descriptions;
        private MonoControllers _controllers;
        
        private void Start()
        {
            _controllers = new MonoControllers();
            var initialization = new GameInitialization(_descriptions, _controllers);
            _controllers.Initialization();
        
        }
    
        private void Update()
        {
            var deltaTime = Time.deltaTime;
            _controllers.Update(deltaTime);
        }

        private void LateUpdate()
        {
            var deltaTime = Time.deltaTime;
            _controllers.LateUpdate(deltaTime);
        }

        private void OnDestroy()
        {
            _controllers.Cleanup();
        }
    }
}