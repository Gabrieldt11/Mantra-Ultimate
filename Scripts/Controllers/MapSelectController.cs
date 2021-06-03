using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapSelectController : MonoBehaviour
{
    public Image[] image;
    int x = 0;
    bool isOk = true;

    void Start()
    {
        image[x].gameObject.SetActive(true);
    }

    void Update()
    {
        UpdateButtonUI();
        ConfirmButton();
    }

    public void LoadScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    void UpdateButtonUI()
    {
        Debug.Log(x);

        image[x].gameObject.SetActive(true);

        if (Input.GetAxisRaw("Joy1LeftStickHorizontal") == -1 && isOk)
        {
            isOk = false;
            image[x].gameObject.SetActive(false);
            x--;
            if (x < 0)
            {
                x = 2;
            }
        }
        else if (Input.GetAxisRaw("Joy1LeftStickHorizontal") == 0)
        {
            isOk = true;
        }
        else if (Input.GetAxisRaw("Joy1LeftStickHorizontal") == 1 && isOk)
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
            image[x].color = Color.green;
            if (x == 0)
            {
                LoadScene("MapaMinas");
            }
            else if (x == 1)
            {
                LoadScene("MapaLaboratorio");
            }
            else if (x == 2)
            {
                LoadScene("MapaSaloon");
            }
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            LoadScene("GameMode");
        }
    }
}
