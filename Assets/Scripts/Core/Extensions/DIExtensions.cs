using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public static class DIExtensions
    {
        /*public static ConcreteIdArgConditionCopyNonLazyBinder AddToGameStateController(this ConcreteIdArgConditionCopyNonLazyBinder binder)
        {
            // Используем FromMethod для создания экземпляра и добавления его в контроллер
            return binder.FromMethod((context) =>
            {
                var instance = context.Container.Resolve<IGameListener>();
                GameStateController.Instance?.AddListener(instance);
                return instance;
            });
        }*/
    }
}