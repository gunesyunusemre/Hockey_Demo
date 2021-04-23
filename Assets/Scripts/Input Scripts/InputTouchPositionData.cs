using UnityEngine;

namespace Input_Scripts
{
    [UnityEngine.CreateAssetMenu(fileName = "InputTouch_", menuName = "Game/Input/Touch Position", order = 0)]
    public class InputTouchPositionData : UnityEngine.ScriptableObject
    {
        //Bu script input manager üzerindeki çalışma yükünü scriptable objenin üstüne yıkar.
        //Gerekli scripte ulaştırmak çok basittir.
        //Burada ise dokunulan konumu bulup value değerine atanır.
        
        #region Variables
        //Variable
        [SerializeField] private Vector3 value;

        //Capsullation
        public Vector3 Value
        {
            get => value;
            set => this.value = value;
        }

        #endregion

        #region Functions

        public void Progress(Camera camera)
        {
            if (!Input.GetMouseButtonDown(0)) return;
            
            Vector3 screenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.z, 10);
            if (!(camera is null)) Value = camera.ScreenToWorldPoint(screenPos);
        }

        #endregion
        
    }
}