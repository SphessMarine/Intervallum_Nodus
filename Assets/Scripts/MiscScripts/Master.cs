using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
      private static Dialogue dialogueScript = null;

      #endregion

      #region UIVariables

      private static GameObject healthUI = null;
      private static GameObject switchboxKeysUI = null;
      private static GameObject doorKeysUI = null;
      private static bool isDirty = false;
      private static Text healthUIText = null;
      private static Text switchboxKeysUIText = null;
      private static Text doorKeysUIText = null;
      private static string playerMaxHealthString = "";

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
         isDirty = true;
      }

      private void GrabReferences()
      {
         playerGameObject = GameObject.Find("Player");
         flashlightGameObject = GameObject.Find("Flashlight");
         dialogueScript = playerGameObject.GetComponent<Dialogue>();
         healthUI = GameObject.Find("UIHealth");
         switchboxKeysUI = GameObject.Find("UISwitchBoxKeys");
         doorKeysUI = GameObject.Find("UIKeys");
         healthUIText = healthUI.GetComponent<Text>();
         switchboxKeysUIText = switchboxKeysUI.GetComponent<Text>();
         doorKeysUIText = doorKeysUI.GetComponent<Text>();
         playerMaxHealthString = playerHealth.ToString();
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

      #region ItemFunctions

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
         isDirty = true;
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
         isDirty = true;
      }

      #endregion

      /// <summary>
      /// Triggers dialogue box
      /// </summary>
      /// <param name="text"></param>
      public static void ShowDialogue(string text)
      {
         dialogueScript.ShowMessage(text);
      }

      #region DamageFunctions

      /// <summary>
      /// Damages player
      /// </summary>
      /// <param name="damage"></param>
      public static void DamagePlayer(int damage)
      {
         playerHealth -= damage;
         Debug.Log("Player has " + playerHealth + " HP.");
         if (playerHealth <= 0)
         {
            GameOver();
         }
         isDirty = true;
      }

      /// <summary>
      /// Triggers GameOver screen
      /// </summary>
      public static void GameOver()
      {
         Debug.Log("Game Over!");
      }

      #endregion

      #endregion

      private void Update()
      {
         if (isDirty)
         {
            // Update UI
            healthUIText.text = playerHealth + "/" + playerMaxHealthString;
            switchboxKeysUIText.text = switchboxKeyCount.ToString();
            doorKeysUIText.text = doorKeyCount.ToString();
            isDirty = false;
         }
      }

   }
}
