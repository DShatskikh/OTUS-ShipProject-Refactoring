using _Project.Code;
using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "SearchNearestOre", story: "[RangeDetector] Search [NearestOre]", category: "Action", id: "167792c00f7c32696881256d69b2e953")]
public partial class SearchNearestOreAction : Action
{
    [SerializeReference]
    public BlackboardVariable<RangeDetector> RangeDetector;
    
    [SerializeReference]
    public BlackboardVariable<Ore> NearestOre;

    protected override Status OnUpdate()
    {
        var status = RangeDetector.Value.UpdateDetector(out Ore result);
        NearestOre.Value = result;
        return status ? Status.Success : Status.Failure;
    }
}

