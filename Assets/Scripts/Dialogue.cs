using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{

   public GameObject dText;
   public Text dialogueText;
   
   void OnTriggerEnter(Collider other)
   {
      if (other.gameObject.GetComponent<DialogueTrigger>())
      {
         dText.SetActive(true);
         dialogueText.text = other.gameObject.GetComponent<DialogueTrigger>().TriggerText;
      }
   }
   
   void OnTriggerExit(Collider other)
   {
      dText.SetActive(false);
   }

}