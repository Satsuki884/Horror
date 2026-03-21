using UnityEngine;
using UnityEngine.UI;

public class InfoPanelController : MonoBehaviour
{
    [SerializeField] private GameObject _infoPanel;

    private void Start()
    {
        _infoPanel.SetActive(false);
    }
}