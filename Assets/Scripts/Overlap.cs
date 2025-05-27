using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Unity.VisualScripting.Antlr3.Runtime.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.Analytics;

public class Overlap : MonoBehaviour {    
    [SerializeField] GameObject linkGen;
    
    Collider[] tooClose;
    Collider[] InRange;
    
    public List<GameObject> SuitableStars;
    public Dictionary<GameObject, GameObject> links = new Dictionary<GameObject, GameObject>();
    
    float Nearest = 1000;
    float distance = 0;
    GameObject NearestStar;
    public static int reps = 0;

    //draws Gizmos the same size/shape as the OverlapSphere
    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(transform.position, Stars.LinkRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Stars.LinkRange * 0.5f);
    }

    // Start is called before the first frame update
    public void Start() {
        SuitableStars = new List<GameObject>();        
        //creates a list off all objects in the spheres area.
        InRange = Physics.OverlapSphere(transform.position, Stars.LinkRange);
        tooClose = Physics.OverlapSphere(transform.position, Stars.LinkRange * 0.5f);
        //If a star is in both lists then it is too close and wont be added to the linked list
        foreach (Collider Collider in InRange)
        {
            if (Collider.CompareTag("Star") == true && !tooClose.Contains(Collider) && Collider.gameObject != this.gameObject)
            {
                SuitableStars.Add(Collider.gameObject);
            }

        }

        //if the list is empty look for the nearest star and add it to the linkedStars list.
        if (SuitableStars.Count == 0) {            
            for (int i = 0; i < Stars.StarList.Count; i++) { 
                distance = Vector3.Distance(Stars.StarList[i].transform.position, transform.position);                
                if (distance < Nearest && distance > 0 && CompareTag("Star")){                    
                    NearestStar = Stars.StarList[i];                    
                    Nearest = distance;
                }
            }
            SuitableStars.Add(NearestStar);
            //add This Star to Other stars linked Star list
            Debug.Log(NearestStar.gameObject);
            Overlap NearestStartOverlap = NearestStar.GetComponent<Overlap>();
            
            //If star has already generated its links, add to it now
            if (NearestStartOverlap.links.Count > 0 && !NearestStartOverlap.links.ContainsKey(this.gameObject))
            {
                NearestStartOverlap.links.Add(this.gameObject, CreateLink());
            }
            else
            {
                NearestStartOverlap.SuitableStars.Add(transform.gameObject);
            }
        }
        RouteGen();
    }

#if UNITY_EDITOR
    public void printDictionaryDebug()
    {
        for (int i = 0; i < links.Count; i++)
        {
            Debug.Log($"Star = {links.ElementAt(i).Key}");
            Debug.Log($"Link = {links.ElementAt(i).Value}");
        }
    }
#endif

    public GameObject CreateLink()
    {
        GameObject Ilink = Instantiate(linkGen);
        Ilink.transform.parent = gameObject.transform;
        Ilink.transform.localPosition = new Vector3(0, 0, 0);
        Ilink.GetComponent<PlaneVec>().start();
        return Ilink;
    }

    void RouteGen() {
        //for each linked star, make a route
        
        for (int i = 0; i < SuitableStars.Count; i++) {
            Overlap otherOverlap = SuitableStars[i].GetComponent<Overlap>();
            if (otherOverlap.links.ContainsKey(this.gameObject))
            {
                GameObject link;
                otherOverlap.links.TryGetValue(this.gameObject, out link);
                links.Add(SuitableStars[i], link);
                continue;
            }
            reps = i;
            
            links.Add(SuitableStars[i], CreateLink());
            
        }       
    }
}
