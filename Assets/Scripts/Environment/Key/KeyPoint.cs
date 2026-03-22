using UnityEngine;

public class KeyPoint : MonoBehaviour
{
    [SerializeField] private bool _triggered;

    public bool IsOccupied => _triggered;

    public void SetOccupied(bool value)
    {
        _triggered = value;
    }
}