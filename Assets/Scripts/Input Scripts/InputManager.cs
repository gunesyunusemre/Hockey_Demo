using System;
using System.Collections.Generic;
using UnityEngine;

namespace Input_Scripts
{
    public class InputManager : MonoBehaviour
    {
        //Bu script input scriptablelarının çalışmasını sağlar.

        #region Variables

        [SerializeField] private List<InputTouchPositionData> touchPositionList;

        private Camera _camera;

        #endregion

        #region Monobehaviour Events

        private void Start()
        {
            _camera=Camera.main;
            
            foreach (var t in touchPositionList)
            {
                t.Value=new Vector3(0,0,0);
            }
        }


        private void Update()
        {
            foreach (var t in touchPositionList)
            {
                t.Progress(_camera);
            }
        }

        #endregion
        
    }
}