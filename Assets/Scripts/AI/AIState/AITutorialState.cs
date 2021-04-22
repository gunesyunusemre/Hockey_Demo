using UnityEngine;

namespace AI.AIState
{
    public class AITutorialState : AIBaseState
    {
        public override void EnterState(AIController AI)
        {
            Debug.Log("Activate Tutorial State!");
        }

        public override void Update(AIController AI)
        {
            
        }
    }
}