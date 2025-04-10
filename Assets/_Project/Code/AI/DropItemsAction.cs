using _Project.Code;
using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "DropItems", story: "Drop [Steve] Items To [CraftTable]", category: "Action", id: "6505164678c3fd9038386fcafecae63b")]
public partial class DropItemsAction : Action
{
    private const float START_TIME = 3f;
    
    [SerializeReference]
    public BlackboardVariable<Steve> Steve;
    
    [SerializeReference]
    public BlackboardVariable<CraftTable> CraftTable;

    private float _timer;
    
    protected override Status OnStart()
    {
        _timer = START_TIME;
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        _timer -= Time.deltaTime;
        return _timer > 0 ? Status.Running : Status.Success;
    }

    protected override void OnEnd()
    {
        foreach (var item in Steve.Value.GetItems)
        {
            CraftTable.Value.AddItem(item);
        }

        Steve.Value.RemoveAllItems();
    }
}

