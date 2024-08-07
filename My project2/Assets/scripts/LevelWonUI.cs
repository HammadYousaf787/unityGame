using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelWonUI : MonoBehaviour
{
    public Button nextLevelButton; // Reference to the Button component for proceeding to the next level
    public string nextLevelName; // Name of the next level to load

    public void NextLevel()
    {
        // Ensure the references are set
        if (nextLevelButton == null)
        {
            Debug.LogError("LevelWonUI: Please assign the Text and Button components in the Inspector.");
            return;
        }


        // Add a listener to the button to call the LoadNextLevel method when clicked
        SceneManager.LoadScene(nextLevelName);
    }

}
