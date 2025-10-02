using UnityEngine;

public class PanelDeactivation : MonoBehaviour
{
    public GameObject panelToDeactivate;

    private void Start()
    {
        // Ensure that the panelToDeactivate variable is assigned in the Inspector
        if (panelToDeactivate == null)
        {
            Debug.LogError("Panel to deactivate is not assigned!");
        }
    }

    public void DeactivatePanelWithDelay()
    {
        // Invoke the DeactivatePanel method with a delay of 0.5 seconds
        Invoke("DeactivatePanel", 0.5f);
    }

    private void DeactivatePanel()
    {
        // Deactivate the panel
        panelToDeactivate.SetActive(false);
    }
}
