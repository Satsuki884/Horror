using UnityEngine;
public enum AmuletType
{
    First, Second, Third
}

public class Amulet : MonoBehaviour
{
    [SerializeField] private AmuletType _type;
    public AmuletType Type => _type;
    [SerializeField] private PlayerSO _playerSO;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _playerSO.ObtainAmulet(_type);
            Destroy(gameObject);
        }
    }
}