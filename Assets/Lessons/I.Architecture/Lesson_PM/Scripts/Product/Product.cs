using Lessons.I.Architecture.Lesson_MVP.OpenLesson;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.Architecture.PM
{
    [CreateAssetMenu(
        fileName = "Product",
        menuName = "Lessons/New Product (Presentation Model)"
    )]
    public sealed class Product : ScriptableObject
    {
        [PreviewField]
        [SerializeField]
        public Sprite icon;

        [SerializeField]
        public string title;

        [TextArea]
        [SerializeField]
        public string description;
        
        [Space]
        [SerializeField]
        public int price;

        public ProductData CreateData()
        {
            return new ProductData()
            {
                Title = title,
                Icon = icon,
                Price = price,
                Description = description,
            };
        }
    }
}