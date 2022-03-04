namespace Project.Scripts.MVC
{
    public interface ILateUpdate : IController
    {
        void LateUpdate(float deltaTime);
    }
}