using UnityEngine;
using MasterFunctions;

public class InteractionScript : MonoBehaviour
{

   [SerializeField]
   public GameObject pointLightControllerGameObject = null;

   private bool isColliding = false;

   private PointLightController lightScript = null;

   /// <summary>
   /// Initialization
   /// </summary>
   void Start()
   {
      lightScript = pointLightControllerGameObject.GetComponent<PointLightController>();
   }

   /// <summary>
   /// Update is called once per frame
   /// </summary>
   void Update ()
   {
      if (Input.GetKey(KeyCode.E) && isColliding)
      {
         lightScript.SwitchLight();
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