using UnityEngine;

public class DragAndDropSystem : MonoBehaviour {

    private GameObject ui;
    private GameObject prefab;
    public Canvas canvas;

    private Board prev;
    private Board now;

    private bool _isDragging = false;
    public bool isDragging {
        get {
            return _isDragging;
        }
    }

	// Update is called once per frame
	void Update () {
        if (!_isDragging) return;

        ui.transform.position = Input.mousePosition;

        Vector3 origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(origin.x, origin.y), Vector2.zero, 100f, 1 << 8);
        if (hit) {
            now = hit.transform.GetComponent<Board>();
            if (prev) {
                if (now != prev) {
                    prev.Highlight(false);
                    now.Highlight(true);
                }
            } else now.Highlight(true);
        } else if (prev) {
            prev.Highlight(false);
            now = null;
        } else now = null;
        prev = now;

        if(Input.GetMouseButtonUp(0)) EndDrag();
    }

    void EndDrag() {
        _isDragging = false;
        Destroy(ui);
        if(now) {
            now.monster = Instantiate(prefab) as GameObject;
            now.Highlight(false);
            now = null;
        }
    }

    public void StartDrag(GameObject prefabUI, GameObject prefab) {
        this.ui = Instantiate(prefabUI, Input.mousePosition, Quaternion.identity, canvas.transform) as GameObject;
        this.prefab = prefab;
        _isDragging = true;
    }

}
