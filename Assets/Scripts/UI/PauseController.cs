using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
    [SerializeField] private PanelsController _panelsController;
    [SerializeField] private Button _pauseButton;
    [SerializeField] private Button _resumeButton;
    [SerializeField] private Button _toMainMenuButton;

    [SerializeField] private Slider Music_Slider;
    [SerializeField] private Slider SFX_Slider;
    [SerializeField] private AudioManager audioManager;

    private void Start()
    {
        _pauseButton.onClick.RemoveAllListeners();
        _resumeButton.onClick.RemoveAllListeners();
        _toMainMenuButton.onClick.RemoveAllListeners();
        _pauseButton.onClick.AddListener(PauseGame);
        _resumeButton.onClick.AddListener(ResumeGame);
        _toMainMenuButton.onClick.AddListener(ToMainMenu);

        Music_Slider.onValueChanged.AddListener(audioManager.SetMusicVolume);
        SFX_Slider.onValueChanged.AddListener(audioManager.SetSFXVolume);

        audioManager.SetMusicVolume(Music_Slider.value);
        audioManager.SetSFXVolume(SFX_Slider.value);
    }

    private void SetMusicVolume(float value)
    {
        AudioListener.volume = value;
    }

    private void SetSFXVolume(float value)
    {
        AudioListener.volume = value;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_panelsController.PausePanel.activeSelf)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    private void PauseGame()
    {
        Debug.Log("Pause");
        
        _panelsController.ActivatedPanel(_panelsController.PausePanel);
        Time.timeScale = 0f;
        audioManager.PauseMusic();
    }

    private void ResumeGame()
    {
        Time.timeScale = 1f;
        _panelsController.ActivatedPanel(null);
        audioManager.ResumeMusic();
    }

    private void ToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
