using UnityEngine;

namespace Player.Mechanics
{
    [CreateAssetMenu(fileName = "SpeedData_", menuName = "Game/Player/Speed Data", order = 0)]
    public class PlayerSpeedData : ScriptableObject
    {
        //Bu sciptable karakter hızını belirler AI da da aynı scriptable kullanılmıştır.
        //Asset/Scriptables/Player/Move konumunda bulunur.
        
        //Variable
        [SerializeField] private float value;

        //Capsullation
        public float Value => value;
    }
}