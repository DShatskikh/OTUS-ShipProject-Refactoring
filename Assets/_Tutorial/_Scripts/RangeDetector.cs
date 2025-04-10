using UnityEngine;

public class RangeDetector : MonoBehaviour
{
    [Header("Detection Settings")]
    [SerializeField] private float detectionRadius = 10f;
    [SerializeField] private LayerMask detectionMask;
    [SerializeField] private bool showDebugVisuals = true;

    public GameObject DetectedTarget
    {
        get;
        set;
    }

    public bool UpdateDetector<T>(out T result) where T : MonoBehaviour
    {
        DetectedTarget = null;
        result = default;
        
        // Perform sphere check
        Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius, detectionMask);

        if (colliders.Length > 0)
        {
            foreach (var collider in colliders)
            {
                if (collider.GetComponent<T>())
                {
                    DetectedTarget = collider.gameObject;
                    result = collider.GetComponent<T>();
                    return true;
                }
            }
        }
        else
        {
            DetectedTarget = null;
            return false;
        }
        
        return false;
    }

    // Debug visualization
    private void OnDrawGizmos()
    {
        if (!showDebugVisuals || this.enabled == false) return;

        Gizmos.color = DetectedTarget ? Color.green : Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);

    }
}
