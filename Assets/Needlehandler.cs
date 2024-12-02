using UnityEngine;
using UnityEngine.UI;

public class Needlehandler : MonoBehaviour
{
    // Reference to the Text component
    public Text uiText;
    // This method will be called when another collider enters the trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check the tag of the other game object
        if (other.CompareTag("2X"))
        {
            if(NewCameraDeemBridge.Instance != null)
            {
                NewCameraDeemBridge.Instance.panelController.Multiplier(2);
            }
            if (ui.instance != null)
            {
                ui.instance.Multiplier(2);
            }
            
            //uiText.text = "2X";
            //ui.instance.Rewardx = 2;
        }
        else if (other.CompareTag("3X"))
        {
            if (NewCameraDeemBridge.Instance != null)
            {
                NewCameraDeemBridge.Instance.panelController.Multiplier(3);
            }
            if (ui.instance != null)
            {
                ui.instance.Multiplier(3);
            }
           
            //uiText.text = "3X";
            //ui.instance.Rewardx = 3;
        }
        else if (other.CompareTag("4X"))
        {
            if (NewCameraDeemBridge.Instance != null)
            {
                NewCameraDeemBridge.Instance.panelController.Multiplier(4);
            }
            if (ui.instance != null)
            {
               
                ui.instance.Multiplier(4);
            }
           
            //uiText.text = "4X";
            //ui.instance.Rewardx = 4;
        }
    }
}