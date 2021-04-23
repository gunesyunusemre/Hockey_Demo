using System;
using UnityEngine;

namespace Hole
{
    public class HoleMono : MonoBehaviour, IHole
    {
        #region Variable
        [SerializeField] private int turn=1;

        #region IBall Variable
        public Transform HoleTransform { get; private set; }
        #endregion

        #endregion

        #region Monobehaviour Events

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

        #endregion

        #region IBall Functions

        public void IncreaseTurn()
        {
            turn++;
            ChangeScale();
        }

        #endregion

        #region Functions

        private void ChangeScale()
        {
            if (turn>20)
                return;
            
            var scale = (turn / 20f);
            transform.localScale = new Vector3(scale, scale);
        }

        #endregion

    }
}