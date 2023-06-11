interface IEnemyState
{
    void Normal();
    void Aggressive();
    void Negative();
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