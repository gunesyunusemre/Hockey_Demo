using System.Collections.Generic;
using UnityEngine;

namespace Ball
{
    public static class BallHelper
    {
        public static IBall Ball;

        public static void InitializeBall(this IBall ball)
        {
            Ball = ball;
        }

        public static void DestroyBall(this IBall ball)
        {
            Ball = null;
        }
    }
    
    public interface IBall
    {
        Transform BallTransform { get; }
        void ChangeDirection(Vector3 newDir);
        void ChangeDirection(float value);

        void ChangeColor(Color color);
    }
}