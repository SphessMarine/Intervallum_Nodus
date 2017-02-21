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
      TAG_SWITCH_DOOR,
      TAG_DOOR,
      TAG_FLOOR,
      TAG_PLAYER
   }

   public enum ItemKey
   {
      ITEM_NONE = 0,
      ITEM_FLASHLIGHT,
      ITEM_GLOWSTICK,
      ITEM_DOOR_KEY,
      ITEM_SWITCHBOX_KEY
   }

   #endregion

   public class Master : MonoBehaviour
   {

      #region MasterVariables

      public bool DebugMode = false;

      public static Master master = null;

      private static string[] tags = new string[]
      {
         "Untagged",
         "enemy",
         "item",
         "switch",
         "switch door",
         "door",
         "floor",
         "Player"
      };

      public static Dictionary<Enum, string> Tags = new Dictionary<Enum, string>();

      #endregion

      #region PlayerVariables

      public static int playerHealth = 100;
      private static GameObject playerGameObject = null;
      private static GameObject flashlightGameObject = null;
      public static bool itemHeld = false;
      public static int doorKeyCount = 0;
      public static int switchboxKeyCount = 0;
      public static ItemKey currentHeldItem = ItemKey.ITEM_NONE;
      public static Dialogue dialogueScript = null;

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

         GrabReferences();
      }

      private void GrabReferences()
      {
         playerGameObject = GameObject.Find("Player");
         flashlightGameObject = GameObject.Find("Flashlight");
         dialogueScript = playerGameObject.GetComponent<Dialogue>();
         if (!(playerGameObject && flashlightGameObject))
         {
            Debug.LogError("Player or Flashlight game object reference missing! Call Scawt to fix.");
         }
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

      /// <summary>
      /// Returns string associated with TagKey enum via Dictionary
      /// </summary>
      /// <param name="key"></param>
      /// <returns></returns>
      public static string GetTag(TagKey key)
      {
         return Tags[key];
      }

      /// <summary>
      /// Runs item collection functions
      /// </summary>
      /// <param name="key"></param>
      public static void PickupItem(ItemKey key)
      {
         // TODO: attach item to player. Account for dropping. Spawn popup with item description.
         switch(key)
         {
            case ItemKey.ITEM_DOOR_KEY:
               doorKeyCount++;
               // Update UI
               break;
            case ItemKey.ITEM_SWITCHBOX_KEY:
               switchboxKeyCount++;
               // Update UI
               break;
            case ItemKey.ITEM_FLASHLIGHT:
            case ItemKey.ITEM_GLOWSTICK:
               AttachItem(key);
               break;
            default:
               break;
         }
      }

      /// <summary>
      /// Attaches flashlight/glowstick gameobject to player
      /// </summary>
      /// <param name="key"></param>
      public static void AttachItem(ItemKey key)
      {
         currentHeldItem = key;
         switch(key)
         {
            case ItemKey.ITEM_FLASHLIGHT:
               flashlightGameObject.transform.SetParent(playerGameObject.transform);
               flashlightGameObject.transform.localPosition = new Vector3(0.4f, 0.0f, 0.0f);
               flashlightGameObject.transform.eulerAngles = playerGameObject.transform.eulerAngles;
               break;
            case ItemKey.ITEM_GLOWSTICK:
               break;
         }
      }

      /// <summary>
      /// Forces the player to drop held item
      /// </summary>
      public static void DropItem()
      {
         switch(currentHeldItem)
         {
            case ItemKey.ITEM_FLASHLIGHT:
               break;
            default:
               break;
         }
      }

      /// <summary>
      /// If appropriate key is found, door is destroyed
      /// </summary>
      /// <param name="door"></param>
      /// <param name="key"></param>
      public static void UnlockDoor(GameObject door, TagKey key)
      {
         bool validDoor = false;
         switch(key)
         {
            case TagKey.TAG_SWITCH_DOOR:
               if (switchboxKeyCount > 0)
               {
                  switchboxKeyCount--;
                  validDoor = true;
               }
               break;
            case TagKey.TAG_DOOR:
               if (doorKeyCount > 0)
               {
                  doorKeyCount--;
                  validDoor = true;
               }
               break;
            default:
               break;
         }
         // TODO: Animate door, somehow
         if (validDoor)
         {
            Destroy(door);
         }
      }

      /// <summary>
      /// Triggers dialogue box
      /// </summary>
      /// <param name="text"></param>
      public static void ShowDialogue(string text)
      {
         dialogueScript.ShowMessage(text);
      }

      #endregion

   }
}
