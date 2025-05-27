using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements.Experimental;

public class ManualShipNav : MonoBehaviour
{
    [SerializeField]GameObject LaunchButton;
    int slctDestination;
    public TMP_Dropdown Destinations;
    List<string> starLinkName;    
    Vector3 CurrentVec;
    float lerpX;
    float lerpY;
    float lerpZ;
    bool lerping = false;

    // Start is called before the first frame update
    private void Start() {
        ListGen();        
    }

    void ListGen(){
        starLinkName = new List<string>();
        for (int i = 0; i < GetComponentInParent<Overlap>().SuitableStars.Count; i++) {
            starLinkName.Add(GetComponentInParent<Overlap>().SuitableStars[i].name);
        }
        Destinations.ClearOptions();
        Destinations.AddOptions(starLinkName);
    }

    public void OnDropdownValueChanged(int val) {
        val = slctDestination;
    }

    public void launch() {
        if (lerping == false) {
            transform.parent = GetComponentInParent<Overlap>().SuitableStars[slctDestination].transform;
            CurrentVec = transform.localPosition;
            StartCoroutine(LerpFloat());
            ListGen();
        }
    }

    //lerp coroutine
    IEnumerator LerpFloat() {
        lerping = true;
        float time = 0;
        while (time < 1f) {
            float perc = 0;
            perc = time*time;
            time += Time.deltaTime;            
            lerpX = lerp(CurrentVec.x, 0, perc);
            lerpY = lerp(CurrentVec.y, 0, perc);
            lerpZ = lerp(CurrentVec.z, 1, perc);            
            yield return null;
        }
        lerping = false;
    }

    public static float lerp(float startValue, float endValue, float t) {
        return (startValue + (endValue - startValue) * t);
    }

    private void Update() {
        if (lerping == true) {
            transform.localPosition = new Vector3(lerpX, lerpY, lerpZ);

        }                 
    }
}
