using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionMenuController : MonoBehaviour
{
    int i = 0;
    bool isOk = true;
    public GameObject[] audioHand;

    void Update()
    {
        AudioController();
        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            LoadScene("Menu");
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    void AudioController()
    {
        audioHand[i].SetActive(true);
        if (Input.GetAxisRaw("Joy1LeftStickHorizontal") == 1 && isOk)
        {
            isOk = false;
            audioHand[i].SetActive(false);
            i++;
            if (i >= 10)
            {
                i = 0;
            }
        }
        else if (Input.GetAxisRaw("Joy1LeftStickHorizontal") == 0)
        {
            isOk = true;
        }
        else if (Input.GetAxisRaw("Joy1LeftStickHorizontal") == -1 && isOk)
        {
            isOk = false;
            audioHand[i].SetActive(false);
            i--;
            if (i <= -1)
            {
                i = 9;
            }
        }
    }
}
