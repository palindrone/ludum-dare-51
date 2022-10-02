using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPlatform : MonoBehaviour
{
    public int itemWidth = 30;
    public int itemHeight = 30;
    
    public int maxWidth;
    public int maxHeight;

    private int currentWidth = 0;
    private int currentHeight = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3? NextPosition()
    {
        // Check out of bounds
        if (currentHeight >= maxHeight)
            return null;
        
        // Get current position if not out of bounds
        var returnVector = new Vector3(currentWidth * itemWidth, currentHeight * itemHeight, 0);
        
        // Increment for next time
        currentWidth++;
        if (currentWidth >= maxWidth)
        {
            currentHeight++;
            currentWidth = 0;
        }

        return returnVector;
    }
}
