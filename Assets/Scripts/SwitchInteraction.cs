using UnityEngine;

public class SwitchInteraction : MonoBehaviour
{
    private bool isColliding = false;

    // Use this for initialization
    void Start ()
    {
		// Empty
	}
	
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
        if (other.gameObject.CompareTag("switch"))
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
        if (other.gameObject.CompareTag("switch"))
        {
            isColliding = true;
        }
    }
}
