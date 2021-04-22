using UnityEngine;

namespace Input_Scripts
{
    [UnityEngine.CreateAssetMenu(fileName = "InputTouch_", menuName = "Game/Input/Touch Position", order = 0)]
    public class InputTouchPositionData : UnityEngine.ScriptableObject
    {
        [SerializeField] private Vector3 value;

        public Vector3 Value
        {
            get => value;
            set => this.value = value;
        }


        public void Progress(Camera camera)
        {
            if (!Input.GetMouseButtonDown(0)) return;
            
            Vector3 screenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.z, 10);
            if (!(camera is null)) Value = camera.ScreenToWorldPoint(screenPos);
        }

    }
}