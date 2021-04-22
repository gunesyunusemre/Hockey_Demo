using UnityEngine;

namespace AI.AIState
{
    public class AIEasyState : AIBaseState
    {
        public override void EnterState(AIController AI)
        {
            Debug.Log("Easy State Activate!");
        }

        public override void Update(AIController AI)
        {
            
        }
    }
}