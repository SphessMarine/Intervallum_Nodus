using UnityEngine;
using MasterFunctions;

[RequireComponent(typeof (Collider))]
public class Door : MonoBehaviour
{
   private enum DoorKey
   {
      TAG_DOOR = 5,
      TAG_SWITCH_DOOR = 4
   }

   [SerializeField]
   private DoorKey key = DoorKey.TAG_DOOR;

   private TagKey tagKey = TagKey.UNTAGGED;

   protected void Start()
   {
      tagKey = (TagKey)key;
      gameObject.tag = Master.GetTag(tagKey);
   }

   protected virtual void OnTriggerEnter(Collider other)
   {
      if (other.gameObject.CompareTag(Master.GetTag(TagKey.TAG_PLAYER)))
      {
         // do thing
         Master.UnlockDoor(gameObject, tagKey);
         // if door can't be unlocked, we continue execution
      }
   }

   protected virtual void OnTriggerExit(Collider other)
   {
      // Empty
   }
}
