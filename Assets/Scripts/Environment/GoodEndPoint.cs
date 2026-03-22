using TMPro;
using UnityEngine;

public class GoodEndPoint : MonoBehaviour
{
    [SerializeField] private GameObject _infoPanel;
    [SerializeField] private TMP_Text _infoText;
    [SerializeField] private PlayerSO _playerSO;
    [SerializeField] private GameObject _endPanel;
    [SerializeField] private TMP_Text _endText;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (_playerSO.HasKey)
            {
                _endPanel.SetActive(true);
                // Time.timeScale = 0f; // Pause the game
                _endText.text = "Fresh air brushes against your face, yet what you have witnessed here will stay with you forever.";
                return;
            }
            else
            {
                _infoPanel.SetActive(true);
                _infoText.text = "You need keys to proceed!";
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _infoPanel.SetActive(false);
            _endPanel.SetActive(false);
        }
    }
}
