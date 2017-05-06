/*
*	Copyright (c) Alex
*/

using UnityEngine;
using System.Collections;

[RequireComponent (typeof(SpriteRenderer))]

public class Tiling : MonoBehaviour {

    #region Variables
    public int offsetX = 2;

    public bool hasARightBuddy = false;

    public bool reverseScale = false;

    private float spriteWidth = 0f;
    private Camera cam;
    private Transform myTransform;

    #endregion

    #region Unity Methods

    private void Awake()
    {
        cam = Camera.main;
        myTransform = transform;
    }
    void Start () 
	{
        SpriteRenderer sRenderer = GetComponent<SpriteRenderer>();
        spriteWidth = sRenderer.sprite.bounds.size.x;

	}
	
	void Update () 
	{
		if(hasARightBuddy == false)
        {
            float camHorizontalExend = cam.orthographicSize * Screen.width / Screen.height;

            float edgeVisiblePostionRight = (myTransform.position.x + spriteWidth / 2) - camHorizontalExend;
            if (cam.transform.position.x >= edgeVisiblePostionRight - offsetX && hasARightBuddy == false)
            {
                MakeNewBuddy(1);
                hasARightBuddy = true;
            }
        }
	}
	
    void MakeNewBuddy (int rightOrLeft)
    {
        Vector3 newPosition = new Vector3(myTransform.position.x + spriteWidth * rightOrLeft, myTransform.position.y, myTransform.position.z);
        Transform newBuddy = Instantiate (myTransform, newPosition, myTransform.rotation) as Transform;
        if (reverseScale == true)
        {
            newBuddy.localScale = new Vector3(newBuddy.localScale.x * -1, newBuddy.localScale.y, newBuddy.position.z);
        }

        newBuddy.parent = myTransform.parent;
        if(rightOrLeft < 0)
        {
            newBuddy.GetComponent<Tiling>().hasARightBuddy = true;
        }
    }
	#endregion
}
