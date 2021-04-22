using UnityEngine;

namespace Player.Mechanics
{
    [CreateAssetMenu(fileName = "SpeedData_", menuName = "Game/Player/Speed Data", order = 0)]
    public class PlayerSpeedData : ScriptableObject
    {
        [SerializeField] private float value;

        public float Value => value;
    }
}