﻿using System;
using Ball;
using Unity.Mathematics;
using UnityEngine;

namespace Player
{
    public class ChangeBallDirection : MonoBehaviour
    {

        [SerializeField] private Transform leftPoint;
        [SerializeField] private Transform midPoint;
        [SerializeField] private Transform rightPoint;
        
        IBall ball;
        Vector3 ballPosition;
        Vector3 ballLocalScale;

        private void Update()
        {
            //TODO: Check PC 
            
            SetBall();

            if (!CheckTrigger())
                return;

            //Dökümanda en sağ ve en sol şeklinde ifade edildiği için topun geliş yönü hesaba katılmamıştır.
            CheckBallPosition();
        }

        private void SetBall()
        {
            ball = BallHelper.Ball;
            ballPosition = BallHelper.Ball.BallTransform.position;
            ballLocalScale = BallHelper.Ball.BallTransform.localScale;
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

        private void CheckBallPosition()
        {
            if (Math.Abs(ballPosition.x - midPoint.position.x) < 0.05f)
            {
                //Debug.Log("MidPoint");
                ball.ChangeDirection(-1);
            }else if (ballPosition.x >= leftPoint.position.x && ballPosition.x <= midPoint.position.x)
            {
                var degreeVector = CalculateLeftDirection();
                if (gameObject.name=="PC")
                    degreeVector.y *= -1;
                ball.ChangeDirection(degreeVector);
                //Debug.Log("Left Point");
            }else if (ballPosition.x <= rightPoint.position.x && ballPosition.x > midPoint.position.x)
            {
                //Debug.Log("Right Point");//Right
                var degreeVector = CalculateRightDirection();
                if (gameObject.name=="PC")//Y direction different player
                    degreeVector.y *= -1;
                ball.ChangeDirection(degreeVector);
            }
        }
        
        private Vector3 CalculateLeftDirection()
        {
            float degree = 165-(75f*-(leftPoint.position.x-ballPosition.x));
            float radians = degree * (Mathf.PI / 180);
            return new Vector3(Mathf.Cos(radians), Mathf.Sin(radians), 0);
        }
        
        private Vector3 CalculateRightDirection()
        {
            float degree = 15.0f+75f*(rightPoint.position.x-ballPosition.x);
            float radians = degree * (Mathf.PI / 180);
            return new Vector3(Mathf.Cos(radians), Mathf.Sin(radians), 0);
        }
        
        
        private void OnDrawGizmos()
        {
            /*Gizmos.color=Color.green;
            Gizmos.DrawWireCube(midPoint.position,new Vector3(0.1f, transform.localScale.y));
            
            Gizmos.color=Color.green;
            Gizmos.DrawWireCube(leftPoint.position,new Vector3(0.9f, transform.localScale.y));
        
            Gizmos.color=Color.green;
            Gizmos.DrawWireCube(rightPoint.position,new Vector3(0.9f, transform.localScale.y));*/
        }
    }
}