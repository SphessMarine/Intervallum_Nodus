using MasterFunctions;
using UnityEngine;

public class Flashlight : Item
{

   [SerializeField]
   public ItemKey itemKey = ItemKey.ITEM_NONE;

   protected override void Start()
   {
      base.Start();
      key = itemKey;
   }

   protected override void OnTriggerEnter(Collider other)
   {
      base.OnTriggerEnter(other);
   }

   protected override void OnTriggerExit(Collider other)
   {
      base.OnTriggerExit(other);
   }

}
