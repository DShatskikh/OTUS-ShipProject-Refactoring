using _Project.Code;
using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "SteveMoveToPoint", story: "[Steve] move to [Point]", category: "Action", id: "433b46d33f0fc21731360e733b84c232")]
public partial class SteveMoveToPointAction : Action
{
    [SerializeReference]
    public BlackboardVariable<Steve> Steve;
    
    [SerializeReference]
    public BlackboardVariable<Transform> Point;

    protected override Status OnStart()
    {
        Steve.Value.MoveTo(Point.Value.position);
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if (!Steve.Value.IsMove)
        {
            return Status.Success;
        }
        
        return Status.Running;
    }

    protected override void OnEnd()
    {
        Steve.Value.StopMove();
    }
}

