using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class StoryInfo : MonoBehaviour
{
    [SerializeField] private TMP_Text letterContent;
    [SerializeField] private string letterTitle;
    [SerializeField] private GameObject _textPanel;

    private Button _tellStoryButton;

    void Start()
    {
        _tellStoryButton = GetComponent<Button>();
        _tellStoryButton.onClick.RemoveAllListeners();
        _tellStoryButton.onClick.AddListener(TellStory);
    }

    void Update()
    {
        if (_textPanel.activeSelf && Input.GetMouseButtonDown(0))
        {
            if (!IsPointerOverUI(_textPanel))
            {
                _textPanel.SetActive(false);
                // Time.timeScale = 1f; // Resume the game

            }
        }
    }

    public void TellStory()
    {
        _textPanel.SetActive(true);
        letterContent.text = letterTitle;
        // Time.timeScale = 0f; // Pause the game
    }

    private bool IsPointerOverUI(GameObject target)
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        foreach (var result in results)
        {
            if (result.gameObject.transform.IsChildOf(target.transform))
                return true;
        }

        return false;
    }
}