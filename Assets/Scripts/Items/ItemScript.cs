using MasterFunctions;
using UnityEngine;

public class ItemScript : Item
{

   [SerializeField]
   public ItemKey itemKey = ItemKey.ITEM_NONE;

   private bool isKey = false;
   private bool spawnDialogue = false;
   [SerializeField]
   private string dialogueToShow = "";

   protected override void Start()
   {
      base.Start();
      key = itemKey;
      if (key == ItemKey.ITEM_SWITCHBOX_KEY || key == ItemKey.ITEM_DOOR_KEY)
      {
         isKey = true;
      }
      if (!dialogueToShow.Equals(string.Empty))
      {
         spawnDialogue = true;
      }
   }

   protected override void OnTriggerEnter(Collider other)
   {
      base.OnTriggerEnter(other);
      if (spawnDialogue)
      {
         Master.ShowDialogue(dialogueToShow);
      }
      if (isKey)
      {
         Destroy(gameObject);
      }
   }

   protected override void OnTriggerExit(Collider other)
   {
      base.OnTriggerExit(other);
   }

}
