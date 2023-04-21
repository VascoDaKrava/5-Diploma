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


        #region Worker harvesting

        /// <summary>
        /// Bool. Harvest fruit
        /// </summary>
        public static int HAVE_BASKET => Animator.StringToHash("HaveBasket");
        
        /// <summary>
        /// Bool. Harvest at middle hight
        /// </summary>
        public static int HARVEST_MIDDLE => Animator.StringToHash("PickMiddle");
        
        /// <summary>
        /// Bool. Harvest wood
        /// </summary>
        public static int HAVE_AXE => Animator.StringToHash("HaveAxe");

        /// <summary>
        /// Bool. Slash tree
        /// </summary>
        public static int AXE_SLASH_TREE => Animator.StringToHash("AxeSlashBottom");

        #endregion

    }
}