using UnityEngine;

public class Pipe : MonoBehaviour
{
    public int length { get; private set; }
    public bool flipped { get; private set; }

    private RectTransform rectTransform;
    [SerializeField]
    private RectTransform pipeLengthRectTransform;

    const int SIZE_PER_UNIT = 50; // Width size for RectTransform for a pipe length of 1
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Start()
    {
        // Delete later
        SetLength(20);
        Flip();
    }

    public void SetLength(int len)
    {
        length = len;
        pipeLengthRectTransform.sizeDelta = new Vector2(SIZE_PER_UNIT * len, pipeLengthRectTransform.sizeDelta.y);
   
        // Reset the positions of the pipe ends to the end of the pipe
        foreach (RectTransform rt in pipeLengthRectTransform)
        {
            float sizeX = rt.sizeDelta.x;
            float sizeY = rt.sizeDelta.y;
            int flipFactor = 1; // Whether or not the pipe end is going up (1) or down (-1)

            if (rt.name == "Down")
            {
                flipFactor = -1;
            }

            float posX = (pipeLengthRectTransform.sizeDelta.x / 2 + sizeX / 2) * flipFactor;
            float posY = sizeX / 2 * flipFactor;

            rt.anchoredPosition = new Vector2(posX, posY);
        }
    }

    public void Flip()
    {
        flipped = !flipped;

        if (flipped)
        {
            rectTransform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            rectTransform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
