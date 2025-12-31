using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorExitZone : MonoBehaviour
{
    [SerializeField] private string spaceEndSceneName = "SpaceEndScene";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        Debug.Log("KISZÖKÖTT");
        SceneManager.LoadScene(spaceEndSceneName);
    }
}
