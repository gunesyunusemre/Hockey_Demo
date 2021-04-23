using System;
using System.Collections;
using System.IO;
using Ball;
using Unity.Mathematics;
using UnityEngine;

namespace Wall
{
    public class WallChangeBallDirection : MonoBehaviour
    {
        
        private IBall ball;
        private Vector3 ballPosition;
        private Vector3 ballLocalScale;

        private bool isEnter=true;
        
        private void Update()
        {
            SetBall();
            
            if (!CheckTrigger())
                return;

            if (!isEnter)
                return;

            StartCoroutine(CheckEnter());
            
            var dir = ball.Direction;
            
            //Debug.Log(dir);
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
            return !(math.abs(transform.position.x-ballPosition.x) > 
                     transform.localScale.x/2f+ballLocalScale.x/2f);
        }

        private IEnumerator CheckEnter()
        {
            isEnter = false;
            yield return new WaitForSeconds(0.1f);
            isEnter = true;
        }
        
        
        private void OnDrawGizmos()
        {
            Gizmos.color=Color.green;
            Gizmos.DrawWireCube(transform.position,new Vector3(transform.localScale.x, transform.localScale.y));
        }
    }
}