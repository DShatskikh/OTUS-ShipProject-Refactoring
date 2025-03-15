using System;
using Game.UI;
using Lessons.Architecture.PM;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Lessons.I.Architecture.Lesson_MVP.OpenLesson
{
    public class ProductView : MonoBehaviour
    {
        public event Action<ProductView> OnBuyClicked;
        
        [SerializeField] private TMP_Text _title;
        [SerializeField] private TMP_Text _description;
        [SerializeField] private Image _icon;
        [SerializeField] private TMP_Text _price;

        [SerializeField] private BuyButton _button;

        public ProductData ProductData { get; set; }
        private ProductViewPresenter _presenter;
        
        public void Construct(ProductViewPresenter presenter)
        {
            _presenter = presenter;
        }
        
        private void OnEnable()
        {
            _button.AddListener(OnBuyButtonClicked);
        }

        private void OnDisable()
        {
            _button.RemoveListener(OnBuyButtonClicked);
        }

        private void OnBuyButtonClicked()
        {
            OnBuyClicked?.Invoke(this);
        }

        public void SetTitle(string productTitle)
        {
            _title.SetText(productTitle);
        }

        public void SetDescription(string productDescription)
        {
            _description.SetText(productDescription);
        }

        public void SetPrice(int productPrice)
        {
            _price.SetText(productPrice.ToString());
        }

        public void SetIcon(Sprite productIcon)
        {
            _icon.sprite = productIcon;
        }

        public void DeactivateBuyButton()
        {
            _button.SetAvailable(false);
        }
    }
}