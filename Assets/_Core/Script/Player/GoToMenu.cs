using UnityEngine;

public class GoToMenu : MonoBehaviour
{
    #region Settings
    [SerializeField] GameObject resumeMenu;
    [SerializeField] bool menuIsOpen = false;
    #endregion

    #region Meths
    void StartActiv()
    {
        resumeMenu.SetActive(false);
    }
    void OpenMenu()
    {
        if (menuIsOpen)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else if (!menuIsOpen)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            resumeMenu.SetActive(!menuIsOpen);
            Cursor.visible = !menuIsOpen;
            menuIsOpen = !menuIsOpen;
        }
        if (resumeMenu.activeSelf == false)
        {
            menuIsOpen = false;
            Cursor.visible = menuIsOpen;
        }
    }
    #endregion
    #region Meths Unity
    private void Start()
    {
        StartActiv();
    }
    private void Update()
    {
        OpenMenu();
    }
    #endregion
}
