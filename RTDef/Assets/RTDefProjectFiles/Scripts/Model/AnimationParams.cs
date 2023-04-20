using UnityEngine;


namespace RTDef.Game.Animations
{
    /// <summary>
    /// All Hashs for animation
    /// </summary>
    public static class AnimationParams
    {

        #region Move

        /// <summary>
        /// Float Value [0 : 1]
        /// </summary>
        public static int VELOCITY_FORWARD => Animator.StringToHash("VelocityForward");

        /// <summary>
        /// Float Value [-1 (right) : 1 (left)]
        /// </summary>
        public static int ROTATION => Animator.StringToHash("Rotation");

        #endregion


        #region Attack

        /// <summary>
        /// Trigger. Make attack
        /// </summary>
        public static int FIRE => Animator.StringToHash("Fire");

        #endregion


        #region Die

        /// <summary>
        /// Trigger. Do die
        /// </summary>
        public static int DIE => Animator.StringToHash("NeedDie");

        #endregion

    }
}