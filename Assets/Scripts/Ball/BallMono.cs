using System;
using System.Collections;
using UnityEngine;

namespace Ball
{
    public class BallMono : MonoBehaviour, IBall
    {
        [SerializeField] private SpriteRenderer ballSprite;
        private Vector3 dir;
        public Transform BallTransform { get; private set; }
        public Vector3 Direction { get; private set; }

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
            
            yield return null;
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

        public void ChangeColor(Color color)
        {
            ballSprite.color = color;
        }
    }
}