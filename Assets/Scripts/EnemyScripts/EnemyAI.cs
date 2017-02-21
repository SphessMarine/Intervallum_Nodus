using UnityEngine;
using MasterFunctions;
using System.Collections;

public class EnemyAI : MonoBehaviour
{

   protected bool damagingPlayer = false;
   [SerializeField]
   protected int damage = 1;
   [SerializeField]
   protected float gracePeriod = 1.0f;

   /// <summary>
   /// Initialize
   /// </summary>
   protected virtual void Start()
   {
      gameObject.tag = Master.GetTag(TagKey.TAG_ENEMY);
   }

   /// <summary>
   /// Raises the OnTriggerEnter event.
   /// </summary>
   /// <param name="other"></param>
   protected virtual void OnTriggerEnter(Collider other)
   {
      if (other.CompareTag(Master.GetTag(TagKey.TAG_PLAYER)))
      {
         damagingPlayer = true;
         StartCoroutine(DamageOverTime());
      }
   }
   
   /// <summary>
   /// Raise OnTriggerExit event.
   /// </summary>
   /// <param name="other"></param>
   protected virtual void OnTriggerExit(Collider other)
   {
      if (other.CompareTag(Master.GetTag(TagKey.TAG_PLAYER)))
      {
         damagingPlayer = false;
         StopCoroutine(DamageOverTime());
      }
   }

   /// <summary>
   /// Damages the player over time
   /// </summary>
   /// <returns></returns>
   protected IEnumerator DamageOverTime()
   {
      while (damagingPlayer)
      {
         Master.DamagePlayer(damage);
         yield return new WaitForSeconds(gracePeriod);
      }
      yield return null;
   }

}
