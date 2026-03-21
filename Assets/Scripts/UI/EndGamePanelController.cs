using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGamePanelController : MonoBehaviour
{
    [SerializeField] private TMP_Text _endGameText;
    public TMP_Text EndGameText => _endGameText;
    [SerializeField] private Button _toMainMenuButton;

    private void Start()
    {
        _toMainMenuButton.onClick.RemoveAllListeners();
        _toMainMenuButton.onClick.AddListener(ToMainMenu);
    }

    private void ToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
