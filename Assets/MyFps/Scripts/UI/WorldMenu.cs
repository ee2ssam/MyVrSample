using MyFps;
using TMPro;
using UnityEngine;

public class WorldMenu : MonoBehaviour
{
    #region Variables
    public GameObject worldMenuUI;
    public TextMeshProUGUI textBox;

    private Transform head;
    private float distance;
    [SerializeField] private float offset = 1.0f;
    #endregion

    protected virtual void Start()
    {
        //참조
        head = Camera.main.transform;
    }

    protected virtual void Update()
    {
        distance = PlayerCasting.distanceFromTarget;
    }

    protected void ShowMenuUI(string sequenceText = "")
    {
        worldMenuUI.SetActive(true);

        //show 설정
        distance = (distance < offset) ? distance - 0.05f : offset;
        worldMenuUI.transform.position = head.position + new Vector3(head.forward.x, 0f, head.forward.z).normalized * distance;
        worldMenuUI.transform.LookAt(new Vector3(head.position.x, worldMenuUI.transform.position.y, head.position.z));
        worldMenuUI.transform.forward *= -1;

        //text 설정
        if (textBox)
        {
            textBox.text = sequenceText;
        }
    }

    protected void HideMenuUI()
    {
        worldMenuUI.SetActive(false);
        textBox.text = "";
    }
}
