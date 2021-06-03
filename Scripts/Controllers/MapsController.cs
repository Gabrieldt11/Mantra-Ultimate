using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MapsController : MonoBehaviour
{
    public Transform[] spawnPoint;
    public GameObject pausePanel;
    public GameObject hudPanelFfa;
    public GameObject hudPanel1V1;
    public Image[] lifeBar;
    public Image[] spellBar;
    public Image[] spellBar2;
    PlayerControll player1;
    PlayerControll player2;
    PlayerControll player3;
    PlayerControll player4;


    void Awake()
    {
        int i = GameManager.Instance.CharacterIndex[0];
        int j = GameManager.Instance.CharacterIndex[1];
        int k = GameManager.Instance.CharacterIndex[2];
        int l = GameManager.Instance.CharacterIndex[3];

        if (GameManager.Instance.PlayerRead[0])
        {
            player1 = Instantiate(GameManager.Instance.Characters[i], spawnPoint[0].transform).GetComponent<PlayerControll>();
            player1.SetController(1);
        }
        if (GameManager.Instance.PlayerRead[1])
        {
            player2 = Instantiate(GameManager.Instance.Characters[j], spawnPoint[1].transform).GetComponent<PlayerControll>();
            player2.SetController(2);
        }
        if (GameManager.Instance.PlayerRead[2])
        {
            player3 = Instantiate(GameManager.Instance.Characters[k], spawnPoint[2].transform).GetComponent<PlayerControll>();
            player3.SetController(3);
        }
        if (GameManager.Instance.PlayerRead[3])
        {
            player4 = Instantiate(GameManager.Instance.Characters[l], spawnPoint[3].transform).GetComponent<PlayerControll>();
            player4.SetController(4);
        }
    }

    void Start()
    {
        if (GameManager.Instance.PlayerRead[2] && GameManager.Instance.PlayerRead[3])
        {
            hudPanelFfa.SetActive(true);
        }
        else
        {
            hudPanel1V1.SetActive(true);
        }
    }

    void Update()
    {
        StartCoroutine(Cooldown());

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            pausePanel.SetActive(true);
        }
        if (hudPanel1V1.activeSelf)
        {
            if (GameManager.Instance.PlayerRead[0])
            {
                lifeBar[0].fillAmount = player1.life * 0.01f;
            }
            if (GameManager.Instance.PlayerRead[1])
            {
                lifeBar[1].fillAmount = player2.life * 0.01f;
            }
        }
        if (hudPanelFfa.activeSelf)
        {
            if (GameManager.Instance.PlayerRead[0])
            {
                lifeBar[2].fillAmount = player1.life * 0.01f;
            }
            if (GameManager.Instance.PlayerRead[1])
            {
                lifeBar[3].fillAmount = player2.life * 0.01f;
            }
            if (GameManager.Instance.PlayerRead[2])
            {
                lifeBar[4].fillAmount = player3.life * 0.01f;
            }
            if (GameManager.Instance.PlayerRead[3])
            {
                lifeBar[5].fillAmount = player4.life * 0.01f;
            }
        }
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void LoadScene(string newScene)
    {
        SceneManager.LoadScene(newScene);
    }

    IEnumerator Cooldown()
    {
        if (!GameManager.Instance.PlayerRead[2])
        {
            if (Input.GetKeyDown(KeyCode.Joystick1Button3) && spellBar[0].fillAmount == 1)
            {
                spellBar[0].fillAmount = 0;
                yield return new WaitForSeconds(2f);
                spellBar[0].fillAmount = 1f;
                yield return null;
            }
            if (Input.GetKeyDown(KeyCode.Joystick1Button2) && spellBar2[0].fillAmount == 1)
            {
                spellBar2[0].fillAmount = 0;
                yield return new WaitForSeconds(4f);
                spellBar2[0].fillAmount = 1f;
            }

            if (Input.GetKeyDown(KeyCode.Joystick2Button3) && spellBar[1].fillAmount == 1)
            {
                spellBar[1].fillAmount = 0;
                yield return new WaitForSeconds(2f);
                spellBar[1].fillAmount = 1f;
            }
            if (Input.GetKeyDown(KeyCode.Joystick2Button2) && spellBar2[1].fillAmount == 1)
            {
                spellBar2[1].fillAmount = 0;
                yield return new WaitForSeconds(4f);
                spellBar2[1].fillAmount = 1f;
            }
        }

        if (GameManager.Instance.PlayerRead[2])
        {
            if (Input.GetKeyDown(KeyCode.Joystick1Button3) && spellBar[2].fillAmount == 1)
            {
                spellBar[2].fillAmount = 0;
                yield return new WaitForSeconds(2f);
                spellBar[2].fillAmount = 1f;
            }
            if (Input.GetKeyDown(KeyCode.Joystick1Button2) && spellBar2[2].fillAmount == 1)
            {
                spellBar2[2].fillAmount = 0;
                yield return new WaitForSeconds(4f);
                spellBar2[2].fillAmount = 1f;
            }

            if (Input.GetKeyDown(KeyCode.Joystick2Button3) && spellBar[3].fillAmount == 1)
            {
                spellBar[3].fillAmount = 0;
                yield return new WaitForSeconds(2f);
                spellBar[3].fillAmount = 1f;
            }
            if (Input.GetKeyDown(KeyCode.Joystick2Button2) && spellBar2[3].fillAmount == 1)
            {
                spellBar2[3].fillAmount = 0;
                yield return new WaitForSeconds(4f);
                spellBar2[3].fillAmount = 1f;
            }

            if (Input.GetKeyDown(KeyCode.Joystick3Button3) && spellBar[4].fillAmount == 1)
            {
                spellBar[4].fillAmount = 0;
                yield return new WaitForSeconds(2f);
                spellBar[4].fillAmount = 1f;
            }
            if (Input.GetKeyDown(KeyCode.Joystick3Button2) && spellBar2[4].fillAmount == 1)
            {
                spellBar2[4].fillAmount = 0;
                yield return new WaitForSeconds(4f);
                spellBar2[4].fillAmount = 1f;
            }

            if (Input.GetKeyDown(KeyCode.Joystick4Button3) && spellBar[5].fillAmount == 1)
            {
                spellBar[5].fillAmount = 0;
                yield return new WaitForSeconds(2f);
                spellBar[5].fillAmount = 1f;
            }
            if (Input.GetKeyDown(KeyCode.Joystick4Button2) && spellBar2[5].fillAmount == 1)
            {
                spellBar2[5].fillAmount = 0;
                yield return new WaitForSeconds(4f);
                spellBar2[5].fillAmount = 1f;
            }
        }
    }
}
