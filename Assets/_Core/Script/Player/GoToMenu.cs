using UnityEngine;

public class GoToMenu : MonoBehaviour
{
    [SerializeField] GameObject resumeMenu;
    [SerializeField] bool menuIsOpen = false;

    private void Start()
    {
        resumeMenu.SetActive(false);
    }
    private void Update()
    {
        if (menuIsOpen)
        {
            Cursor.lockState = CursorLockMode.None;
        }else if (!menuIsOpen)
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
}
