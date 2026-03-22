using TMPro;
using UnityEngine;

public class GoodEndPoint : MonoBehaviour
{
    [SerializeField] private GameObject _infoPanel;
    [SerializeField] private TMP_Text _infoText;
    [SerializeField] private PlayerSO _playerSO;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (_playerSO.HasKey)
            {
                _infoPanel.SetActive(true);
                _infoText.text = "You have the key! You win!";
                return;
            }
            else
            {
                _infoPanel.SetActive(true);
                _infoText.text = "You need the key to proceed!";
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _infoPanel.SetActive(false);
        }
    }
}
