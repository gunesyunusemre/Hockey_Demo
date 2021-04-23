using Ball;
using Manager;
using Player;
using UnityEngine;

namespace AI
{
    public class CheckBallForAI : MonoBehaviour
    {
        //Bu scriptte top AI çubuğundan yukarı giderse tekrar spawn ettirir ve avantajı oyuncuya verir.
        
        #region variable

        private IBall _ball;
        private Vector3 _ballPos;

        #endregion

        #region Monobehavior events

        private void Update()
        {
            SetBall();

            if (!(_ballPos.y > transform.position.y + transform.localScale.y / 2)) return;
            
            //Spawn Ball
            _ball.ChangeType(PlayerType.PC);
            SpawnManager.instance.SpawnBall();
        }

        #endregion

        #region Functions

        private void SetBall()
        {
            _ball = BallHelper.Ball;
            _ballPos = _ball.BallTransform.position;
        }

        #endregion
        
    }
}