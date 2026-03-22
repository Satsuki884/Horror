using TMPro;
using UnityEngine;

public class BadEndPoint : MonoBehaviour
{
    [SerializeField] private GameObject _infoPanel;
    [SerializeField] private TMP_Text _infoText;
    [SerializeField] private GameObject _endPanel;
    [SerializeField] private TMP_Text _endText;
    [SerializeField] private PlayerSO _playerSO;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (_playerSO.HasAmulet)
            {
                _endPanel.SetActive(true);
                // Time.timeScale = 0f; // Pause the game
                _endText.text = "Beneath the crushing weight of the stone mask, your head falls from your shoulders, offering a final sacrifice to the last god.";
                return;
            }
            else
            {
                _infoPanel.SetActive(true);
                _infoText.text = "You need amulets to proceed!";
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
