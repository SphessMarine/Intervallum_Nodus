using UnityEngine;
using MasterFunctions;
using UnityEngine.EventSystems;

public class MenuButtonBehavior : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{

   public MenuButton button = MenuButton.BUTTON_NOOP;

   private bool isClicked = false;

   public void OnPointerDown(PointerEventData data)
   {
      isClicked = true;
   }

   public void OnPointerExit(PointerEventData data)
   {
      isClicked = false;
   }

   public void OnPointerUp(PointerEventData data)
   {
      if (isClicked)
      {
         Master.ButtonAction(button);
      }
   }

}
