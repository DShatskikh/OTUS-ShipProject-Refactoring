using System;
using AIModule;
using Entities;
using UnityEngine;

namespace Lessons.AI.Architecture
{
    public sealed class AICharacterController : MonoBehaviour
    {
        [SerializeField]
        private MonoEntityStd character;

        [SerializeField]
        private Blackboard blackboard;

        [SerializeField]
        private AIBehaviour aiBehaviour;

        private void Awake()
        {
            this.blackboard.SetObject(BlackboardAPI.Character, this.character);
            this.character.Add(this.blackboard);
        }

        private void OnEnable()
        {
            this.aiBehaviour.OnStart();
        }

        private void OnDisable()
        {
            this.aiBehaviour.OnStop();
        }

        private void FixedUpdate()
        {
            this.aiBehaviour.OnUpdate(Time.fixedDeltaTime);
        }

        private void OnDrawGizmos()
        {
            this.aiBehaviour.OnGizmos();
        }
    }
}