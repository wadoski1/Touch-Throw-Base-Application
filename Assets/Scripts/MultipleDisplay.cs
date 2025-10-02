/* Unmerged change from project 'Assembly-CSharp.Player'
Before:
using System.Collections;
After:
*/
using UnityEngine;

public class MultipleDisplay : MonoBehaviour
{
    public GameObject[] availableCameras;
    void Start()
    {
        //Debug.Log("displays connected: " + Display.displays.Length);
        // Display.displays[0] is the primary, default display and is always ON, so start at index 1.
        // Check if additional displays are available and activate each.

        for (int i = 1; i < Display.displays.Length; i++)
        {
            Display.displays[i].Activate();
            availableCameras[i].SetActive(true);
        }
    }

    void Update()
    {

    }
}

