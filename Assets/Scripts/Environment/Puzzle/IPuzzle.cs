public enum PuzzleType
{
    None, Switch, Lever, Button
}

public interface IPuzzle
{
    bool IsSolved { get; }
    void Activate();
    void Deactivate();
    void Reset();
    PuzzleType Type { get; }
    
}