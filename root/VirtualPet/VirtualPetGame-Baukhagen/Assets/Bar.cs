//////////////////////////////////////////////
//Assignment/Lab/Project: Virtual Pet
//Name: Zebulun Baukhagen
//Section: 2023SP.SGD.213.2172
//Instructor: Brian Sowers
//Date: 2/18/2023
/////////////////////////////////////////////

using UnityEngine;

public class Bar : MonoBehaviour
{
    private Transform bar;

    // Start is called before the first frame update
    void Awake()
    {
        // get the transform of the child
        bar = transform.Find("Bar");
    }

    public void SetSize(float sizeNormalized)
    {
        // set the size of the child
        bar.localScale = new Vector3(sizeNormalized, 1f);
    }
}
