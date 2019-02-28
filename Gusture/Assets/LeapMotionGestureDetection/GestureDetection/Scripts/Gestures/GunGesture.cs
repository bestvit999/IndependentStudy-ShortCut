using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunGesture : GestureBase
{

    public EHand m_Hand;

    FingerExtendedDetails m_GestureDetail;

    BluetoothLib bt;

    void Start()
    {
        m_GestureDetail.bThumbExtended = true;
        m_GestureDetail.bIndexExtended = true;
        m_GestureDetail.bMiddleExtended = false;
        m_GestureDetail.bRingExtended = false;
        m_GestureDetail.bPinkeyExtended = false;
        bt = FindObjectOfType<BluetoothLib>();
    }

    void Update()
    {

    }

    public override bool Detected()
    {
        DetectionManager.DetectionHand detectHand = DetectionManager.Get().GetHand(m_Hand);

        if (detectHand.IsSet())
        {

            bt.send("GunGusture is Detected");

            return detectHand.CheckWithDetails(m_GestureDetail);
        }

        return false;
    }
}
