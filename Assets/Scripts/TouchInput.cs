using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour
{
    private Touch _touch;private Vector2 touchStartPosition, touchEndPosition;
    private ControlManager control;
    // Start is called before the first frame update
    void Start()
    {
        control = GetComponent<ControlManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0){
            _touch = Input.GetTouch(0);

            if(_touch.phase == TouchPhase.Began){
                touchStartPosition = _touch.position;
            }
            else if (_touch.phase == TouchPhase.Moved || _touch.phase == TouchPhase.Stationary){
                touchEndPosition = _touch.position;

                float x = touchEndPosition.x - touchStartPosition.x;
                float y = touchEndPosition.y - touchStartPosition.y;


                if(Mathf.Abs(x) == 0 && Mathf.Abs(y) == 0){
                    //Tap
                }
                
                else if(Mathf.Abs(x) > Mathf.Abs(y)){
                    //x>0 = right, x<0 = left
                }
                else{
                    //y>0 = up, y<0 = down
                }
                Vector2 direction = new Vector2(x, y);
                control.Move(direction.normalized);
            }
            else if (_touch.phase == TouchPhase.Ended || _touch.phase == TouchPhase.Canceled){
                control.Move(Vector2.zero);
            }
        }
    }
}
