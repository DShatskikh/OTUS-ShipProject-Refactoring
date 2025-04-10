using _Project.Code;
using System;
using System.Timers;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using Object = UnityEngine.Object;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "BreakOre", story: "Break [Ore] and add to [Steve]", category: "Action", id: "7a43828196eecadfd1b36368649f8a24")]
public partial class BreakOreAction : Action
{
    private const float START_TIME = 3f;

    [SerializeReference]
    public BlackboardVariable<Steve> Steve;

    [SerializeReference]
    public BlackboardVariable<Ore> Ore;

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
        var ore = Ore.Value;
        Steve.Value.AddItem(ore.Item);
        Object.Destroy(ore.gameObject);
    }
}

