using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HeartBeat : MonoBehaviour
{
    // Grow parameters
    public float approachSpeed = 0.02f;
    public float growthBound = 2f;
    public float shrinkBound = 0.5f;
    private float currentRatio = 1;

    // The text object we're trying to manipulate
    private Image img;
    private float originalFontSize;

    // And something to do the manipulating
    private Coroutine routine;
    private bool keepGoing = true;
    private bool closeEnough = false;

    // Attach the coroutine
    void Awake()
    {
        // Find the text  element we want to use
        this.img = this.gameObject.GetComponent<Image>();

        // Then start the routine
        this.routine = StartCoroutine(this.Pulse());
    }

    IEnumerator Pulse()
    {
        // Run this indefinitely
        while (keepGoing)
        {
            // Get bigger for a few seconds
            while (this.currentRatio != this.growthBound)
            {
                // Determine the new ratio to use
                currentRatio = Mathf.MoveTowards(currentRatio, growthBound, approachSpeed);

                // Update our text element
                this.transform.localScale = Vector3.one * currentRatio;

                yield return new WaitForEndOfFrame();
            }

            // Shrink for a few seconds
            while (this.currentRatio != this.shrinkBound)
            {
                // Determine the new ratio to use
                currentRatio = Mathf.MoveTowards(currentRatio, shrinkBound, approachSpeed);

                // Update our text element
                this.transform.localScale = Vector3.one * currentRatio;

                yield return new WaitForEndOfFrame();
            }
        }
    }
}
