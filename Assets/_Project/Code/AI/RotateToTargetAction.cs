using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using UnityEngine.Serialization;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "RotateToTarget", story: "[Self] Rotate To [Target]", category: "Action", id: "6f7c9c90e0ad17fff78f8e691a5ff1a2")]
public partial class RotateToTargetAction : Action
{
    private const float ROTATION_SPEED = 3;
    
    [SerializeReference]
    public BlackboardVariable<Transform> Self;
    
    [SerializeReference]
    public BlackboardVariable<Transform> Target;

    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        Vector3 direction = Target.Value.position - Self.Value.position;
        direction.y = 0; // Ограничиваем вращение по Y
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        Self.Value.rotation = Quaternion.Lerp(Self.Value.rotation, targetRotation, Time.deltaTime * ROTATION_SPEED);
        
        return Math.Abs(Self.Value.rotation.y - targetRotation.y) < 0.2f ? Status.Success : Status.Running;
    }

    protected override void OnEnd()
    {
    }
}

