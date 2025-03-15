using System;
using Atomic.Contexts;
using Atomic.Entities;
using UnityEngine;

namespace Lessons.Lesson_AtomicFramework
{
    public class ShootController : MonoBehaviour
    {
        // [SerializeField] private Character _character;
        [SerializeField] private SceneEntity _sceneEntity;


        private void Start()
        {
            var moveController = GameContext.Instance.GetMoveController();
            Debug.Log($"It is move controller = {moveController}");
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _sceneEntity.GetShootRequest().Invoke();
                // _character.Shoot();
            }
        }
    }
}