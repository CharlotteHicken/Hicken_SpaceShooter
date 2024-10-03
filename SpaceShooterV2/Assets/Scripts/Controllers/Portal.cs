using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Portal : MonoBehaviour
{
    public float portalRaidus;
    public int portalPoints;
    public string lineColor;
    public GameObject otherPortal;
    public GameObject player;
    public GameObject currentPortal;
    Color currentColor;
    bool canEnterPortal;

    private void Start()
    {
        if (lineColor == "blue")
        {
            currentColor = Color.blue;
        }
        else
        {
            currentColor = new Color(1, 0.5f, 0);
        }
    }
    void Update()
    {
        DrawPortal(portalRaidus, portalPoints);
        if ((otherPortal.transform.position - player.transform.position).magnitude > portalRaidus)
        {
            canEnterPortal = true;
        }
        if ((otherPortal.transform.position - player.transform.position).magnitude <= portalRaidus && canEnterPortal)
        {
            Teleport();
            canEnterPortal = false;
        }
    }

    public void DrawPortal(float radius, int circlePoints)
    {
        float degrees = 360 / circlePoints;
        float radians = degrees * Mathf.Deg2Rad;

        for (int i = 0; i <= circlePoints; i++)
        {
            Vector3 currentPoint = new Vector3(Mathf.Cos(radians + (radians * i)), Mathf.Sin(radians + (radians * i))) * radius;
            Vector3 nextPoint = new Vector3(Mathf.Cos(radians + (radians * (i + 1))), Mathf.Sin(radians + (radians * (i + 1)))) * radius;
            Debug.DrawLine(currentPortal.transform.position + currentPoint, currentPortal.transform.position + nextPoint, currentColor);
        }
    }
    
    public void Teleport()
    {
        player.transform.position = otherPortal.transform.position;
    }
}
