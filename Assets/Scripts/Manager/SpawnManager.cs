using System;
using Ball;
using Player;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Manager
{
    public class SpawnManager : MonoBehaviour
    {
        public static SpawnManager instance;

        [SerializeField] private GameObject ball;
        //Ball Spawn point
        [SerializeField] private Transform redSpawnPoint;
        [SerializeField] private Transform blueSpawnPoint;

        [SerializeField] private GameObject hole;
        

        private void Awake()
        {
            if (instance==null)
                instance = this;
        }

        private void Start()
        {
            //Spawn Ball
            var instantiatedBall =Instantiate(ball);
            instantiatedBall.transform.position = blueSpawnPoint.position;
            //Spawn Hole
            SpawnHole();
        }

        public void SpawnBall()
        {
            switch (BallHelper.Ball.CurrentState)
            {
                case PlayerType.Player:
                    BallHelper.Ball.BallTransform.position = redSpawnPoint.position;
                    BallHelper.Ball.ChangeDirection(Vector3.up);
                    break;
                case PlayerType.PC:
                    BallHelper.Ball.BallTransform.position = blueSpawnPoint.position;
                    BallHelper.Ball.ChangeDirection(Vector3.down);
                    break;
            }
            BallHelper.Ball.ChangeType(PlayerType.Grey);
        }

        public void SpawnHole()
        {
            var instantiatedHole =Instantiate(hole);
            var xPos = Random.Range(-2f, 2f);
            instantiatedHole.transform.position = new Vector3(xPos, 0, 0);
        }
    }
}