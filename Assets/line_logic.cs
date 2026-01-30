using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class line_logic : MonoBehaviour
{
        private LineRenderer line;
        private Vector3 prevPosition;
        [SerializeField]
        private float minDistance=0.1F;
    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
        prevPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0)){
            Vector3 currentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentPosition.z = 0f;
            if(Vector3.Distance(currentPosition,prevPosition )>minDistance)
            {
                line.positionCount++;
                line.SetPosition(line.positionCount-1,currentPosition);
                prevPosition = currentPosition;
            }

        }

    
    }
}
