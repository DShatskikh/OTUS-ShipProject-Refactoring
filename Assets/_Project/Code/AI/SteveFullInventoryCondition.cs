using _Project.Code;
using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "SteveFullInventory", story: "[Steve] is Full Inventory", category: "Conditions", id: "605d9c0d690a61216a6a76ee6fcdd5a6")]
public partial class SteveFullInventoryCondition : Condition
{
    [SerializeReference]
    public BlackboardVariable<Steve> Steve;

    public override bool IsTrue() => 
        Steve.Value.GetIsFullInventory;
}
