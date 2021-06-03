using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Image[] image;
    bool isOk = true;
    int x = 0;

    void Start()
    {
        image[x].gameObject.SetActive(true);
    }

    void Update()
    {
        UpdateButtonUI();
        ConfirmButton();
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void UpdateButtonUI()
    {
        Debug.Log(x);

        image[x].gameObject.SetActive(true);

        if (Input.GetAxisRaw("Joy1LeftStickVertical") == -1 && isOk)
        {
            isOk = false;
            image[x].gameObject.SetActive(false);
            x--;
            if (x < 0)
            {
                x = 2;
            }
        }
        else if (Input.GetAxisRaw("Joy1LeftStickVertical") == 0)
        {
            isOk = true;
        }
        else if (Input.GetAxisRaw("Joy1LeftStickVertical") == 1 && isOk)
        {
            isOk = false;
            image[x].gameObject.SetActive(false);
            x++;
            if (x > 2)
            {
                x = 0;
            }
        }
    }

    void ConfirmButton()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
            if (x == 0)
            {
                LoadScene("GameMode");
            }
            else if (x == 1)
            {
                LoadScene("Options");
            }
            else if (x == 2)
            {
                QuitGame();
            }
        }
    }
}
