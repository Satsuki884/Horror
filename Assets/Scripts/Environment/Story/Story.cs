using TMPro;
using UnityEngine;

public enum StoryType
{
    First, Second, Third
}

public class Story : MonoBehaviour
{
    [SerializeField] private StoryType _type;
    public StoryType Type => _type;
    [SerializeField] private PlayerSO _playerSO;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _playerSO.ObtainStory(_type);
            Destroy(gameObject);
        }
    }
}