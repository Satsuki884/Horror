using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private PanelsController _panelsController;
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _quitButton;
    [SerializeField] private Button _infoButton;
    [SerializeField] private Button _closeInfoButton;
    [SerializeField] private Button _soundButton;

    [Header("Sound")]
    [SerializeField] private Image _soundIcon;
    [SerializeField] private Sprite _soundOnSprite;
    [SerializeField] private Sprite _soundOffSprite;
    private bool isSoundEnabled;
    void Start()
    {
        Time.timeScale = 0f;

        InitializeButtons();
        SoundStart();
    }

    void InitializeButtons()
    {
        _startButton.onClick.RemoveAllListeners();
        _startButton.onClick.AddListener(StartGame);
        _soundButton.onClick.RemoveAllListeners();
        _soundButton.onClick.AddListener(SoundOnOff);
        _infoButton.onClick.RemoveAllListeners();
        _infoButton.onClick.AddListener(() => _panelsController.ActivatedPanel(_panelsController.InfoPanel));
        _closeInfoButton.onClick.RemoveAllListeners();
        _closeInfoButton.onClick.AddListener(() => _panelsController.ActivatedPanel(_panelsController.MainMenuPanel));
        _quitButton.onClick.RemoveAllListeners();
        _quitButton.onClick.AddListener(Application.Quit);
    }

    void StartGame()
    {
        Time.timeScale = 1f;
        _panelsController.ActivatedPanel(null);
    }

    void SoundOnOff()
    {
        isSoundEnabled = !isSoundEnabled;

        AudioListener.volume = isSoundEnabled ? 1f : 0f;

        PlayerPrefs.SetInt("Sound", isSoundEnabled ? 1 : 0);

        UpdateSoundIcon();
    }

    void SoundStart()
    {
        isSoundEnabled = PlayerPrefs.GetInt("Sound", 1) == 1;

        AudioListener.volume = isSoundEnabled ? 1f : 0f;

        UpdateSoundIcon();
    }

    void UpdateSoundIcon()
    {
        if (_soundIcon != null)
        {
            _soundIcon.sprite = isSoundEnabled ? _soundOnSprite : _soundOffSprite;
        }
    }
}
