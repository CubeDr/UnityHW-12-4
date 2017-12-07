using UnityEngine;

public class Board : MonoBehaviour {
    public DragAndDropSystem system;

    public Color defaultColor = Color.white;
    public Color highlightedColor = Color.green;
    private new SpriteRenderer renderer;

    private GameObject _monster;
    public GameObject monster {
        get {
            return _monster;
        }

        set {
            if (_monster) Destroy(_monster);
            _monster = value;
            _monster.transform.position = transform.position + Vector3.back;
        }
    }

    // Use this for initialization
    void Start() {
        renderer = GetComponent<SpriteRenderer>();
    }

    public void Highlight(bool highlight) {
        renderer.color = highlight ? highlightedColor : defaultColor;
    }
}
