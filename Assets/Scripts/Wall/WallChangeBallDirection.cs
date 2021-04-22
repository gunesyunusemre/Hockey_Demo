using System;
using System.IO;
using Ball;
using Unity.Mathematics;
using UnityEngine;

namespace Wall
{
    public class WallChangeBallDirection : MonoBehaviour
    {
        
        IBall ball;
        Vector3 ballPosition;
        Vector3 ballLocalScale;
        
        private void Update()
        {
            SetBall();
            
            if (!CheckTrigger())
                return;

            var dir = ball.Direction;
            Debug.Log(dir);
            dir.x *= -1;
            
            ball.ChangeDirection(dir);
        }
        
        private void SetBall()
        {
            ball = BallHelper.Ball;
            ballPosition = BallHelper.Ball.BallTransform.position;
            ballLocalScale = BallHelper.Ball.BallTransform.localScale;
        }
        
        private bool CheckTrigger()
        {
            if (math.abs(transform.position.x-ballPosition.x) > 
                transform.localScale.x/2f+ballLocalScale.x/2f)
                return false;

            return true;
        }
        
        
        private void OnDrawGizmos()
        {
            Gizmos.color=Color.green;
            Gizmos.DrawWireCube(transform.position,new Vector3(transform.localScale.x, transform.localScale.y));
        }
    }
}