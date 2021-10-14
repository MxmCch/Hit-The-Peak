using UnityEngine;

public class ScreenEdgeCollider : MonoBehaviour
{
    public GameObject topAnchor;
    GameObject top;
    GameObject bottom;
    GameObject left;
    GameObject right;

    void Awake()
    {
        top = new GameObject("Top");
        bottom = new GameObject("Bottom");
        left = new GameObject("Left");
        right = new GameObject("Right");

        top.transform.parent = this.gameObject.transform;
        bottom.transform.parent = this.gameObject.transform;
        left.transform.parent = this.gameObject.transform;
        right.transform.parent = this.gameObject.transform;
    }

    void Start()
    {
        CreateScreenColliders();
        CreateEffector();
    }

    //Collider needs Effector2D so the ball doesnt get stuck in place
    void CreateEffector()
    {
        //// Create top effector2D
        AreaEffector2D effector2D = top.AddComponent<AreaEffector2D>();
        effector2D.forceAngle = 270;
        effector2D.forceMagnitude = 1;

        //// Create bottom effector2D
        effector2D = bottom.AddComponent<AreaEffector2D>();
        effector2D.forceAngle = -270;
        effector2D.forceMagnitude = 1;

        //// Create left effector2D
        effector2D = left.AddComponent<AreaEffector2D>();
        effector2D.forceAngle = 0;
        effector2D.forceMagnitude = 1;

        //// Create right effector2D
        effector2D = right.AddComponent<AreaEffector2D>();
        effector2D.forceAngle = 180;
        effector2D.forceMagnitude = 1;
    }
 
    void CreateScreenColliders()
    {
        Vector3 bottomLeftScreenPoint = Camera.main.ScreenToWorldPoint(new Vector3(0f, 0f, 0f));
        Vector3 topRightScreenPoint = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));

        //// Create top collider
        BoxCollider2D collider = top.AddComponent<BoxCollider2D>();
        collider.usedByEffector = true;
        collider.size = new Vector3(Mathf.Abs(bottomLeftScreenPoint.x - topRightScreenPoint.x), 0.1f, 0f);
        collider.offset = new Vector2(collider.size.x / 2f, collider.size.y / 2f);

        top.transform.position = new Vector3((bottomLeftScreenPoint.x - topRightScreenPoint.x) / 2f, topAnchor.transform.position.y, 0f);

        // Create bottom collider
        collider = bottom.AddComponent<BoxCollider2D>();
        collider.usedByEffector = true;
        collider.size = new Vector3(Mathf.Abs(bottomLeftScreenPoint.x - topRightScreenPoint.x), 0.1f, 0f);
        collider.offset = new Vector2(collider.size.x / 2f, collider.size.y / 2f);

        //** Bottom needs to account for collider size
        bottom.transform.position = new Vector3((bottomLeftScreenPoint.x - topRightScreenPoint.x) / 2f, bottomLeftScreenPoint.y - collider.size.y, 0f);

        // Create left collider
        collider = left.AddComponent<BoxCollider2D>();
        collider.usedByEffector = true;
        collider.size = new Vector3(0.1f, Mathf.Abs(topRightScreenPoint.y - bottomLeftScreenPoint.y), 0f);
        collider.offset = new Vector2(collider.size.x / 2f, collider.size.y / 2f);

        //** Left needs to account for collider size
        left.transform.position = new Vector3(((bottomLeftScreenPoint.x - topRightScreenPoint.x) / 2f) - collider.size.x, bottomLeftScreenPoint.y, 0f);

        // Create right collider
        collider = right.AddComponent<BoxCollider2D>();
        collider.usedByEffector = true;
        collider.size = new Vector3(0.1f, Mathf.Abs(topRightScreenPoint.y - bottomLeftScreenPoint.y), 0f);
        collider.offset = new Vector2(collider.size.x / 2f, collider.size.y / 2f);

        right.transform.position = new Vector3(topRightScreenPoint.x, bottomLeftScreenPoint.y, 0f);
    }
}