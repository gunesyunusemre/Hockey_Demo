using System;
using AI.AIState;
using Player.Mechanics;
using UnityEngine;

namespace AI
{
    public class AIController : MonoBehaviour
    {
        //Bu Class State machine pattern ile zorlukları kontrol etmektedir.
        //AI Base State den türemiş tüm scriptler burada state olarak kullanılmaktadır.
        //Her bir script ise bir zorluğu belirtmektedir.
        
        #region Variable
        [SerializeField] private AIData AIData;
        [SerializeField] private PlayerSpeedData speedData;
        
        private AIBaseState currentState;

        #region Capsullation
        public PlayerSpeedData SpeedData => speedData;
        public AIBaseState CurrentState
        {
            get { return currentState; }
        }

        #endregion

        #region AI Base State Scripts

        public readonly AITutorialState TutorialState = new AITutorialState();
        public readonly AIEasyState EasyState = new AIEasyState();
        public readonly AIMediumState MediumState = new AIMediumState();
        public readonly AIHardState HardState = new AIHardState();
        public readonly AIExpertState ExpertState = new AIExpertState();

        #endregion

        #endregion

        #region Monobehaviour Events

        private void Start()
        {
            Debug.Log(AIData.DifficultyType);
            SelectState(AIData.DifficultyType);
        }

        private void Update()
        {
            currentState.Update(this);

            if (currentState.DifType != AIData.DifficultyType)
            {
                SelectState(AIData.DifficultyType);
            }
        }

        #endregion

        #region AI Base State Swich Function

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
        

        #endregion
        
    }
}