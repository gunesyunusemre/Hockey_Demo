using System.Collections.Generic;
using Player;
using UnityEngine;

namespace Ball
{
    //Bu script find kullanmadan topa ulaşmamızı sağlarken
    //getcomponent cullanmadanda script içerisine ulaşmamızı sağlar.
    //Helper iletişim kanalıyken IBall ise scripte olması gereken yapıları bildirir.

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
        Vector3 Direction { get; }
        void ChangeDirection(Vector3 newDir);
        void ChangeDirection(float value);
        void ChangeType(PlayerType type);
        PlayerType CurrentState { get; }
    }
}