using UnityEngine;
using MasterFunctions;

[RequireComponent(typeof (Collider))]
public class Item : MonoBehaviour
{
   protected bool playerCollision = false;
   protected ItemKey key = ItemKey.ITEM_NONE;

   protected virtual void Start()
   {
      gameObject.tag = Master.GetTag(TagKey.TAG_ITEM);
   }

   protected virtual void OnTriggerEnter(Collider other)
   {
      if (other.gameObject.CompareTag(Master.GetTag(TagKey.TAG_PLAYER)))
      {
         playerCollision = true;
         // do thing
         Master.PickupItem(key);
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
