using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandCtrl : MonoBehaviour
{
    public InputDeviceCharacteristics characteristics;
    private InputDevice handControllerDevice;
    public List<GameObject> handModelPrefabsList;
    private GameObject myHand;
    private Animator handAnim = null;
    private Transform myTransform;

    void Start()
    {
        myTransform = transform;

        List<InputDevice> devices = new List<InputDevice>();
        //InputDevices.GetDevices(devices);
        InputDevices.GetDevicesWithCharacteristics(characteristics, devices);

        if (devices.Count > 0) handControllerDevice = devices[0];

        if (handModelPrefabsList.Count > 0)
        {
            myHand = Instantiate(handModelPrefabsList[0], myTransform);
            handAnim = myHand.GetComponent<Animator>();
            //  if (handAnim) Debug.Log("Animator found");
        }
    }

    void Update()
    {
        if(handControllerDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerVal))
        {
            handAnim.SetFloat("Trigger", triggerVal);
        }
        else
        {
            handAnim.SetFloat("Trigger", 0);
        }

        if (handControllerDevice.TryGetFeatureValue(CommonUsages.grip, out float gripVal))
        {
            handAnim.SetFloat("Grip", gripVal);
        }
        else
        {
            handAnim.SetFloat("Grip", 0);
        }

    }
}
