using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Menu : MonoBehaviour
{
    [SerializeField]
    private GameObject _panel;
    [SerializeField]
    private Text _statusText;

    private bool end = false;

    private void Start()
    {
        GameObject.Find("Player").GetComponent<Character>().OnKilled += OnPlayerKilled;
    }

    private void OnPlayerKilled(GameObject player)
    {
        player.GetComponent<Character>().OnKilled -= OnPlayerKilled;
        end = true;
        ShowPanel("Game Over");
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ShowPanel("Pause");
        }
    }

    private void ShowPanel(string statusText)
    {
        if(!_panel.gameObject.activeSelf || end)
        {
            _panel.gameObject.SetActive(true);
            _statusText.text = statusText;
        }
        else if(!end)
        {
            _panel.gameObject.SetActive(false);
        }
    }
}
