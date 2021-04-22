using UnityEngine;

namespace AI.AIState
{
    public class AIHardState : AIBaseState
    {
        public override void EnterState(AIController AI)
        {
            Debug.Log("Hard State Activate!");

        }

        public override void Update(AIController AI)
        {
            
        }
    }
}