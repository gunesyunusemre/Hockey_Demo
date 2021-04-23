using UnityEngine;

namespace AI
{
    [CreateAssetMenu(fileName = "AI_", menuName = "Game/AI/AI Data", order = 0)]
    public class AIData : ScriptableObject
    {
        //Bu script oyun içerisindeyken zorluğu değiştirebileceğimiz scriptable objeyi
        //üretmemizi sağlar. Bu scriptable obje Asset/Scriptables/AI dizininde bulunur.
        
        //variable
        [SerializeField] private AIDifficultyType difficultyType;

        //Capsullation
        public AIDifficultyType DifficultyType => difficultyType;
    }
}