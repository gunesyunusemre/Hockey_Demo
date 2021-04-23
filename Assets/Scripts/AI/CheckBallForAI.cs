using Ball;
using Manager;
using Player;
using UnityEngine;

namespace AI
{
    public class CheckBallForAI : MonoBehaviour
    {
        private IBall _ball;
        private Vector3 _ballPos;
        
        private void Update()
        {
            SetBall();

            if (!(_ballPos.y > transform.position.y + transform.localScale.y / 2)) return;
            
            //Spawn Ball
            _ball.ChangeType(PlayerType.PC);
            SpawnManager.instance.SpawnBall();
        }
        
        private void SetBall()
        {
            _ball = BallHelper.Ball;
            _ballPos = _ball.BallTransform.position;
        }
    }
}