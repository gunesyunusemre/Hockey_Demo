namespace AI.AIState
{
    public abstract class AIBaseState
    {
        public AIDifficultyType DifType;
        public abstract void EnterState(AIController AI);

        public abstract void Update(AIController AI);
    }
}