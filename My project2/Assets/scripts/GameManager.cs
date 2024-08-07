using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject startingUI;
    public string sceneName;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        ShowStartingUI();
    }

    public void StartGame()
    {
        // Hide the starting UI and load the first game scene
        HideStartingUI();
        SceneManager.LoadScene("level1"); // Make sure to replace "Level1" with your actual scene name
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game is quitting...");
    }

    private void ShowStartingUI()
    {
        if (startingUI != null)
        {
            startingUI.SetActive(true);
        }
    }

    private void HideStartingUI()
    {
        if (startingUI != null)
        {
            startingUI.SetActive(false);
        }
    }
}
