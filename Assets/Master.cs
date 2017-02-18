using System;
using System.Collections.Generic;
using UnityEngine;

namespace MasterFunctions
{

   #region Enums

   public enum TagKey
   {
      UNTAGGED = 0,
      TAG_ENEMY,
      TAG_ITEM,
      TAG_SWITCH,
      TAG_FLOOR,
      TAG_PLAYER
   }

   public enum ItemKey
   {
      ITEM_NONE = 0,
      ITEM_FLASHLIGHT,
      ITEM_GLOWSTICK,
      ITEM_KEY
   }

   #endregion

   public class Master : MonoBehaviour
   {

      #region MasterVariables

      public static Master master = null;

      private static string[] tags = new string[]
      {
         "Untagged",
         "enemy",
         "item",
         "switch",
         "floor",
         "Player"
      };

      public static Dictionary<Enum, string> Tags = new Dictionary<Enum, string>();

      #endregion

      #region PlayerVariables

      public static int playerHealth = 0;

      public static bool itemHeld = false;

      public static ItemKey currentHeldItem = ItemKey.ITEM_NONE;

      #endregion

      #region Init

      /// <summary>
      /// Called before Start, needed for initialization
      /// </summary>
      private void Awake()
      {
         // Enforce singleton
         if (master == null)
         {
            master = this;
         }
         else if (master != this)
         {
            Destroy(gameObject);
         }
   
         DontDestroyOnLoad(gameObject);
   
         BuildDictionary();
      }
   
      private void BuildDictionary()
      {
         for (int i = 0; i < tags.Length; i++)
         {
            Tags.Add((TagKey)i, tags[i]);
         }
      }

      #endregion

      #region HelperFunctions

      public static string GetTag(TagKey key)
      {
         return Tags[key];
      }

      public static void PickupItem(ItemKey key)
      {
         if (!itemHeld)
         {
            currentHeldItem = key;
         }
         // TODO: attach item to player. Account for dropping. Spawn popup with item description.
      }

      #endregion

   }
}
