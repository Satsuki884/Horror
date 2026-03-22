using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSO", menuName = "ScriptableObjects/Player")]
public class PlayerSO : ScriptableObject
{
    [SerializeField] private float _walkSpeed = 5f;
    public float WalkSpeed => _walkSpeed;
    [SerializeField] private bool _hasKey = false;
    public bool HasKey => _hasKey;
    [SerializeField] private bool _hasFirstKey = false;
    public bool HasFirstKey => _hasFirstKey;
    [SerializeField] private bool _hasSecondKey = false;
    public bool HasSecondKey => _hasSecondKey;
    [SerializeField] private bool _hasThirdKey = false;
    public bool HasThirdKey => _hasThirdKey;
    [SerializeField] private bool _hasAmulet = false;
    public bool HasAmulet => _hasAmulet;
    [SerializeField] private bool _hasFirstAmulet = false;
    public bool HasFirstAmulet => _hasFirstAmulet;
    [SerializeField] private bool _hasSecondAmulet = false;
    public bool HasSecondAmulet => _hasSecondAmulet;
    [SerializeField] private bool _hasThirdAmulet = false;
    public bool HasThirdAmulet => _hasThirdAmulet;
    [SerializeField] private bool _hasFirstStory = false;
    public bool HasFirstStory => _hasFirstStory;
    [SerializeField] private bool _hasSecondStory = false;
    public bool HasSecondStory => _hasSecondStory;
    [SerializeField] private bool _hasThirdStory = false;
    public bool HasThirdStory => _hasThirdStory;

    public void ObtainKey(KeyType type)
    {
        switch (type)
        {
            case KeyType.First:
                _hasFirstKey = true;
                break;
            case KeyType.Second:
                _hasSecondKey = true;
                break;
            case KeyType.Third:
                _hasThirdKey = true;
                break;
        }
        UpdateUI();
        _hasKey = _hasFirstKey && _hasSecondKey && _hasThirdKey;
    }

    public void ObtainAmulet(AmuletType type)
    {
        switch (type)
        {
            case AmuletType.First:
                _hasFirstAmulet = true;
                break;
            case AmuletType.Second:
                _hasSecondAmulet = true;
                break;
            case AmuletType.Third:
                _hasThirdAmulet = true;
                break;
        }
        UpdateUI();
        _hasAmulet = _hasFirstAmulet && _hasSecondAmulet && _hasThirdAmulet;
    }



    public void ObtainStory(StoryType type)
    {
        switch (type)
        {
            case StoryType.First:
                _hasFirstStory = true;
                break;
            case StoryType.Second:
                _hasSecondStory = true;
                break;
            case StoryType.Third:
                _hasThirdStory = true;
                break;
        }
        UpdateUI();
    }

    private void UpdateUI()
    {
        UIManager ui = FindAnyObjectByType<UIManager>();

        if (ui != null)
        {
            ui.UpdateKeysUI();
            ui.UpdateAmuletsUI();
            ui.UpdateStoriesUI();
        }
    }
}