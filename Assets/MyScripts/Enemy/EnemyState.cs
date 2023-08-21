interface IEnemyState
{
    void Normal();
    void Aggressive();
}

public class EnemyState
{
    public enum State
    {
        Normal,
        Aggressive,
        Negative
    }
    public State state;
}