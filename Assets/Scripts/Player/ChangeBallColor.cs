using System;
using Ball;
using Unity.Mathematics;
using UnityEngine;

namespace Player
{
    public class ChangeBallColor : MonoBehaviour
    {
        [SerializeField] private PlayerType thisType;

        [SerializeField] private Transform leftPoint;
        [SerializeField] private Transform rightPoint;

        private IBall ball;
        private Vector3 ballPosition;
        private Vector3 ballLocalScale;
        
        private void Update()
        {
            SetBall();

            if (!CheckTrigger())
                return;
            
            ball.ChangeType(thisType);
        }
        
        private void SetBall()
        {
            ball = BallHelper.Ball;
            ballPosition = ball.BallTransform.position;
            ballLocalScale = ball.BallTransform.localScale;
        }

        private bool CheckTrigger()
        {
            if (math.abs(transform.position.y-ballPosition.y) > 
                transform.localScale.y/2f+ballLocalScale.y/2f)
                return false;

            
            if (ballPosition.x < leftPoint.position.x || ballPosition.x > rightPoint.position.x)
                return false;

            return true;
        }
    }
}