using UnityEngine;

namespace Lessons.Architecture.PM
{
    public abstract class BasePopup : MonoBehaviour
    {
        public abstract void Show();
        public abstract void Hide();
    }
}