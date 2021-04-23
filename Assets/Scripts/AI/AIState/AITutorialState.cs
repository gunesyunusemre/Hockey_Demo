using Ball;
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
            var ball = BallHelper.Ball;

            var step = AI.SpeedData.Value * Time.deltaTime;
            var target = new Vector2(ball.BallTransform.position.x, AI.transform.position.y);
            AI.transform.position = Vector2.MoveTowards(AI.transform.position, target, step);
            
        }

        private void Move(AIController AI)
        {
            var ball = BallHelper.Ball;

            var step = AI.SpeedData.Value * Time.deltaTime;
            
          
        }
    }
}