using System;
using System.Collections;
using Hole;
using Player;
using UnityEngine;

namespace Ball
{
    public class BallMono : MonoBehaviour, IBall
    {
        [SerializeField] private SpriteRenderer ballSprite;
        private Vector3 dir;
        public Transform BallTransform { get; private set; }
        public Vector3 Direction { get; private set; }
        public PlayerType CurrentState { get; private set; }

        private void OnEnable()
        {
            BallTransform = transform;
            this.InitializeBall();
        }
        private void OnDisable()
        {
            this.DestroyBall();
        }

        private void Start()
        {
            dir=Vector3.down;
            Direction = dir;
            ChangeType(PlayerType.Grey);
            StartCoroutine(MoveBall());
        }

        

        private IEnumerator MoveBall()
        {
            yield return new WaitForSeconds(1f);
            do
            {
                transform.Translate(dir * (Time.deltaTime * 5f));
                yield return null;
            } while (true);
            
        }

        public void ChangeDirection(Vector3 newDir)
        {
            dir = newDir;
            Direction = newDir;
        }

        public void ChangeDirection(float value)
        {
            dir *= value;
            Direction = dir;
        }

        public void ChangeType(PlayerType type)
        {
            HoleHelper.HoleList[0].IncreaseTurn();
            CurrentState = type;
            switch (type)
            {
                case PlayerType.Player:
                    ballSprite.color=Color.blue;
                    break;
                case PlayerType.PC:
                    ballSprite.color=Color.red;
                    break;
                case  PlayerType.Grey:
                    ballSprite.color=Color.gray;
                    break;
            }
        }
    }
}