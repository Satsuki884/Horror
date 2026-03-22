public enum PuzzleType
{
    None, First, Second, Third, Last, Random
}

public interface IPuzzle
{
    bool IsSolved { get; }
    void Activate();
    void Deactivate();
    void Reset();
    PuzzleType Type { get; }

}