using UnityEngine;

namespace Utils
{
    public class ViewComponent: MonoBehaviour
    {
        
        protected void Activate()
        {
            this.gameObject.SetActive(true);
        }

        protected void Deactivate()
        {
            this.gameObject.SetActive(false);
        }

        protected int IndexInParent
        {
            get
            {
                var thisTransform = this.transform;
                int index = -1;
                var parent = this.gameObject.transform.parent;
                int count = parent.childCount;
                int i = 0;
                while (index == -1 && i < count)
                {
                    if (parent.GetChild(i) == thisTransform)
                    {
                        index = i;
                    }
                    i++;
                }
                return index;
            }
        }
        
    }
}