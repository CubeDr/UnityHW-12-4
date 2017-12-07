using UnityEngine;

public class DragAndDropSystem : MonoBehaviour {

    private GameObject prefabUI;
    private GameObject prefab;
    public Canvas canvas;

    private bool isDragging = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!isDragging) return;

        prefabUI.transform.position = Input.mousePosition;
        if (Input.GetMouseButtonUp(0)) EndDrag();
	}

    private void EndDrag() {
        isDragging = false;
        Destroy(prefabUI);
    }

    public void StartDrag(GameObject prefabUI, GameObject prefab) {
        this.prefabUI = Instantiate(prefabUI, Input.mousePosition, Quaternion.identity, canvas.transform) as GameObject;
        this.prefab = prefab;
        isDragging = true;
    }
}
