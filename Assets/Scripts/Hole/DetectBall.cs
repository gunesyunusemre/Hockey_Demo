using System;
using Ball;
using Manager;
using Unity.Mathematics;
using UnityEngine;

namespace Hole
{
    public class DetectBall : MonoBehaviour
    {
        //Bu script topun deliğe girip girmediğini denetler.

        #region Variable

        private IBall ball;
        private Vector3 ballPosition;
        private Vector3 ballLocalScale;

        #endregion

        #region Monobehaviour Events

        private void Update()
        {
            SetBall();
            
            if (CheckTrigger())
                return;
            
            ScoreManager.instance.Goal(ball.CurrentState);
            SpawnManager.instance.SpawnHole();
            SpawnManager.instance.SpawnBall();
            Destroy(gameObject);
        }

        #endregion

        #region Functions

        private void SetBall()
        {
            ball = BallHelper.Ball;
            ballPosition = ball.BallTransform.position;
            ballLocalScale = ball.BallTransform.localScale;
        }

        private bool CheckTrigger()
        {
            var dis = Vector2.Distance(transform.position, ballPosition);
            return (dis > transform.localScale.x);
        }

        #endregion

        
    }
}