using System;
using Input_Scripts;
using UnityEngine;

namespace Player.Mechanics
{
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] private InputTouchPositionData positionData;
        [SerializeField] private PlayerSpeedData speedData;

        [SerializeField] private LimitData limitData;
        //[SerializeField] private LimitData maxData;
        

        private float _yPos;
        
        private void Start()
        {
            _yPos = transform.position.y;
            
        }

        private void FixedUpdate()
        {
            if (Math.Abs(transform.position.x - positionData.Value.x) < 0.1f) return;
            
            var step = speedData.Value * Time.deltaTime;
            var target = new Vector2(positionData.Value.x, _yPos);
            transform.position = Vector2.MoveTowards(transform.position, target, step);

            if (transform.position.x < -limitData.Value)
            {
                var pos = transform.position;
                pos.x = -limitData.Value;
                transform.position = pos;
            }else if (transform.position.x > limitData.Value)
            {
                var pos = transform.position;
                pos.x = limitData.Value;
                transform.position = pos;
            }
            
        }
    }
}