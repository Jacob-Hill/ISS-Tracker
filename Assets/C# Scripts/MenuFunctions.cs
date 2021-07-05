using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuFunctions : MonoBehaviour
{
    private GameObject PositionPanel;
    private GameObject Menu;
    bool MenuOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "ISS Tracking")
        {
            PositionPanel = GameObject.Find("PositionPanel");
            Menu = GameObject.Find("Menu");
            Menu.transform.localScale = Vector3.zero;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "ISS Tracking")
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (MenuOpen)
                {
                    CloseMenu();
                }
                else
                {
                    OpenMenu();
                }
            }
        }
    }

    void OpenMenu()
    {
        MenuOpen = true;
        PositionPanel.transform.localScale = Vector3.zero;
        Menu.transform.localScale = Vector3.one;
    }

    public void CloseMenu()
    {
        MenuOpen = false;
        PositionPanel.transform.localScale = Vector3.one;
        Menu.transform.localScale = Vector3.zero;
    }

    public void ExitProgram()
    {
        Application.Quit();
    }

    public void SwapScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        if(scene.name == "Main Menu")
        {
            SceneManager.LoadSceneAsync("ISS Tracking");
        }
        else
        {
            SceneManager.LoadSceneAsync("Main Menu");
        }
    }
}
