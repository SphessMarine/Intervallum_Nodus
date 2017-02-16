using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField]
    private GameObject pointLight01 = null;

    [SerializeField]
    private GameObject pointLight02 = null;

    [SerializeField]
    private GameObject pointLight03 = null;

    [SerializeField]
    private GameObject pointLight04 = null;

    [SerializeField]
    private GameObject pointLight05 = null;

    [SerializeField]
    private GameObject pointLight06 = null;

    private static List<GameObject> lightList = new List<GameObject>();

    private static bool lightsOff = true;

    // Use this for initialization
    void Start()
    {
        lightList.Add(pointLight01);
        lightList.Add(pointLight02);
        lightList.Add(pointLight03);
        lightList.Add(pointLight04);
        lightList.Add(pointLight05);
        lightList.Add(pointLight06);
        SwitchLight();
    }

    // Update is called once per frame
    void Update()
    {
        // Empty
    }

    /// <summary>
    /// Turns lights on and off
    /// </summary>
    /// <param name="lightSwitch"></param>
    public static void SwitchLight()
    {
        foreach (GameObject obj in lightList)
        {
            obj.SetActive(!lightsOff);
        }
        lightsOff = !lightsOff;
    }
}
