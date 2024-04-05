using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Carousel : MonoBehaviour
{

    public GameObject scrollbar;
    public float scroll_pos = 0;
    float[]pos;
    float distance;
    // Start is called before the first frame update
    void Start()
    {
        pos = new float [transform.childCount];
       distance = 1f/ (pos.Length - 1);
       for (int i = 0 ; i < pos.Length; i++){
            pos[i] = distance * i;
       }
    }

    // Update is called once per frame
    void Update()
    {
       

       if (Input.GetMouseButton(0)){
        scroll_pos = scrollbar.GetComponent<Scrollbar>().value;
       }
       else {
        for (int i = 0; i< pos.Length; i ++){
            if (scroll_pos < pos[i] + (distance/2) && scroll_pos > pos [i] - (distance/2)){
                scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, pos[i], 0.1f);
            }
        }
       }

       for (int i = 0; i< pos.Length; i ++){
            float targetScale = (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2)) ? 1f : 0.8f;
            transform.GetChild(i).localScale = Vector2.Lerp(transform.GetChild(i).localScale, new Vector2(targetScale, targetScale), 0.1f);
        }
    }
}
