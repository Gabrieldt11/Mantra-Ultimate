using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameModeController : MonoBehaviour
{

    public Image[] image;
    int x = 0;
    bool isOk = true;

    void Start()
    {
        image[x].gameObject.SetActive(true);
        Time.timeScale = 1;
        for (int i = 0; i < GameManager.Instance.PlayerRead.Length; i++)
        {
            GameManager.Instance.PlayerRead[i] = false;
        }
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
    void UpdateButtonUI()
    {
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
                LoadScene("1V1");
            }
            else if (x == 1)
            {
                LoadScene("FFA");
            }
            else if (x == 2)
            {
                LoadScene("Menu");
            }
        }
    }
}
