using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

namespace MyFps
{
    public abstract class GrabInteractable : XRGrabInteractable
    {
        protected abstract void DoAction();

        #region Variables
        private float theDistance;

        //action UI
        public GameObject actionUI;
        public TextMeshProUGUI actionText;
        [SerializeField] private string action = "Action Text";

        //true�̸� Interactive ����� ����
        protected bool unInteractive = false;

        //ī�޶�
        private Transform head;
        #endregion

        protected virtual void Start()
        {
            //����
            head = Camera.main.transform;
        }

        protected virtual void Update()
        {
            theDistance = PlayerCasting.distanceFromTarget;
        }

        protected override void OnHoverEntered(HoverEnterEventArgs args)
        {
            if (unInteractive)
                return;

            base.OnHoverEntered(args);
            ShowActionUI();

        }

        protected override void OnHoverExited(HoverExitEventArgs args)
        {
            base.OnHoverExited(args);
            HideActionUI();
        }

        protected override void OnSelectEntered(SelectEnterEventArgs args)
        {
            base.OnSelectEntered(args);

            HideActionUI();

            //Action
            DoAction();
        }

        void ShowActionUI()
        {
            actionUI.SetActive(true);

            //theDistance �� ������Ʈ������ �Ÿ��� ����Ͽ�
            float distance = Vector3.Distance(head.position, transform.position);
            if(distance < theDistance)
            {
                actionUI.transform.position = head.position
                    + new Vector3(head.forward.x, 0f, head.forward.z).normalized * (distance - 0.02f);
            }
            else
            {
                actionUI.transform.position = head.position
                    + new Vector3(head.forward.x, 0f, head.forward.z).normalized * (theDistance - 0.01f);
            }

            
            actionUI.transform.LookAt(new Vector3(head.position.x, actionUI.transform.position.y, head.position.z));
            actionUI.transform.forward *= -1;

            actionText.text = action;
        }

        void HideActionUI()
        {
            actionUI.SetActive(false);
            actionText.text = "";
        }
    }
}
