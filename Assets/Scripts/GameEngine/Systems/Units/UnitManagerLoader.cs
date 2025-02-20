using System.Collections.Generic;
using System.Linq;
using SaveSystem;
using UnityEngine;

namespace GameEngine
{
    public sealed class UnitManagerLoader : SaveLoader<UnitManager, List<UnitData>>
    {
        protected override List<UnitData> ConvertToData(UnitManager service)
        {
            return Object.FindObjectsOfType<Unit>().Select(unit => new UnitData()
            {
                Type = unit.Type,
                HitPoints = unit.HitPoints,
                Position = unit.Position,
                Rotation = unit.Rotation,
            }).ToList();
        }

        protected override void SetupData(UnitManager service, List<UnitData> data)
        {
            var units = Object.FindObjectsOfType<Unit>();

            foreach (var sceneUnit in units) 
                Object.Destroy(sceneUnit.gameObject);

            var allUnits = Resources.LoadAll<Unit>("Test/UnitObjects");
            
            foreach (var unitData in data)
            {
                foreach (var prefab in allUnits)
                {
                    if (prefab.Type == unitData.Type)
                    {
                        var unit = Object.Instantiate(prefab, unitData.Position, Quaternion.Euler(unitData.Rotation));
                        unit.HitPoints = unitData.HitPoints;
                    }
                }
            }

            service.SetupUnits(units);
        }

        protected override void SetupDefaultData(UnitManager service)
        {
            foreach (var unit in Object.FindObjectsOfType<Unit>()) 
                Object.Destroy(unit.gameObject);

            service.SetupUnits(new Unit[] {});
        }
    }
}