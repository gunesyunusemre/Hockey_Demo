using UnityEngine;

namespace AI
{
    [CreateAssetMenu(fileName = "AI_", menuName = "Game/AI/AI Data", order = 0)]
    public class AIData : ScriptableObject
    {
        [SerializeField] private AIDifficultyType difficultyType;

        public AIDifficultyType DifficultyType => difficultyType;
    }
}