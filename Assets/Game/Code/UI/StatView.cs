using Atomic.Contexts;
using Atomic.Entities;
using TMPro;
using UnityEngine;

namespace Game
{
    public sealed class StatView : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _hitPointsLabel;
        
        [SerializeField]
        private TMP_Text _ammoLabel;
        
        [SerializeField]
        private TMP_Text _killLabel;

        private void Start()
        {
            var player = SceneContext.Instance.GetPlayer();
            
            var ammo = player.Entity.GetAmmo();
            var maxAmmo = player.Entity.GetMaxAmmo();
            
            _ammoLabel.text = $"BULLETS: {ammo.Value}/{maxAmmo}";
            
            ammo.Subscribe(count =>
            {
                _ammoLabel.text = $"BULLETS: {count}/{maxAmmo}";
            });

            var hitPoints = player.Entity.GetHitPoints();
            
            _hitPointsLabel.text = $"HIT POINTS: {hitPoints.Value} ";

            hitPoints.Subscribe(count =>
            {
                _hitPointsLabel.text = $"HIT POINTS: {count} ";
            });
            
            var kills = player.Entity.GetKills();
            
            _killLabel.text = $"KILLS: {kills.Value} ";
            
            kills.Subscribe(count =>
            {
                _killLabel.text = $"KILLS: {count} ";
            });
        }
    }
}