using System.Collections;
using TMPro;
using UnityEngine;

namespace ShootEmUp
{
    public class StartGameScreen : ScreenBase
    {
        [SerializeField]
        private TMP_Text _reverseReportLabel;

        [SerializeField]
        private GameStateController _gameStateController;

        public override void Show()
        {
            base.Show();
            StartCoroutine(AwaitReverseReport());
        }

        private IEnumerator AwaitReverseReport()
        {
            for (int i = 3; i > 0; i--)
            {
                _reverseReportLabel.text = $"{i}";
                yield return new WaitForSeconds(0.25f);
                _reverseReportLabel.text += '.';
                yield return new WaitForSeconds(0.25f);
                _reverseReportLabel.text += '.';
                yield return new WaitForSeconds(0.25f);
                _reverseReportLabel.text += '.';
                yield return new WaitForSeconds(0.25f);
            }
            
            Hide();
            _gameStateController.StartGame();
        }
    }
}