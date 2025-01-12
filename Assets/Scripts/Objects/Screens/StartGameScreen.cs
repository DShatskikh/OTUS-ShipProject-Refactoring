using System.Collections;
using GameCycle;
using TMPro;
using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public class StartGameScreen : ScreenBase, IInitializable
    {
        [SerializeField]
        private TMP_Text _reverseReportLabel;

        private GameStateController _gameStateController;

        [Inject]
        private void Construct(GameStateController gameStateController)
        {
            _gameStateController = gameStateController;
        }

        public void Initialize()
        {
            Show();
        }

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