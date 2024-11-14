using UnityEngine;
using UnityEngine.InputSystem;

namespace MyVrSample
{
    /// <summary>
    /// Teleport Ray�� �����ϴ� Ŭ����
    /// </summary>
    public class ActivateTeleportRay : MonoBehaviour
    {
        #region Variables
        public GameObject leftTeleportRay;          //�ڷ���Ʈ ���� Ray ������Ʈ
        public GameObject rightTeleportRay;         //�ڷ���Ʈ ������ Ray ������Ʈ

        public InputActionProperty leftActivate;    //���� ��Ʈ�ѷ��� Activate �Է�
        public InputActionProperty rightActivate;   //������ ��Ʈ�ѷ��� Activate �Է�
        #endregion

        private void Update()
        {
            float leftAivateValue = leftActivate.action.ReadValue<float>();
            float rightAivateValue = rightActivate.action.ReadValue<float>();

            leftTeleportRay.SetActive(leftAivateValue > 0.1f);
            rightTeleportRay.SetActive(rightAivateValue > 0.1f);
        }
    }
}