using Ball;
using UnityEngine;

namespace AI.AIState
{
    public class AITutorialState : AIBaseState
    {
        #region AI Base State Events

        public override void EnterState(AIController AI)
        {
            Debug.Log("Activate Tutorial State!");
            DifType = AIDifficultyType.Tutorial;
        }

        public override void Update(AIController AI)
        {
            var ball = BallHelper.Ball;

            
            Move(AI, ball);
        }

        #endregion

        #region AI Functions

        private void Move(AIController AI, IBall ball)
        {
            var step = AI.SpeedData.Value * Time.deltaTime;
            var target = new Vector2(ball.BallTransform.position.x, AI.transform.position.y);
            AI.transform.position = Vector2.MoveTowards(AI.transform.position, target, step);
        }
        
        #endregion

    }
}