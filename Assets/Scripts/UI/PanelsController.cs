using System;
using UnityEngine;

public class PanelsController : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenuPanel;
    public GameObject MainMenuPanel => _mainMenuPanel;
    [SerializeField] private GameObject _infoPanel;
    public GameObject InfoPanel => _infoPanel;
    [SerializeField] private GameObject _gamePanel;
    public GameObject GamePanel => _gamePanel;
    [SerializeField] private GameObject _endGamePanel;
    public GameObject EndGamePanel => _endGamePanel;
    [SerializeField] private GameObject _pausePanel;
    public GameObject PausePanel => _pausePanel;
    [SerializeField] private GameObject _storyPanel;
    public GameObject StoryPanel => _storyPanel;

    public void Start()
    {
        _mainMenuPanel.SetActive(true);
        _infoPanel.SetActive(false);
        _gamePanel.SetActive(false);
        _endGamePanel.SetActive(false);
        _pausePanel.SetActive(false);
        _storyPanel.SetActive(false);

    }

    public void ActivatedPanel(GameObject panel)
    {
        if (panel == null)
        {
            _mainMenuPanel.SetActive(false);
            _infoPanel.SetActive(false);
            _gamePanel.SetActive(false);
            _endGamePanel.SetActive(false);
            _pausePanel.SetActive(false);
            return;
        }
        _mainMenuPanel.SetActive(panel == _mainMenuPanel);
        _infoPanel.SetActive(panel == _infoPanel);
        _gamePanel.SetActive(panel == _gamePanel);
        _endGamePanel.SetActive(panel == _endGamePanel);
        _pausePanel.SetActive(panel == _pausePanel);
    }

}
