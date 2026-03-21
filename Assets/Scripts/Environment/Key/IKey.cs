public enum KeyType
{
    None, First, Second, Third, Last, Random
}

public interface IKey
{
    bool IsSolved { get; }
    void Activate();
    void Deactivate();
    void Reset();
    PuzzleType Type { get; }
    
}