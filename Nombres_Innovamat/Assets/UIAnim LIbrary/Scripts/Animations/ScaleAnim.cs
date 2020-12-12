using System.Collections;
using UnityEngine;

namespace Assets.UIAnim_LIbrary.Scripts.Animations
{
    public class ScaleAnim : UIAnim
    {
        private RectTransform rectTransform;

        public ScaleAnim(RectTransform t)
        {
            rectTransform = t;
        }

        public IEnumerator Execute()
        {
            yield return null;
        }

        public IEnumerator Execute(AnimationCurve animCurve, Vector3 size, float duration, float delayAfter, bool forward, NextFunctionDelegate nextFunction)
        {
            float time = 0;

            Vector3 initial = rectTransform.localScale;

            //play anim
            while (time < duration)
            {
                time += Time.deltaTime;

                //we get the point in the animation curve we are according to the direction and time
                float curveVal;
                if (forward)
                    curveVal = animCurve.Evaluate(time / duration); //follow the curve in all axis
                else
                {
                    curveVal = animCurve.Evaluate((duration - time) / duration); //follow the curve in all axis
                    curveVal = curveVal - 1; //we want it to be negative if we are going backwards
                }                    
                
                //we add to the original scale
                rectTransform.localScale = initial + new Vector3 (curveVal * size.x, curveVal * size.y, curveVal * size.z);

                yield return null;
            }

            //anim compleated
            yield return new WaitForSeconds(delayAfter);
            
            //call next function if there is one
            if (nextFunction != null)
                nextFunction();
        }
    }
}
