using _Project.Code;
using System;
using System.Collections.Generic;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "StevePatrol", story: "[Steve] patrol to [Waipoints]", category: "Action", id: "5e35d07f1761f7bfa3c78ed9d72f060a")]
public partial class StevePatrolAction : Action
{
    [SerializeReference]
    public BlackboardVariable<Steve> Steve;
    
    [SerializeReference] 
    public BlackboardVariable<List<GameObject>> Waipoints;

    private int _pointIndex;
    
    protected override Status OnStart()
    {
        Steve.Value.MoveTo(Waipoints.Value[_pointIndex].transform.position);
        
        _pointIndex++;
            
        if (_pointIndex >= Waipoints.Value.Count)
            _pointIndex = 0;
        
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

