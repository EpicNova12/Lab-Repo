using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbulanceEvent : MonoBehaviour
{
    GameObject m_ambulance;
    public void Move()
    {
        m_ambulance.transform.position = new Vector3(4.8f, 6.5f, -4.0f);
    }
}

