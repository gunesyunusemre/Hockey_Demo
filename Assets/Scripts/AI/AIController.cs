using System;
using AI.AIState;
using Player.Mechanics;
using UnityEngine;

namespace AI
{
    public class AIController : MonoBehaviour
    {
        [SerializeField] private AIData AIData;
        [SerializeField] private PlayerSpeedData speedData;
        
        public PlayerSpeedData SpeedData => speedData;

        private AIBaseState currentState;

        public AIBaseState CurrentState
        {
            get { return currentState; }
        }

        

        public readonly AITutorialState TutorialState = new AITutorialState();
        public readonly AIEasyState EasyState = new AIEasyState();
        public readonly AIMediumState MediumState = new AIMediumState();
        public readonly AIHardState HardState = new AIHardState();
        public readonly AIExpertState ExpertState = new AIExpertState();

        private void Start()
        {
            Debug.Log(AIData.DifficultyType);
            SelectState(AIData.DifficultyType);
        }

        private void Update()
        {
            currentState.Update(this);
        }

        public void TransitionToState(AIBaseState state)
        {
            currentState = state;
            currentState.EnterState(this);
        }

        private void SelectState(AIDifficultyType type)
        {
            switch (type)
            {
                case AIDifficultyType.Tutorial:
                    TransitionToState(TutorialState);
                    break;
                case AIDifficultyType.Easy:
                    TransitionToState(EasyState);
                    break;
                case AIDifficultyType.Medium:
                    TransitionToState(MediumState);
                    break;
                case AIDifficultyType.Hard:
                    TransitionToState(HardState);
                    break;
                case AIDifficultyType.Expert:
                    TransitionToState(ExpertState);
                    break;
            }
        }

        
        
    }
}