using System;
using UnityEngine;

namespace Hole
{
    public class HoleMono : MonoBehaviour, IHole
    {
        [SerializeField] private int turn=1;
        public Transform HoleTransform { get; private set; }
        
        private void OnEnable()
        {
            HoleTransform = transform;
            this.InitializeHole();
            ChangeScale();
        }

        private void OnDisable()
        {
            this.DestroyHole();
        }


        

        public void IncreaseTurn()
        {
            turn++;
            ChangeScale();
        }

        private void ChangeScale()
        {
            if (turn>20)
                return;
            
            var scale = (turn / 20f);
            transform.localScale = new Vector3(scale, scale);
        }
    }
}