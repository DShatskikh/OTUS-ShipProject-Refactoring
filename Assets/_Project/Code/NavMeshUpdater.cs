using System.Collections;
using Unity.AI.Navigation;
using UnityEngine;

namespace _Project.Code
{
    public sealed class NavMeshUpdater : MonoBehaviour
    {
        [SerializeField]
        private float _navMeshUpdateInterval = 0.5f;

        private NavMeshSurface _navMeshSurface;

        private void Awake()
        {
            _navMeshSurface = GetComponent<NavMeshSurface>();
        }

        private IEnumerator Start()
        {
            while (true)
            {
                yield return new WaitForSeconds(_navMeshUpdateInterval);
                _navMeshSurface.BuildNavMesh();
            }
        }
    }
}