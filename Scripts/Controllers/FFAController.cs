using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FFAController : MonoBehaviour {
    
    void Update()
    {
        StartCoroutine(PlayersAreRead());
        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            SceneManager.LoadScene("GameMode");
        }
    }

    IEnumerator PlayersAreRead()
    {
        if (GameManager.Instance.PlayerRead[0] && GameManager.Instance.PlayerRead[1] &&
            GameManager.Instance.PlayerRead[2] && GameManager.Instance.PlayerRead[3])
        {
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene("EscolhaDeMapa");
        }
    }
}
