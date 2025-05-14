using _Tutorial;
using UnityEngine;

public sealed class Startup : MonoBehaviour
{
    private TutorialState _tutorial;

    private void Awake()
    {
        _tutorial = new TutorialState();
        
        ServiceLocator.Register(_tutorial);
    }

    private void Start()
    {
        _tutorial.Start();
    }
}