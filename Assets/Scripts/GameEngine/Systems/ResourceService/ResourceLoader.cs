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
            return Object.FindObjectsOfType<Resource>().Select(resuorce => new ResourceData()
            {
                ID = resuorce.ID,
                Amount = resuorce.Amount
            }).ToArray();
        }

        protected override void SetupData(ResourceService service, ResourceData[] data)
        {
            var resources = Object.FindObjectsOfType<Resource>().ToList();
           
            foreach (var resourceData in data)
            {
                foreach (var resource in resources)
                {
                    if (resource.ID == resourceData.ID)
                    {
                        resource.Amount = resourceData.Amount;
                    }
                }
            }

            service.SetResources(resources);
        }

        protected override void SetupDefaultData(ResourceService service)
        {
            service.SetResources(Object.FindObjectsOfType<Resource>());
        }
    }
}