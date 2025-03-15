using System;
using System.Collections.Generic;
using Lessons.Architecture.MVP;
using Lessons.Architecture.PM;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.I.Architecture.Lesson_MVP.OpenLesson
{
    public interface IProductService
    {
        event Action<ProductData> OnProductAdded;
        event Action<ProductData> OnProductUnlocked;
        void Unlock(ProductData productData);
    }

    public class ProductService : MonoBehaviour, IProductService
    {
        public event Action<ProductData> OnProductAdded;
        public event Action<ProductData> OnProductUnlocked;
        
        [SerializeField] private ProductCatalog _productCatalog;

        public List<ProductData> ProductData = new();

        private void Start()
        {
            Init();
        }

        private void Init()
        {
            foreach (var product in _productCatalog.products)
            {
                AddProduct(product);
            }
        }

        [Button]
        public void AddProduct(Product product)
        {
            var productData = product.CreateData();
            ProductData.Add(productData);
            OnProductAdded?.Invoke(productData);
        }

        public void Unlock(ProductData productData)
        {
            productData.IsUnlock = true;
            OnProductUnlocked?.Invoke(productData);
        }
    }
}