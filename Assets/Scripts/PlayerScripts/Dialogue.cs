using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{

   #region LocalVariables

   public GameObject dText = null;
   public Text dialogueText = null;
   private bool runCoroutine = false;
   private bool spawnTextRunning = false;
   private string externalText = "";
   private bool spawn = false;
   const float maxAlpha = 1.0f;
   const float minAlpha = 0.0f;
   float curAlpha = 0.0f;
   const float deltaAlpha = 0.01f;
   private Color c = new Color(0.0f, 0.0f, 0.0f, 0.0f);
   private Color cText = new Color(1.0f, 1.0f, 1.0f, 0.0f);

   #endregion

   #region TriggerEvents

   /// <summary>
   /// Raise OnTriggerEnter event.
   /// Spawn dialogue window with recieved text
   /// </summary>
   /// <param name="other"></param>
   void OnTriggerEnter(Collider other)
   {
      if (other.gameObject.GetComponent<DialogueTrigger>())
      {
         if (spawnTextRunning)
         {
            StopCoroutine(SpawnExternalText());
         }
         dText.SetActive(true);
         dialogueText.text = other.gameObject.GetComponent<DialogueTrigger>().TriggerText;
         StopCoroutine(SpawnText());
         spawn = true;
         StartCoroutine(SpawnText());
      }
   }
   
   /// <summary>
   /// Raise OnTriggerExit event.
   /// Despawn dialogue window and reset text
   /// </summary>
   /// <param name="other"></param>
   void OnTriggerExit(Collider other)
   {
      if (other.gameObject.GetComponent<DialogueTrigger>())
      {
         StopCoroutine(SpawnText());
         spawn = false;
         StartCoroutine(SpawnText());
      }
   }

   #endregion

   public void ShowMessage(string text)
   {
      externalText = text;
      StartCoroutine(SpawnExternalText());
   }

   /// <summary>
   /// Spawns text from an external source
   /// </summary>
   /// <param name="value"></param>
   /// <param name="text"></param>
   /// <returns></returns>
   private IEnumerator SpawnExternalText()
   {
      spawnTextRunning = true;
      dText.SetActive(true);
      dialogueText.text = externalText;
      StopCoroutine(SpawnText());
      spawn = true;
      StartCoroutine(SpawnText());
      yield return new WaitForSeconds(5.0f);
      StopCoroutine(SpawnText());
      spawn = false;
      StartCoroutine(SpawnText());
      spawnTextRunning = false;
      yield return null;
   }

   /// <summary>
   /// Spawns the text in a spooky fashion.
   /// </summary>
   /// <returns></returns>
   private IEnumerator SpawnText()
   {
      // Set our conditional
      runCoroutine = true;
      // Reset color to set with the minAlpha
      c.a = curAlpha;
      cText.a = curAlpha;
      // Set dText object's color to our new color
      dText.GetComponent<Image>().color = c;
      dialogueText.color = cText;
      while (runCoroutine)
      {
         if (spawn)
         {
            // While the current alpha is less than the max, iterate by delta
            if (curAlpha < maxAlpha)
            {
               curAlpha = c.a + deltaAlpha;
            }
            // Otherwise, we are == or > max and should cease execution
            else
            {
               curAlpha = maxAlpha;
               runCoroutine = false;
            }
         }
         else
         {
            // While the current alpha is > the min, iterate by delta
            if (curAlpha > minAlpha)
            {
               curAlpha = c.a - deltaAlpha;
            }
            // Otherwise, we are == or < min and should cease execution
            else
            {
               curAlpha = minAlpha;
               runCoroutine = false;
            }
         }
         c.a = curAlpha;
         cText.a = curAlpha;
         // Set dText color to new color
         dText.GetComponent<Image>().color = c;
         dialogueText.color = cText;
         yield return new WaitForEndOfFrame();
      }
      curAlpha = spawn ? 1.0f : 0.0f;
      dText.SetActive(spawn);
      yield return null;
   }

}