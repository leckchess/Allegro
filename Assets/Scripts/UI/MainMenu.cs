using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : Window
{
    [SerializeField]
    private Button _playButton;

    private void Start()
    {
        _playButton.onClick.AddListener(() => 
        {
            SceneManager.LoadScene(1);
        });
    }
}
