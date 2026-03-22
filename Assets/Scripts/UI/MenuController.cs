using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private PanelsController _panelsController;
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _quitButton;
    [SerializeField] private Button _infoButton;
    [SerializeField] private Button _closeInfoButton;
    [SerializeField] private PlayerSO _playerSO;

    private bool isSoundEnabled;
    void Start()
    {
        Time.timeScale = 0f;

        InitializeButtons();
    }

    void InitializeButtons()
    {
        _startButton.onClick.RemoveAllListeners();
        _startButton.onClick.AddListener(StartGame);
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
        _playerSO.ResetPlayerData();
    }
}
