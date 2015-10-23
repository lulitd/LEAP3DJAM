using UnityEngine;
using System.Collections;

public class PlayerMiniMap : MonoBehaviour {

    Transform center;
    public float radius = 5f;
	public GameObject MiniMap;
	public GameObject MiniMapCenter;
    public GameObject environment1;
	public GameObject environment2;
	public GameObject environment3;
	public GameObject environment4;
    private GameObject[] tempList;
	public bool haveMiniMap;
	public float RotateMiniMap;
	public bool rotating;
	private float scale;

	// Use this for initialization
	void Start () {
        
        tempList = new GameObject[500];
       // InvokeRepeating("UpdateMiniMap", 0, 0.1F); // update miniMap 0.5s
	
    }

	void FixedUpdate(){
		ScaleMap();
		if (haveMiniMap) {//control miniMap

			MiniMap.transform.localPosition = new Vector3 (-0.41f, 0.04f, 2.29f); // move object up
			if(rotating){
				MiniMap.transform.Rotate(Vector3.right * RotateMiniMap);
				rotating =false;
			}
		} else {
			MiniMap.transform.localPosition = new Vector3 (-0.41f, -5f, 2.29f); // move object up
		}
	}
    // Update is called once per frame
    void LateUpdate() {
		if(haveMiniMap){
		CreateMiniMap ();
		StartCoroutine (MiniMapDe());
		}
    }

	//similar to the StaerCoroutine Use One
	//void OnGUI(){
	//	DestroyMiniMap ();
	//}

	IEnumerator MiniMapDe()
	{

		yield return new WaitForEndOfFrame();;
		DestroyMiniMap ();
	}
	//void OnEnable(){
	//	DestroyMiniMap ();
	//	Debug.Log ("here");
	//}

    public void CreateMiniMap()
    {
		//need to make sure player scale should always be 1 ,1 ,1 and if go wrong. will casue problem
		center = gameObject.transform; // player position  
		int j=0;//j should be in function scope to have no errors
        Collider[] inArea = Physics.OverlapSphere(center.position,radius);
        for(int i = 0; i < inArea.Length; i++)
        {
            if (inArea[i].tag == "Tree")
            {
				Vector3 tempPos = center.InverseTransformPoint(inArea[i].gameObject.transform.position);//relative to the center of player
				tempPos.x = tempPos.x*scale;//
				tempPos.z = tempPos.z*scale;// the scale to minimize the pos on MINIMap
				tempPos.y = tempPos.y*scale;
				Vector3 posRelatePlane = MiniMapCenter.transform.TransformPoint(tempPos);//position relate to centerpoint of map
				GameObject temp;
				temp = (GameObject)Instantiate(environment1, posRelatePlane, Quaternion.identity);
				//temp.transform.parent = MiniMap.transform;
				temp.transform.localScale = new Vector3(0.1f,0.1f,0.1f);
				tempList[j] = temp;
				j++;
            }

			if (inArea[i].tag == "Chest")
			{
				Vector3 tempPos = center.InverseTransformPoint(inArea[i].gameObject.transform.position);//relative to the center of player
				tempPos.x = tempPos.x*scale;//
				tempPos.z = tempPos.z*scale;// the scale to minimize the pos on MINIMap
				tempPos.y = tempPos.y*scale;
				Vector3 posRelatePlane = MiniMapCenter.transform.TransformPoint(tempPos);//position relate to centerpoint of map
				GameObject temp;
				temp = (GameObject)Instantiate(environment3, posRelatePlane, Quaternion.identity);
				temp.transform.localScale = new Vector3(0.1f,0.1f,0.1f);
				//temp.transform.parent = MiniMap.transform;
				tempList[j] = temp;
				j++;
			}

			if (inArea[i].tag == "Mushroom")
			{
				Vector3 tempPos = center.InverseTransformPoint(inArea[i].gameObject.transform.position);//relative to the center of player
				tempPos.x = tempPos.x*scale;//
				tempPos.z = tempPos.z*scale;// the scale to minimize the pos on MINIMap
				tempPos.y = tempPos.y*scale;
				Vector3 posRelatePlane = MiniMapCenter.transform.TransformPoint(tempPos);//position relate to centerpoint of map
				GameObject temp;
				temp = (GameObject)Instantiate(environment2, posRelatePlane, Quaternion.identity);
				temp.transform.localScale = new Vector3(0.1f,0.1f,0.1f);//the scale of object in MiniMap
				//temp.transform.parent = MiniMap.transform;
				tempList[j] = temp;
				j++;
			}

			if (inArea[i].tag == "Slime")
			{
				Vector3 tempPos = center.InverseTransformPoint(inArea[i].gameObject.transform.position);//relative to the center of player
				tempPos.x = tempPos.x*scale;//
				tempPos.z = tempPos.z*scale;// the scale to minimize the pos on MINIMap
				tempPos.y = tempPos.y*scale;
				Vector3 posRelatePlane = MiniMapCenter.transform.TransformPoint(tempPos);//position relate to centerpoint of map
				GameObject temp;
				temp = (GameObject)Instantiate(environment4, posRelatePlane, Quaternion.identity);
				temp.transform.localScale = new Vector3(0.003f,0.003f,0.003f);//the scale of object in MiniMap
				//temp.transform.parent = MiniMap.transform;
				tempList[j] = temp;
				j++;
			}

        }

    }
	public void ScaleMap(){
		scale=(50-radius)/100;
	}

	public void ShowMiniMap(){
		haveMiniMap = true;
	}

	public void DismissMiniMap(){
		haveMiniMap = false;
	}

	
	public Vector3 getMiniMapPos(Vector3 pos){
		Vector3 MiniMapPos;
		MiniMapPos = pos + Vector3.left * 10;
		return MiniMapPos;
	}

    public void UpdateMiniMap() // a flash mini map
    {
		if (haveMiniMap) {
			CreateMiniMap ();
			Invoke ("DestroyMiniMap", 0.08f);
		}
    }

    void DestroyMiniMap()
    {
     
        for(int i = 0; i < tempList.Length; i++)
        {
            Destroy(tempList[i]);
        }

    }

  


}
