using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public List<Transform> starTransforms;
    public int interpolationFrameCount;
    int elapsedFrames = 0;
    float drawingTime;
    int currentStarList = 0;

    // Update is called once per frame
    void Update()
    {
        drawingTime = (float)elapsedFrames / interpolationFrameCount;

            Vector3 currentStar = starTransforms[currentStarList].position;
            Vector3 nextStar = starTransforms[currentStarList + 1].position;
            Vector3 interpolatedPosition = Vector3.Lerp(currentStar, nextStar, drawingTime);
            Debug.DrawLine(currentStar, interpolatedPosition, Color.white);

        elapsedFrames++;
         
        if (elapsedFrames > interpolationFrameCount)
        {
            currentStarList++;
            elapsedFrames = 0;

            if (currentStarList >= starTransforms.Count - 1)
            {
                currentStarList = 0;
            }
        
        }
    }
}
