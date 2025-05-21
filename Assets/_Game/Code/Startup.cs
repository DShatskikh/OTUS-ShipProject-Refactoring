using _Tutorial;
using UnityEngine;

public sealed class Startup : MonoBehaviour
{
    [SerializeField]
    private Player _player;

    private TutorialState _tutorial;

    private void Awake()
    {
        _tutorial = new TutorialState();
        
        ServiceLocator.Register(_tutorial);
        ServiceLocator.Register(_player);
    }

    private void Start()
    {
        _tutorial.Start();
    }
}