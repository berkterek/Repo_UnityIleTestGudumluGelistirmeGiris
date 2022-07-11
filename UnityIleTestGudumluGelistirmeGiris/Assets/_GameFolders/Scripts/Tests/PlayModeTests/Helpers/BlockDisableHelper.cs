using UnityEngine;

namespace PlayModeTest.Helpers
{
    public class BlockDisableHelper : MonoBehaviour
    {
        [SerializeField] Collider2D _collider2D;

        public void SetDisableCollider()
        {
            _collider2D.enabled = false;
        }
    }    
}

