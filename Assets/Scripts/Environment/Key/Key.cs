using UnityEngine;

public enum KeyType
{
    First, Second, Third
}

public class Key : MonoBehaviour
{
    [SerializeField] private KeyType _type;
    public KeyType Type => _type;
    [SerializeField] private PlayerSO _playerSO;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _playerSO.ObtainKey(_type);
            Destroy(gameObject);
        }
    }
}