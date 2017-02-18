using UnityEngine;
using MasterFunctions;

[RequireComponent(typeof (Collider))]
public class Item : MonoBehaviour
{
   protected bool equipped = false;
   protected bool playerCollision = false;
   protected bool pickup = true;

   protected virtual void Start()
   {
      gameObject.tag = Master.GetTag(TagKey.TAG_ITEM);
   }

   protected virtual void OnTriggerEnter(Collider other)
   {
      if (pickup && other.gameObject.CompareTag(Master.GetTag(TagKey.TAG_PLAYER)))
      {
         playerCollision = true;
         // do thing
      }
   }

   protected virtual void OnTriggerExit(Collider other)
   {
      if (playerCollision)
      {
         // do thing
      }
   }
}
