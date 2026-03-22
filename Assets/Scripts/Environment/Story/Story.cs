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
    [SerializeField] private GameObject _storyUI;
    [SerializeField] private TMP_Text _storyText;
    [SerializeField] private string _storyContent;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _playerSO.ObtainStory(_type);
            _storyText.text = _storyContent;
            _storyUI.SetActive(true);
            Destroy(gameObject, 0.5f);
        }
    }
}