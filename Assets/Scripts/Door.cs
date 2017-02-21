using UnityEngine;
using MasterFunctions;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(DialogueTrigger))]
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

   [SerializeField]
   private string lockedText = "You need a key to unlock this door.";

   protected void Start()
   {
      tagKey = (TagKey)key;
      gameObject.tag = Master.GetTag(tagKey);
   }

   protected virtual void OnTriggerEnter(Collider other)
   {
      if (other.gameObject.CompareTag(Master.GetTag(TagKey.TAG_PLAYER)))
      {
         switch (tagKey)
         {
            case TagKey.TAG_DOOR:
               if (Master.doorKeyCount == 0)
               {
                  GetComponent<DialogueTrigger>().TriggerText = lockedText;
               }
               else
               {
                  GetComponent<DialogueTrigger>().TriggerText = string.Empty;
               }
               break;
            case TagKey.TAG_SWITCH_DOOR:
               if (Master.switchboxKeyCount == 0)
               {
                  GetComponent<DialogueTrigger>().TriggerText = lockedText;
               }
               else
               {
                  GetComponent<DialogueTrigger>().TriggerText = string.Empty;
               }
               break;
            default:
               break;
         }
      }
   }

   protected virtual void OnCollisionEnter(Collision other)
   {
      if (other.gameObject.CompareTag(Master.GetTag(TagKey.TAG_PLAYER)))
      {
         Master.UnlockDoor(gameObject, tagKey);
      }
   }

   protected virtual void OnTriggerExit(Collider other)
   {
      // Empty
   }
}
