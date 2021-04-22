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
            var instantiated =Instantiate(ball);
            switch (BallHelper.Ball.CurrentState)
            {
                case PlayerType.Player:
                    instantiated.transform.position = redSpawnPoint.position;
                    break;
                case PlayerType.PC:
                    instantiated.transform.position = blueSpawnPoint.position;
                    break;
            }
        }

        public void SpawnHole()
        {
            var instantiatedHole =Instantiate(hole);
            var xPos = Random.Range(-2.5f, 2.5f);
            instantiatedHole.transform.position = new Vector3(xPos, 0, 0);
        }
    }
}