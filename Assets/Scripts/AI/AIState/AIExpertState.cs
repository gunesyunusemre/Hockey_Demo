using UnityEngine;

namespace AI.AIState
{
    public class AIExpertState : AIBaseState
    {
        public override void EnterState(AIController AI)
        {
            Debug.Log("Expert State Activate!");

        }

        public override void Update(AIController AI)
        {
            
        }
    }
}