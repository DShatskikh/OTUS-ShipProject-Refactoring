using System.Collections.Generic;
using System.Linq;
using SaveSystem;
using UnityEngine;

namespace GameEngine
{
    public sealed class ResourceLoader : SaveLoader<ResourceService, ResourceData[]>
    {
        protected override ResourceData[] ConvertToData(ResourceService service)
        {
            Debug.Log($"Вы сохранили {service.GetResources().Count()} ресурсов");
            return service.GetResources().Select(resuorce => new ResourceData()
            {
                ID = resuorce.ID,
                Amount = resuorce.Amount
            }).ToArray();
        }

        protected override void SetupData(ResourceService service, ResourceData[] data)
        {
            var resources = Object.FindObjectsOfType<Resource>();
            
            //Тут можно менять состояние в зависимости от сейвдаты
            
            service.SetResources(resources);
        }

        protected override void SetupDefaultData(ResourceService service)
        {
            var resources = Object.FindObjectsOfType<Resource>();
            service.SetResources(resources);
        }
    }
}