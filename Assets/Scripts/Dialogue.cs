using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{

    public GameObject dText;
    public Text dialogueText;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("switch"))
        {
            dText.SetActive(true);
            dialogueText.text = "Press E to Turn Lights On/Off";
        }
        if (other.gameObject.CompareTag("start"))
        {
            dText.SetActive(true);
            dialogueText.text = "Figure out how to turn the lights back on.";
        }
    }

    void OnCollisionExit(Collision other)
    {
        dText.SetActive(false);
    }

}