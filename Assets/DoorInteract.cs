using UnityEngine;
using UnityEngine.InputSystem;

public class DoorInteract : MonoBehaviour
{
    [Header("References")]
    public GameObject doorObject;
    public GameObject interactText;

    [Header("Sprites")]
    public Sprite closedDoorSprite;
    public Sprite openDoorSprite;

    [Header("Sorting Layers")]
    public string closedSortingLayer = "Collision";
    public string openSortingLayer = "WalkBehind";

    private bool playerInRange = false;
    private bool isOpen = false;

    private Collider2D doorCollider;
    private SpriteRenderer doorRenderer;

    void Start()
    {
        if (doorObject != null)
        {
            doorCollider = doorObject.GetComponent<Collider2D>();
            doorRenderer = doorObject.GetComponent<SpriteRenderer>();
        }

        if (interactText != null)
            interactText.SetActive(false);

        if (doorRenderer != null && closedDoorSprite != null)
        {
            doorRenderer.sprite = closedDoorSprite;
            doorRenderer.sortingLayerName = closedSortingLayer;
        }

        if (doorCollider != null)
            doorCollider.enabled = true;

        isOpen = false;
    }

    void Update()
    {
        if (!playerInRange || doorRenderer == null || doorCollider == null)
            return;

        if (Keyboard.current != null && Keyboard.current.eKey.wasPressedThisFrame)
        {
            if (!isOpen)
                OpenDoor();
            else
                CloseDoor();
        }
    }

    private void OpenDoor()
    {
        isOpen = true;

        doorCollider.enabled = false;

        if (openDoorSprite != null)
            doorRenderer.sprite = openDoorSprite;

        if (!string.IsNullOrEmpty(openSortingLayer))
            doorRenderer.sortingLayerName = openSortingLayer;

        UpdateInteractText();

        Debug.Log("Ajtó kinyitva");
    }

    private void CloseDoor()
    {
        isOpen = false;

        doorCollider.enabled = true;

        if (closedDoorSprite != null)
            doorRenderer.sprite = closedDoorSprite;

        if (!string.IsNullOrEmpty(closedSortingLayer))
            doorRenderer.sortingLayerName = closedSortingLayer;

        UpdateInteractText();

        Debug.Log("Ajtó bezárva");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        playerInRange = true;

        if (interactText != null)
        {
            interactText.SetActive(true);
            UpdateInteractText();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        playerInRange = false;

        if (interactText != null)
            interactText.SetActive(false);
    }
    private void UpdateInteractText()
    {
        if (!playerInRange || interactText == null)
            return;

        string text = isOpen ? "(E) Close door" : "(E) Open door";

        var tmp = interactText.GetComponent<TMPro.TextMeshProUGUI>();
        if (tmp != null)
        {
            tmp.text = text;
            return;
        }

        var uiText = interactText.GetComponent<UnityEngine.UI.Text>();
        if (uiText != null)
        {
            uiText.text = text;
        }
    }
}
