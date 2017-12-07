using UnityEngine;

public class DragAndDropSystem : MonoBehaviour {

    private GameObject prefabUI;
    private GameObject prefab;
    public Canvas canvas;

    private bool isDragging = false;

	// Update is called once per frame
	void Update () {
        if (!isDragging) return;

        prefabUI.transform.position = Input.mousePosition;
        if (Input.GetMouseButtonUp(0)) EndDrag();
	}

    private void EndDrag() {
        isDragging = false;
        Destroy(prefabUI);
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        Instantiate(prefab, pos, Quaternion.identity);
    }

    public void StartDrag(GameObject prefabUI, GameObject prefab) {
        this.prefabUI = Instantiate(prefabUI, Input.mousePosition, Quaternion.identity, canvas.transform) as GameObject;
        this.prefab = prefab;
        isDragging = true;
    }
}
