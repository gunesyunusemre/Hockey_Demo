using Ball;
using Unity.Mathematics;
using UnityEngine;

namespace AI.AIState
{
    public class AIHardState : AIBaseState
    {
        #region Variable
        private IBall _ball;
        private Vector3 _ballPos;
        private Vector3 _ballDir;
        
        private float _xPos;
        #endregion

        #region AI Base State Events

        public override void EnterState(AIController AI)
        {
            Debug.Log("Hard State Activate!");
            DifType = AIDifficultyType.Hard;
        }

        public override void Update(AIController AI)
        {
            SetBall();

            if (!(_ballPos.y > 0)) return;
            
            if (_ballDir.y<0)
                return;
            
            CalculateXPos(AI);
            
            Move(AI);
        }

        #endregion

        #region AI Function

        private void SetBall()
        {
            _ball = BallHelper.Ball;
            _ballPos = _ball.BallTransform.position;
            _ballDir = _ball.Direction;
        }
        
        private void CalculateXPos(AIController AI)
        {
            var radian = math.atan(_ballDir.y / _ballDir.x);
            var degree = radian * Mathf.Rad2Deg;
            var x = math.cos(180 + degree);
            var dis = math.abs(AI.transform.position.y - _ballPos.y);
            var xDis = x * dis;
            _xPos = xDis + _ballPos.x;
        }

        private void Move(AIController AI)
        {
            var step = AI.SpeedData.Value * Time.deltaTime;
            _xPos = Mathf.Clamp(_xPos,-2, 2);
            var target = new Vector2(_xPos, AI.transform.position.y);
            AI.transform.position = Vector2.MoveTowards(AI.transform.position, target, step);
        }

        #endregion

    }
}