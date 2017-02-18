using UnityEngine;
using MasterFunctions;

public class InteractionScript : MonoBehaviour
{
    private bool isColliding = false;
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.E) && isColliding)
        {
            PointLightController.SwitchLight();
        }
    }

    /// <summary>
    /// Raises the OnCollisionExit Event
    /// </summary>
    /// <param name="other"></param>
    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag(Master.GetTag(TagKey.TAG_SWITCH)))
        {
            isColliding = false;
        }
    }

    /// <summary>
    /// Raises the OnCollisionEnter Event
    /// </summary>
    /// <param name="other"></param>
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(Master.GetTag(TagKey.TAG_SWITCH)))
        {
            isColliding = true;
        }
    }
}