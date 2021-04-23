using UnityEngine;

namespace Player.Mechanics
{
    [CreateAssetMenu(fileName = "LimitData_", menuName = "Game/Player/Limit Data", order = 0)]
    public class LimitData : ScriptableObject
    {
        //Bu scriptable obje sağ ve sol limitini ayarlar
        //Asset/Scriptables/Player/Move konumunda bulunur.
        
        //Variable
        [SerializeField] private float value;

        //Capsullation
        public float Value => value;
    }
}