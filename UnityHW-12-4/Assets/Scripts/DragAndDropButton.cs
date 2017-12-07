using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDropButton : MonoBehaviour, IPointerDownHandler {
    public DragAndDropSystem system;

    public GameObject spawningMonsterUI;
    public GameObject spawningMonster;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnPointerDown(PointerEventData data) {
        system.StartDrag(spawningMonsterUI, spawningMonster);
    }
}
