using TMPro;
using UnityEngine;

public class StoryLetter : MonoBehaviour
{
    [SerializeField] private TMP_Text letterContent;
    [SerializeField] private string letterTitle;
    [SerializeField] private GameObject _textPanel;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _textPanel.SetActive(true);
            letterContent.text = letterTitle;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _textPanel.SetActive(false);
        }
    }
}