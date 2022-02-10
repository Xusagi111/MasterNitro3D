using System.Collections.Generic;

namespace Project.Scripts.MVC
{
    public class MonoControllers : IInitialization, IUpdate, ILateUpdate, ICleanup
    {
        private readonly List<IInitialization> _initializeControllers;
        private readonly List<IUpdate> _executeController;
        private readonly List<ILateUpdate> _lateExecutes;
        private readonly List<ICleanup> _cleanups;
        

        public MonoControllers()
        {
            _initializeControllers = new List<IInitialization>();
            _executeController = new List<IUpdate>();
            _lateExecutes = new List<ILateUpdate>();
            _cleanups = new List<ICleanup>();
        }

        internal MonoControllers Add(IController controller)
        {
            if (controller is IInitialization initializeController)
            {
                _initializeControllers.Add(initializeController);
            }

            if (controller is IUpdate execute)
            {
                _executeController.Add(execute);
            }

            if (controller is ILateUpdate lateExecute)
            {
                _lateExecutes.Add(lateExecute);
            }

            if (controller is ICleanup cleanup)
            {
                _cleanups.Add(cleanup);
            }

            return this;
        }
        
        public void Initialization()
        {
            for (int index = 0; index < _initializeControllers.Count; index++)
            {
                _initializeControllers[index].Initialization();
            }
        }
        
        public void Update(float deltaTime)
        {
            for (int index = 0; index < _executeController.Count; index++)
            {
                _executeController[index].Update(deltaTime);
            }
        }


        public void LateUpdate(float deltaTime)
        {
            for (int index = 0; index < _lateExecutes.Count; index++)
            {
                _lateExecutes[index].LateUpdate(deltaTime);
            }
        }
        
        public void Cleanup()
        {
            for (int index = 0; index < _cleanups.Count; index++)
            {
                _cleanups[index].Cleanup();
            }
        }
    }
}