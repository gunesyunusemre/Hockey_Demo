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
        }

        private void Update()
        {
            transform.Translate(dir * (Time.deltaTime * 5f));
        }

        public void ChangeDirection(Vector3 newDir)
        {
            dir = newDir;
        }

        public void ChangeDirection(float value)
        {
            dir *= value;
        }

        public void ChangeColor(Color color)
        {
            ballSprite.color = color;
        }
    }
}