using Ball;
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
            var ball = BallHelper.Ball;

            if (!(ball.BallTransform.position.y >= 0)) return;
            
            
            var step = AI.SpeedData.Value * Time.deltaTime;
            var target = new Vector2(ball.BallTransform.position.x-0.5f, AI.transform.position.y);
            AI.transform.position = Vector2.MoveTowards(AI.transform.position, target, step);

        }
    }
}