using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class line_logic : MonoBehaviour
{
        private List<LineRenderer> lineList;
        private LineRenderer line;
        private bool isDrawing;
        private Vector3 prevPosition;
        private float time;
        private bool startTimer;
        [SerializeField] private LineRenderer template;
        [SerializeField] private float minDistance=0.1F;
    // Start is called before the first frame update
    void Start()
    {
        lineList = new List<LineRenderer>();
        prevPosition = transform.position;
        isDrawing = false;
        time = 0;
    }

    void StartLine()
    {
        Vector3 currentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        currentPosition.z = 0f;
        line = Instantiate(template, this.transform);
        lineList.Add(line);
        line.positionCount = 1;
        line.SetPosition(0, currentPosition);
        prevPosition = currentPosition;
        isDrawing = true;
        startTimer = false;
        time = 0;

    }
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isDrawing)
        {
            StartLine();

        }

        if(Input.GetMouseButton(0)){
            if (isDrawing)
            {
                Vector3 currentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                currentPosition.z = 0f;
                if (Vector3.Distance(currentPosition, prevPosition) > minDistance)
                {
                    line.positionCount++;
                    line.SetPosition(line.positionCount - 1, currentPosition);
                    prevPosition = currentPosition;
                }
            }

        }

        if (Input.GetMouseButtonUp(0))
        {
            line = null;
            isDrawing = false;
            startTimer = true;
            time = 0;
        }

        if (startTimer)
        {
            time+=Time.deltaTime;
            if (time > 5.0)
            {
                //do save
                
                foreach (LineRenderer l in lineList)
                {
                    Destroy(l.gameObject);
                    startTimer = false;
                }
                
                lineList = new List<LineRenderer>();
            }
        }
        
    }
}
