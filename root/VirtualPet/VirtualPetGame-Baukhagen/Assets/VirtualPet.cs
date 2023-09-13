//////////////////////////////////////////////
//Assignment/Lab/Project: Virtual Pet
//Name: Zebulun Baukhagen
//Section: 2023SP.SGD.213.2172
//Instructor: Brian Sowers
//Date: 2/18/2023
/////////////////////////////////////////////

using UnityEngine;

public class VirtualPet
{
    private string name;
    private float fullness;
    private float enrichment;
    private float energy;
    private ConsciousState wakeState;

    public VirtualPet(string chosenName)
    {
        // constructor
        name = chosenName;
        fullness = 1f;
        enrichment = 1f;
        energy = 1f;
        wakeState = ConsciousState.Awake;
    }

    #region Properties

    public ConsciousState WakeState
    {
        get
        {
            return wakeState;
        }
    }

    public string Name
    {
        get
        {
            return name;
        }
    }

    public float Fullness
    {
        get
        {
            return fullness;
        }

        set
        {
            fullness = value;
        }
    }

    public float Enrichment
    {
        get
        {
            return enrichment;
        }

        set
        {
            enrichment = value;
        }
    }

    public float Energy
    {
        get
        {
            return energy;
        }

        set
        {
            energy = value;
        }
    }

    #endregion

    #region Methods

    public void Eat(float amountOfFood)
    {
        // tries to add amountOfFood to pet.fullness
        // if amountOfFood + pet.fullness > 1, set fullness to 1
        if (wakeState == ConsciousState.Awake)
        {
            Debug.Log("Rest check successful, trying to eat.");
            float potentialFullness = fullness + amountOfFood;
            if (potentialFullness <= 1f)
            {
                Debug.Log("Eat check successful, eating.");
                fullness = potentialFullness;
            }
            else
            {
                Debug.Log("Eat check successful, setting max fullness.");
                fullness = 1f;
            }
        }
        else
        {
            Debug.Log("Eat check failed, pet is asleep.");
        }
    }

    public void Rest(float restIncrement)
    {
        // if pet is awake and unrested, go to sleep
        // else if pet is asleep, add restIncrement to energy
        // else if pet is asleep and energy is full, wake up
        // else default pet to awake
        if (wakeState == ConsciousState.Awake && energy < 1f)
        {
            Debug.Log("Rest check successful, going to sleep.");
            wakeState = ConsciousState.Asleep;
        }
        else if (wakeState == ConsciousState.Asleep && energy < 1f)
        {
            Debug.Log("Rest check successful, sleeping and incrementing.");
            energy += restIncrement;
        }
        else if (wakeState == ConsciousState.Asleep && energy >= 1f)
        {
            Debug.Log("Rest check successful, rested and waking up.");
            energy = 1f;
            wakeState = ConsciousState.Awake;
        }
        else
        {
            Debug.Log("Rest check failed, defaulting to awake.");
            wakeState = ConsciousState.Awake;
        }
    }

    public void Play(float amountOfEnrichment)
    {
        // tries to add potentialEnrichment to pet.enrichment
        // if potentialEnrichment + pet.enrichment > 1, set enrichment to 1
        if (wakeState == ConsciousState.Awake)
        {
            Debug.Log("Rest check successful, trying to play.");
            float potentialEnrichment = enrichment + amountOfEnrichment;
            if (potentialEnrichment <= 1f)
            {
                Debug.Log("Play check successful, playing.");
                enrichment = potentialEnrichment;
            }
            else
            {
                Debug.Log("Play check successful, setting max enrichment.");
                enrichment = 1f;
            }
        }
        else
        {
            Debug.Log("Play check failed, pet is asleep.");
        }

    }

    #endregion
}

public enum ConsciousState
{
    Awake,
    Asleep,
}
