using UnityEngine;

public class ObjectTouchHandler : MonoBehaviour
{
    // You can choose the color in the Unity Inspector
    public Color touchColor = Color.red;
    private Color originalColor;
    private Renderer objRenderer;

    void Start()
    {
        // Get the Renderer component from the object
        objRenderer = GetComponent<Renderer>();
        
        // Save the original color so we can change it back later
        originalColor = objRenderer.material.color;
    }

    // Option A: If "Is Trigger" is turned OFF (Solid Collision)
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the object we touched has a specific tag
        if (collision.gameObject.CompareTag("GrabCube"))
        {
            // Change the object's color to the touch color
            objRenderer.material.color = touchColor;
            Debug.Log("Touched the target object via Collision!");
            TriggerYourEvent();
        }
    }
    
    // Triggered when the other object stops touching this collider
    void OnCollisionExit(Collision collision)
    {
        // Revert back to the original color
        objRenderer.material.color = originalColor;
    }

    // Option B: If "Is Trigger" is turned ON (Overlap/Pass-through)
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GrabCube"))
        {
            objRenderer.material.color = touchColor;
            Debug.Log("Entered the target object's Trigger zone!");
            TriggerYourEvent();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        objRenderer.material.color = originalColor;
    }

    void TriggerYourEvent()
    {
        // Put your game logic here (e.g., take damage, destroy object, play sound)
    }
}

