using System;
using Ball;
using Manager;
using Unity.Mathematics;
using UnityEngine;

namespace Hole
{
    public class DetectBall : MonoBehaviour
    {
        
        private IBall ball;
        private Vector3 ballPosition;
        private Vector3 ballLocalScale;

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
    }
}