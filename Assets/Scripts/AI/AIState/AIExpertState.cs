using Ball;
using Hole;
using Unity.Mathematics;
using UnityEngine;

namespace AI.AIState
{
    public class AIExpertState : AIBaseState
    {
        #region Variable

        private IBall _ball;
        private Vector3 _ballPos;
        private Vector3 _ballDir;

        private IHole _hole;
        private Vector3 _holePos;
        
        private float _xPos;
        private float _deg;
        private Vector2 _target;

        #endregion

        #region AIBaseStateEvent
        public override void EnterState(AIController AI)
        {
            Debug.Log("Expert State Activate!");
            DifType = AIDifficultyType.Expert;
        }

        public override void Update(AIController AI)
        {
            SetBall();

            if (!(_ballPos.y > 0)) return;

            if (_ballDir.y<0)
                return;

            CalculateXPos(AI);

            if (!ControlXPos())
                return;

            CalculateDegree(AI);
            
            Move(AI);
        }
        

        #endregion

        #region AI Funtion

        private void SetBall()
        {
            _ball = BallHelper.Ball;
            _ballPos = _ball.BallTransform.position;
            _ballDir = _ball.Direction;
        }
        
        private void CalculateXPos(AIController AI)
        {
            var rad = math.atan(_ballDir.y / _ballDir.x);
            var degree = rad * Mathf.Rad2Deg;
            var x = math.cos(180 + degree);
            var dis = math.abs(AI.transform.position.y - _ballPos.y);
            var xDis = x * dis;
            _xPos = xDis + _ballPos.x;
        }

        private bool ControlXPos()
        {
            return !(_xPos > 2) && !(_xPos < -2);
        }

        private void CalculateDegree(AIController AI)
        {
            _hole = HoleHelper.HoleList[0];
            _holePos = _hole.HoleTransform.position;

            var y = AI.transform.position.y - _holePos.y;
            var x = _holePos.x + _xPos;
            var rad = math.atan(y / x);
            _deg =rad * Mathf.Rad2Deg;
        }

        private void PrepareMove(AIController AI)
        {
            if (_holePos.x >0)
            {
                //right
                var rightXPos =((_deg - 15) / 75) + _xPos;
                var targetX = rightXPos-(AI.transform.localScale.x / 2);
                targetX = Mathf.Clamp(targetX,-2, 2);
                _target = new Vector2(targetX, AI.transform.position.y);
            }
            else
            {
                //left
                var leftXPos =((_deg + 90) / 75) + _xPos;
                var targetX = leftXPos-(AI.transform.localScale.x / 2);
                targetX = Mathf.Clamp(targetX,-2, 2);
                _target = new Vector2(targetX, AI.transform.position.y);
            }
        }

        private void Move(AIController AI)
        {
            var step = AI.SpeedData.Value * Time.deltaTime;
            _xPos = Mathf.Clamp(_xPos,-2, 2);
            PrepareMove(AI);
            AI.transform.position = Vector2.MoveTowards(AI.transform.position, _target, step);
        }

        #endregion
        
    }
}