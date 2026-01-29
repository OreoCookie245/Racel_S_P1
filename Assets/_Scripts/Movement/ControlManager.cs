using UnityEngine;
using UnityEngine.UI;

public class ControlManager : MonoBehaviour
{
    public Button ControlType1;
    public Button ControlType2;
    public Button ControlType3;

    public GameObject menuCanvas;

    private int currentProfile = 1;
    private bool menuOpen = false;

    public enum ControllerStickSetup { Default, SwapLeftRight, Custom }
    private ControllerStickSetup stickSetup = ControllerStickSetup.Default;

    void Awake()
    {
        //Canvas is hidden at start
        if (menuCanvas != null)
            menuCanvas.SetActive(false);
        LockCursor(true);
    }

    void Start()
    {
        LoadProfile();
    }

    void Update()
    {
        //Only detect ESC if Canvas is assigned
        if (menuCanvas == null)
            return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMenu();
        }
    }

    void ToggleMenu()
    {
        menuOpen = !menuOpen;
        menuCanvas.SetActive(menuOpen);
        LockCursor(!menuOpen);

        //Pause game when menu open
        Time.timeScale = menuOpen ? 0f : 1f;
    }

    void LockCursor(bool locked)
    {
        Cursor.lockState = locked ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !locked;
    }

    void SwitchProfile(int profileNumber)
    {
        currentProfile = profileNumber;

        //Apply stick mapping
        switch (currentProfile)
        {
            case 1: stickSetup = ControllerStickSetup.Default; break;
            case 2: stickSetup = ControllerStickSetup.SwapLeftRight; break;
            case 3: stickSetup = ControllerStickSetup.Custom; break;
        }

        SaveProfile();
        Debug.Log("Switched to Controller Profile " + currentProfile + " (" + stickSetup + ")");
    }

    void SaveProfile()
    {
        PlayerPrefs.SetInt("ControllerProfile", currentProfile);
        PlayerPrefs.Save();
    }

    void LoadProfile()
    {
        currentProfile = PlayerPrefs.GetInt("ControllerProfile", 1);
        SwitchProfile(currentProfile);
    }

    public ControllerStickSetup GetStickSetup()
    {
        return stickSetup;
    }
}
