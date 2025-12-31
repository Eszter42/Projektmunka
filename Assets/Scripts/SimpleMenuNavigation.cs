using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class SimpleMenuNavigation : MonoBehaviour
{
    [Header("Buttons in order (Left → Right)")]
    public Button leftButton;
    public Button rightButton;

    private int currentIndex = 0;

    void Start()
    {
        SelectButton(0);
    }

    void Update()
    {
        if (Keyboard.current == null)
            return;

        if (Keyboard.current.aKey.wasPressedThisFrame ||
            Keyboard.current.leftArrowKey.wasPressedThisFrame)
        {
            SelectButton(0);
        }

        if (Keyboard.current.dKey.wasPressedThisFrame ||
            Keyboard.current.rightArrowKey.wasPressedThisFrame)
        {
            SelectButton(1);
        }

        if (Keyboard.current.eKey.wasPressedThisFrame ||
            Keyboard.current.enterKey.wasPressedThisFrame)
        {
            Button current =
                (currentIndex == 0) ? leftButton : rightButton;

            if (current != null)
                current.onClick.Invoke();
        }
    }

    private void SelectButton(int index)
    {
        currentIndex = index;

        Button btn = (index == 0) ? leftButton : rightButton;
        if (btn == null)
            return;

        EventSystem.current.SetSelectedGameObject(btn.gameObject);
    }
}
