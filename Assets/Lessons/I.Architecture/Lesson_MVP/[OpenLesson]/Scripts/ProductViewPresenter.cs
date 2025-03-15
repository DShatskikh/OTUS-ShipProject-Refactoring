using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Lessons.I.Architecture.Lesson_MVP.OpenLesson
{
    //Presenter
    public class ProductViewPresenter : MonoBehaviour
    {
        public GameObject MarketPopup;
        public Button ClosePopupButton;
        public ProductView ProductViewPrefab;
        public Transform ProductViewContainer;

        public IProductService ProductService;

        private List<ProductView> _productViews = new();

        public int Money = 100;
        public TMP_Text MoneyText;
        
        private void Awake()
        {
            ClosePopupButton.onClick.AddListener(() =>
            {
                MarketPopup.SetActive(false);
            });
            
            ProductService.OnProductAdded += OnProductAdded;
            ProductService.OnProductUnlocked += OnProductUnlocked;
        }

        private void OnProductUnlocked(ProductData productData)
        {
            var view = _productViews.FirstOrDefault(view => view.ProductData == productData);

            if (view != null)
            {
                view.DeactivateBuyButton();
            }
        }

        private void OnProductAdded(ProductData productData)
        {
            CreateView(productData);
        }

        [Button]
        public void ShowMarket()
        {
            MarketPopup.SetActive(true);

            // for (int i = _productViews.Count - 1; i >= 0; i--)
            // {
            //     var view = _productViews[i];
            //     _productViews.Remove(view);
            //     Destroy(view.gameObject);
            // }
        }

        private void CreateView(ProductData product)
        {
            var productView = Instantiate(ProductViewPrefab, ProductViewContainer);
            productView.SetTitle(product.Title);
            productView.SetDescription(product.Description);
            productView.SetPrice(product.Price);
            productView.SetIcon(product.Icon);
                
            productView.ProductData = product;
                
            productView.OnBuyClicked += OnProductViewBuyClicked;
                    
            _productViews.Add(productView);
        }

        private void OnProductViewBuyClicked(ProductView productView)
        {
            var productData = productView.ProductData;

            //Money Storage
            if (CanBuy(productData.Price))
            {
                Money -= productData.Price;
                UpdateMoney();
                Debug.Log($"Buy product {productData.Title}");
                ProductService.Unlock(productData);
            }
            else
            {
                Debug.Log("Not enough money");
            }
        }

        private void UpdateMoney()
        {
            MoneyText.SetText(Money.ToString());
        }

        private bool CanBuy(int productPrice)
        {
            return productPrice <= Money;
        }
    }
}
