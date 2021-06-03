using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceControllerP1 : MonoBehaviour
{

    private int characterIndex;
    public int controller;

    [SerializeField] private List<Champions> characterList = new List<Champions>();

    [SerializeField] private Text characterName;
    [SerializeField] private Image characterSplash;

    public Button leftButton;
    public Button rightButton;

    bool isOk = true;
    bool isConfirmed = false;

    void Start()
    {
        GameManager.Instance.Controller[0] = 1;
    }

    void Update()
    {
        LeftSide();
        RightSide();
        ConfirmSelection();
        UpdateCharacterSelectionUI();
    }

    void LeftSide()
    {
        if (Input.GetAxis("Joy" + controller + "LeftStickHorizontal") == -1 && isOk && !isConfirmed)
        {
            isOk = false;
            characterIndex--;
            if (characterIndex < 0)
            {
                characterIndex = characterList.Count - 1;
            }
            leftButton.image.color = Color.red;

            UpdateCharacterSelectionUI();
        }
        if (Input.GetAxis("Joy" + controller + "LeftStickHorizontal") == 0)
        {
            isOk = true;
            leftButton.image.color = Color.white;
        }
    }

    void RightSide()
    {
        if (Input.GetAxis("Joy" + controller + "LeftStickHorizontal") == 1 && isOk && !isConfirmed)
        {
            isOk = false;
            characterIndex++;
            if (characterIndex == characterList.Count)
            {
                characterIndex = 0;
            }
            rightButton.image.color = Color.red;

            UpdateCharacterSelectionUI();
        }
        if (Input.GetAxis("Joy" + controller + "LeftStickHorizontal") == 0)
        {
            isOk = true;
            rightButton.image.color = Color.white;
        }
    }

    void ConfirmSelection()
    {
        if (Input.GetAxisRaw("Joy" + controller + "Button2") == 1)
        {
            Debug.Log(characterIndex);
            isConfirmed = true;
            GameManager.Instance.CharacterIndex[controller - 1] = characterIndex;
            GameManager.Instance.PlayerRead[controller - 1] = true;
        }
        if (Input.GetAxisRaw("Joy" + controller + "Button1") == 1)
        {
            isConfirmed = false;
            GameManager.Instance.PlayerRead[controller - 1] = false;
        }

        if (isConfirmed)
        {
            leftButton.image.color = Color.green;
            rightButton.image.color = Color.green;
        }
    }

    private void UpdateCharacterSelectionUI()
    {
        characterSplash.sprite = characterList[characterIndex].splash;
        characterName.text = characterList[characterIndex].characterName;
    }
}
