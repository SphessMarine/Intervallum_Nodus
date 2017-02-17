using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
   [SerializeField]
   private string triggerText = "";

   public string TriggerText
   {
      get { return triggerText; }
      set { triggerText = value; }
   }
}
