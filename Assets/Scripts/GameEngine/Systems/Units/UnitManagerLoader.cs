using System.Linq;
using SaveSystem;
using UnityEngine;

namespace GameEngine
{
    public sealed class UnitManagerLoader : SaveLoader<UnitManager, UnitData[]>
    {
        protected override UnitData[] ConvertToData(UnitManager service)
        {
            var units = service.GetAllUnits().Select(unit => new UnitData()
            {
                ID = unit.GetInstanceID(),
                Type = unit.Type,
                HitPoints = unit.HitPoints,
                Position = unit.Position,
                Rotation = unit.Rotation,
            }).ToArray();
            
            var debugMessage = $"Вы сохранили {service.GetAllUnits().Count()} Юнитов\n";

            foreach (var unit in units)
            {
                debugMessage += $"[ID: {unit.ID}, ";
                debugMessage += $"Type: {unit.Type}, ";
                debugMessage += $"HitPoints: {unit.HitPoints}]";
                debugMessage += "\n";
            }

            Debug.Log(debugMessage);
            return units;
        }

        protected override void SetupData(UnitManager service, UnitData[] data)
        {
            var units = Object.FindObjectsOfType<Unit>();

            //Тут можно изменять Юнитов в зависимости от их сохраненного состояния
            
            service.SetupUnits(units);
        }

        protected override void SetupDefaultData(UnitManager service)
        {
            var units = Object.FindObjectsOfType<Unit>();
            service.SetupUnits(units);
        }
    }
}