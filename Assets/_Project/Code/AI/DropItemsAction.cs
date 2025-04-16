using _Project.Code;
using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "DropItems", story: "[Steve] Drop Items To [CraftTable]", category: "Action", id: "6505164678c3fd9038386fcafecae63b")]
public partial class DropItemsAction : Action
{
    [SerializeReference]
    public BlackboardVariable<Steve> Steve;
    
    [SerializeReference]
    public BlackboardVariable<CraftTable> CraftTable;

    protected override Status OnStart()
    {
        if (Steve.Value.TryDropToCraftTable(CraftTable.Value))
            return Status.Running;
        
        return Status.Failure;
    }

    protected override Status OnUpdate()
    {
        return Steve.Value.IsDropToCraftTable ? Status.Running : Status.Success;
    }
}

