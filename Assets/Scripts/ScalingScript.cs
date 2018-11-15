using UnityEngine;
using System.Collections;

public class ScalingScript : MonoBehaviour
{
    public bool isScaling = true;
    private bool scalingUp = true;
    
    private Vector3 startScale;
    private Vector3 endScale;
    
    public float scaleSpeed;
    public float scaleRate;
    float scaleTimer;

    private void Start()
    {
        startScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
        endScale = new Vector3(transform.localScale.x + 0.1f, transform.localScale.y + 0.1f, transform.localScale.z + 0.1f);
    }

    // Update is called once per frame
    void Update ()
    {     
        scaleTimer += Time.deltaTime;

        if (isScaling)
        {
            if (scalingUp)
            {
                transform.localScale = Vector3.Lerp(transform.localScale, endScale, scaleSpeed * Time.deltaTime);
            }
            else if (!scalingUp)
            {
                transform.localScale = Vector3.Lerp(transform.localScale, startScale, scaleSpeed * Time.deltaTime);
            }

            if(scaleTimer >= scaleRate)
            {
                if (scalingUp)
                {
                    scalingUp = false;
                }
                else if (!scalingUp)
                {
                    scalingUp = true;
                }
                scaleTimer = 0;
            }
        }
        
	}
}