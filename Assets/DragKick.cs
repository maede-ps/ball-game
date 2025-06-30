using UnityEngine;

public class DragKick : MonoBehaviour
{
    public float baseForce = 10f; // اینو خودت تنظیم کن
    public LineRenderer trailRenderer; // برای ویژوال افکت موقع درگ

    private Vector2 startDragPos;
    private Vector2 endDragPos;
    private Rigidbody2D rb;

    public int Coin_Count;

    public float Play_Life_Time;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (trailRenderer != null)
            trailRenderer.positionCount = 0;
    }

    private void Update()
    {
        Play_Life_Time += Time.deltaTime;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Vector2 touchWorldPos = Camera.main.ScreenToWorldPoint(touch.position);

            if (touch.phase == TouchPhase.Began)
            {
                startDragPos = touchWorldPos;
                if (trailRenderer != null)
                {
                    trailRenderer.positionCount = 1;
                    trailRenderer.SetPosition(0, startDragPos);
                }
            }

            if (touch.phase == TouchPhase.Moved)
            {
                if (trailRenderer != null)
                {
                    trailRenderer.positionCount = 2;
                    trailRenderer.SetPosition(1, touchWorldPos);
                }
            }

            if (touch.phase == TouchPhase.Ended)
            {
                endDragPos = touchWorldPos;
                Vector2 direction = (endDragPos - startDragPos).normalized;
                float distance = Vector2.Distance(endDragPos, startDragPos);

                // اعمال نیرو به توپ
                rb.velocity = Vector2.zero; // ریست سرعت قبلی
                rb.AddForce(direction * baseForce * distance, ForceMode2D.Impulse);

                // ریست افکت
                if (trailRenderer != null)
                    trailRenderer.positionCount = 0;
            }
        }
    }



    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Item ite = collision.collider.gameObject.GetComponent<Item>();
    //    if (ite != null)
    //    {
    //        UnityEngine.Debug.Log(collision.collider.name);
    //    }
    //}


}
