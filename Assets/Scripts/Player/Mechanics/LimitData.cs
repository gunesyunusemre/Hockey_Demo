using UnityEngine;

namespace Player.Mechanics
{
    [CreateAssetMenu(fileName = "LimitData_", menuName = "Game/Player/Limit Data", order = 0)]
    public class LimitData : ScriptableObject
    {
        [SerializeField] private float value;

        public float Value => value;
    }
}