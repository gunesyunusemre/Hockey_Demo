using System;
using Ball;
using Manager;
using UnityEngine;

namespace Player
{
    public class CheckBallForPlayer : MonoBehaviour
    {
        #region Variables

        private IBall _ball;
        private Vector3 _ballPos;

        #endregion

        #region Monobehaviour Events

        private void Update()
        {
            SetBall();

            if (!(_ballPos.y < transform.position.y - transform.localScale.y / 2)) return;
            
            //Spawn Ball
            _ball.ChangeType(PlayerType.Player);
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