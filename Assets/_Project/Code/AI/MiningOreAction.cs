using _Project.Code;
using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "MiningOreAction", story: "Mining [Ore] and add to [Steve]", category: "Action", id: "ebf53901ff492e63d7dd9122ca765191")]
public partial class MiningOreAction : Action
{
    [SerializeReference]
    public BlackboardVariable<Steve> Steve;

    [SerializeReference]
    public BlackboardVariable<Ore> Ore;
    
    protected override Status OnStart()
    {
        if (Steve.Value.TryMining(Ore.Value))
            return Status.Running;

        return Status.Failure;
    }

    protected override Status OnUpdate()
    {
        return Steve.Value.IsMining ? Status.Running : Status.Success;
    }
}


