using UnityEngine;
using UnityEngine.AI;

namespace _Project.Code
{
    [RequireComponent(typeof(CharacterController))]
    public class CustomNavAgent : MonoBehaviour
    {
        [Header("Movement Settings")]
        [SerializeField]
        private float moveSpeed = 3.5f;

        [SerializeField]
        private float rotationSpeed = 120f;

        [SerializeField]
        private float stoppingDistance = 0.5f;

        [Header("Path Finding")]
        [SerializeField]
        private float pathUpdateInterval = 0.5f;

        [SerializeField]
        private float samplePositionRange = 5f;

        [SerializeField]
        private float positionCheckInterval = 1f;

        [SerializeField]
        private float invalidPositionThreshold = 0.3f;

        private CharacterController characterController;
        private NavMeshPath currentPath;
        private int currentPathIndex;
        private float lastPathUpdateTime;
        private float lastPositionCheckTime;
        private Vector3 targetPosition;
        private Vector3 adjustedTargetPosition;
        private Vector3 lastValidPosition;
        private bool hasPath;
        private bool isStuck;

        private void Awake()
        {
            characterController = GetComponent<CharacterController>();
            currentPath = new NavMeshPath();
            lastValidPosition = transform.position;
        }

        private void Update()
        {
            CheckAgentPositionValidity();

            if (isStuck)
            {
                HandleStuckSituation();
                return;
            }

            if (Time.time - lastPathUpdateTime >= pathUpdateInterval &&
                Vector3.Distance(transform.position, adjustedTargetPosition) > stoppingDistance)
            {
                UpdatePath();
                lastPathUpdateTime = Time.time;
            }

            if (hasPath)
            {
                MoveAlongPath();
            }
        }

        private void CheckAgentPositionValidity()
        {
            if (Time.time - lastPositionCheckTime < positionCheckInterval) return;

            lastPositionCheckTime = Time.time;

            // Проверяем, находится ли агент на навигационной сетке
            if (NavMesh.SamplePosition(transform.position, out NavMeshHit hit, invalidPositionThreshold,
                    NavMesh.AllAreas))
            {
                lastValidPosition = transform.position;
                isStuck = false;
            }
            else
            {
                Debug.LogWarning("Agent is in invalid position! Attempting recovery...");
                isStuck = true;
            }
        }

        private void HandleStuckSituation()
        {
            // 1. Пытаемся найти ближайшую точку на NavMesh
            if (NavMesh.SamplePosition(transform.position, out NavMeshHit hit, samplePositionRange, NavMesh.AllAreas))
            {
                Debug.Log("Found valid position nearby, moving to it");
                Vector3 direction = hit.position - transform.position;
                direction.y = 0;

                if (direction.magnitude > 0.1f)
                {
                    // Поворачиваем к точке восстановления
                    Quaternion targetRotation = Quaternion.LookRotation(direction);
                    transform.rotation = Quaternion.RotateTowards(
                        transform.rotation,
                        targetRotation,
                        rotationSpeed * Time.deltaTime);

                    // Двигаемся к точке восстановления
                    characterController.Move(transform.forward * moveSpeed * 0.5f * Time.deltaTime);
                }
                else
                {
                    // Мы достигли точки восстановления
                    isStuck = false;
                    lastValidPosition = transform.position;
                    UpdatePath(); // Пытаемся продолжить путь
                }

                return;
            }

            // 2. Если не нашли точку рядом - телепортируем на последнюю валидную позицию
            Debug.LogWarning("Could not find valid position nearby! Teleporting to last valid position.");
            characterController.enabled = false;
            transform.position = lastValidPosition;
            characterController.enabled = true;
            isStuck = false;
        }

        public void SetDestination(Vector3 destination)
        {
            targetPosition = destination;
            adjustedTargetPosition = FindClosestAccessiblePosition(targetPosition);
            lastPathUpdateTime = -pathUpdateInterval; // Принудительное обновление пути
            hasPath = false;
            isStuck = false;
        }

        private Vector3 FindClosestAccessiblePosition(Vector3 targetPos)
        {
            if (NavMesh.SamplePosition(targetPos, out NavMeshHit hit, 1f, NavMesh.AllAreas))
            {
                return hit.position;
            }

            if (NavMesh.SamplePosition(targetPos, out hit, samplePositionRange, NavMesh.AllAreas))
            {
                Debug.Log($"Target position adjusted from {targetPos} to {hit.position}");
                return hit.position;
            }

            Debug.LogWarning("Could not find any accessible position near target!");
            return targetPos;
        }

        private void UpdatePath()
        {
            if (!NavMesh.SamplePosition(transform.position, out _, invalidPositionThreshold, NavMesh.AllAreas))
            {
                Debug.LogWarning("Cannot calculate path from invalid position!");
                isStuck = true;
                return;
            }

            if (NavMesh.CalculatePath(transform.position, adjustedTargetPosition, NavMesh.AllAreas, currentPath))
            {
                if (currentPath.corners.Length > 1)
                {
                    currentPathIndex = 1;
                    hasPath = true;
                    isStuck = false;
                }
                else
                {
                    hasPath = false;
                }
            }
            else
            {
                adjustedTargetPosition = FindClosestAccessiblePosition(targetPosition);
                hasPath = false;
            }
        }

        private void MoveAlongPath()
        {
            if (currentPathIndex >= currentPath.corners.Length)
            {
                hasPath = false;
                return;
            }

            Vector3 currentWaypoint = currentPath.corners[currentPathIndex];
            Vector3 direction = currentWaypoint - transform.position;
            direction.y = 0;

            if (direction != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.RotateTowards(
                    transform.rotation,
                    targetRotation,
                    rotationSpeed * Time.deltaTime);
            }

            float distanceToWaypoint = direction.magnitude;
            if (distanceToWaypoint <= stoppingDistance)
            {
                currentPathIndex++;
                return;
            }

            characterController.Move(transform.forward * moveSpeed * Time.deltaTime);
        }

        public bool HasPath() => hasPath && !isStuck;

        public bool ReachedDestination() => !hasPath && !isStuck &&
                                            Vector3.Distance(transform.position, adjustedTargetPosition) <=
                                            stoppingDistance;

        public bool IsStuck() => isStuck;

        private void OnDrawGizmos()
        {
            if (currentPath != null && hasPath)
            {
                Gizmos.color = Color.blue;
                for (int i = 0; i < currentPath.corners.Length - 1; i++)
                {
                    Gizmos.DrawLine(currentPath.corners[i], currentPath.corners[i + 1]);
                }
            }

            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(adjustedTargetPosition, 0.3f);

            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(targetPosition, 0.3f);

            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(lastValidPosition, 0.4f);
        }
    }
}