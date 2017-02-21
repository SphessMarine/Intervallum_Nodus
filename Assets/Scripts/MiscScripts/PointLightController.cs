using System.Collections.Generic;
using UnityEngine;

public class PointLightController : MonoBehaviour
{
   [SerializeField]
   private List<GameObject> lightList = new List<GameObject>();

   private static bool lightsOff = true;

   // Use this for initialization
   void Start ()
   {
       SwitchLight();
   }

	// Update is called once per frame
	void Update ()
   {
      // Empty
	}

   /// <summary>
   /// Turns lights on and off
   /// </summary>
   /// <param name="lightSwitch"></param>
   public void SwitchLight()
   {
      foreach (GameObject obj in lightList)
      {
           if (obj)
           {
              obj.SetActive(!lightsOff);
           }
      }
      lightsOff = !lightsOff;
   }
}
