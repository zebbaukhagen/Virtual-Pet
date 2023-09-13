//////////////////////////////////////////////
//Assignment/Lab/Project: Virtual Pet
//Name: Zebulun Baukhagen
//Section: 2023SP.SGD.213.2172
//Instructor: Brian Sowers
//Date: 2/18/2023
/////////////////////////////////////////////

using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Serialized Fields
    [SerializeField] private Bar energyBar;
    [SerializeField] private Bar enrichmentBar;
    [SerializeField] private Bar fullnessBar;

    [SerializeField] List<GameObject> panelsList = new();

    [SerializeField] TMP_InputField inputField;

    [SerializeField] TextMeshProUGUI nameLabel;
    #endregion

    VirtualPet pet;

    private float needsDecayRate = 0.001f;

    // Update is called once per frame
    void Update()
    {
        // if pet exists and is alive, decay it's needs and update UI
        // if pet is asleep, continue resting until fully rested
        if (pet != null)
        {
            if (IsPetAlive(pet))
            {
                DecayPetsNeeds(pet, needsDecayRate);
                UpdateUIBars();
                if (pet.WakeState == ConsciousState.Asleep)
                {
                    pet.Rest(needsDecayRate * 2);
                }
            }
            else
            {
                // if it isn't alive, delete the instance and activate lose panel
                pet = null;
                panelsList[3].SetActive(true);
            }
        }
    }

    #region Game Methods

    private void UpdateUIBars()
    {
        // update all needs bars
        energyBar.SetSize(pet.Energy);
        enrichmentBar.SetSize(pet.Enrichment);
        fullnessBar.SetSize(pet.Fullness);
    }

    private void DecayPetsNeeds(VirtualPet pet, float decayRate)
    {
        // if pet is awake, decay normally
        // if pet is asleep, decay at reduced rate
        if (pet.WakeState == ConsciousState.Awake)
        {
            pet.Energy -= decayRate;
            pet.Enrichment -= decayRate;
            pet.Fullness -= decayRate;
        }
        else
        {
            pet.Enrichment -= decayRate / 2;
            pet.Fullness -= decayRate / 2;
        }
    }

    private bool IsPetAlive(VirtualPet pet)
    {
        // check if pet is still living
        if (pet.Energy <= 0 || pet.Enrichment <= 0 || pet.Fullness <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    #endregion

    #region Play Buttons

    public void OnClickFeedButton()
    {
        pet.Eat(.2f);
    }

    public void OnClickRestButton()
    {
        if (pet.WakeState == ConsciousState.Awake) pet.Rest(.2f);
    }

    public void OnClickPlayButton()
    {
        pet.Play(.1f);
    }

    #endregion


    #region Menu Buttons

    public void OnClickStartButton()
    {
        // instantiate pet, update name label and set panels
        pet = new VirtualPet(inputField.text);
        nameLabel.text = pet.Name;

        panelsList[2].SetActive(true);
        panelsList[0].SetActive(false);
    }

    public void OnClickHelpButton()
    {
        if (panelsList[1].activeInHierarchy == false)
        {
            panelsList[1].SetActive(true);
        }
        else
        {
            panelsList[1].SetActive(false);
        }
    }

    public void OnClickQuitButton()
    {
        Application.Quit();
    }

    public void OnClickNewPetButton()
    {
        SceneManager.LoadScene("MainScene");
    }

    #endregion
}
