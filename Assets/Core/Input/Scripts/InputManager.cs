using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    public event Action ClickToScreenEvent;   
    public event Action ClickRightEvent;

    private InputControls _inputControls;

    private void Awake()
    {
        _inputControls = new InputControls();

        _inputControls.TapToSceen.TapToScreen.performed += context => ClickToScreen();

        // TODO: Після тестів видалити
        _inputControls.TapToSceen.MouseRghtButton.performed += context => ClickRight();

        if (Instance == null)
        {
            Instance = this as InputManager;
            DontDestroyOnLoad(gameObject);
            return;
        }
        Destroy(Instance.gameObject);
    }

    private void OnEnable() => _inputControls.Enable();
    private void OnDisable() => _inputControls.Disable();
    private void ClickToScreen() => ClickToScreenEvent.Invoke();
    private void ClickRight() => ClickRightEvent.Invoke();

}
