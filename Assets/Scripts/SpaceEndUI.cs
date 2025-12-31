using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceEndUI : MonoBehaviour
{
    [Header("Scene Names")]
    public string consoleRoomSceneName = "SampleScene";

    public void OnExitGameClicked()
    {
        Debug.Log("Exit game clicked");
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void OnBackToConsoleClicked()
    {
        Debug.Log("Back to console room clicked");
        SceneManager.LoadScene(consoleRoomSceneName);
    }
}
