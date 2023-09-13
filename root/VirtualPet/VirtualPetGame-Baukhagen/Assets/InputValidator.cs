//////////////////////////////////////////////
//Assignment/Lab/Project: Virtual Pet
//Name: Zebulun Baukhagen
//Section: 2023SP.SGD.213.2172
//Instructor: Brian Sowers
//Date: 2/18/2023
/////////////////////////////////////////////

using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputValidator : MonoBehaviour
{
    [SerializeField] Button startButton;
    [SerializeField] TMP_InputField inputField;
    [SerializeField] GameObject inputPromptPanel;

    private void Awake()
    {
        inputField.onValueChanged.AddListener(ValidateInput);
    }

    private void ValidateInput(string input)
    {
        // make button interactable if input field contains something that isn't empty
        startButton.interactable = !string.IsNullOrWhiteSpace(input);

        if (inputPromptPanel)
        {
            inputPromptPanel.SetActive(string.IsNullOrWhiteSpace(input));
        }
    }
}
