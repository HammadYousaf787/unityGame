using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LossScreenUI : MonoBehaviour
{
    public Button retryButton; // Reference to the Button component for retrying the level
    public string retryLevelName; // Name of the next level to load

    public void RetryLevel()
    {
        // Ensure the references are set
        if ( retryButton == null)
        {
            Debug.LogError("LossScreenUI: Please assign the Text and Button components in the Inspector.");
            return;
        }


        SceneManager.LoadScene(retryLevelName);
    }


}
