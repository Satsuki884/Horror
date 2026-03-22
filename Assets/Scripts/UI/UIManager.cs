using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private PlayerSO _player;
    [Header("Keys")]
    [SerializeField] private Image _firstKey;
    [SerializeField] private Image _secondKey;
    [SerializeField] private Image _thirdKey;

    [Header("Amulets")]
    [SerializeField] private Image _firstAmulet;
    [SerializeField] private Image _secondAmulet;
    [SerializeField] private Image _thirdAmulet;

    [Header("Stories")]
    [SerializeField] private StoryInfo _firstStory;
    [SerializeField] private StoryInfo _secondStory;
    [SerializeField] private StoryInfo _thirdStory;

    void Start()
    {
        DisableAll();
        UpdateKeysUI();
        UpdateAmuletsUI();
        UpdateStoriesUI();
    }

    private void DisableAll()
    {
        _firstKey.enabled = false;
        _secondKey.enabled = false;
        _thirdKey.enabled = false;

        _firstAmulet.enabled = false;
        _secondAmulet.enabled = false;
        _thirdAmulet.enabled = false;

        _firstStory.gameObject.SetActive(false);
        _secondStory.gameObject.SetActive(false);
        _thirdStory.gameObject.SetActive(false);
    }

    public void UpdateKeysUI()
    {
        _firstKey.enabled = _player.HasFirstKey;
        _secondKey.enabled = _player.HasSecondKey;
        _thirdKey.enabled = _player.HasThirdKey;
    }

    public void UpdateAmuletsUI()
    {
        _firstAmulet.enabled = _player.HasFirstAmulet;
        _secondAmulet.enabled = _player.HasSecondAmulet;
        _thirdAmulet.enabled = _player.HasThirdAmulet;
    }

    public void UpdateStoriesUI()
    {
        _firstStory.gameObject.SetActive(_player.HasFirstStory);
        _secondStory.gameObject.SetActive(_player.HasSecondStory);
        _thirdStory.gameObject.SetActive(_player.HasThirdStory);
    }
}