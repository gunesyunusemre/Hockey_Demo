using System;
using Input_Scripts;
using UnityEngine;

namespace Player.Mechanics
{
    public class PlayerMove : MonoBehaviour
    {

        #region variables

        [SerializeField] private InputTouchPositionData positionData;
        [SerializeField] private PlayerSpeedData speedData;

        [SerializeField] private LimitData limitData;
        
        private float _yPos;

        #endregion

        #region Monobehaviour Events

        private void Start()
        {
            _yPos = transform.position.y;
            
        }

        private void FixedUpdate()
        {
            if (Math.Abs(transform.position.x - positionData.Value.x) < 0.1f) return;
            
            Move();
        }

        #endregion

        #region Functions

        private void Move()
        {
            var step = speedData.Value * Time.deltaTime;
            var target = new Vector2(positionData.Value.x, _yPos);
            target.x = Mathf.Clamp(target.x, -limitData.Value, limitData.Value);
            transform.position = Vector2.MoveTowards(transform.position, target, step);
        }

        #endregion
    }
}