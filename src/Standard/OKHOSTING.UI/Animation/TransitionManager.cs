using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace OKHOSTING.UI.Animations
{
    /// <summary>
    /// This class is responsible for running transitions. It holds the timer that
    /// triggers transition animation. 
    /// </summary><remarks>
    /// This class is a singleton.
    /// 
    /// We manage the transition timer here so that we can have a single timer
    /// across all transitions. If each transition has its own timer, this creates
    /// one thread for each transition, and this can lead to too many threads in
    /// an application.
    /// 
    /// This class essentially just manages the timer for the transitions. It calls 
    /// back into the running transitions, which do the actual work of the transition.
    /// 
    /// Based on a great project by Uwe Keim https://github.com/UweKeim/dot-net-transitions
    /// </remarks>
    internal class TransitionManager
    {
        #region Public methods

        /// <summary>
        /// Singleton's getInstance method.
        /// </summary>
        public static TransitionManager GetInstance()
        {
            if (Instance == null)
            {
                Instance = new TransitionManager();
            }
            return Instance;
        }

        /// <summary>
        /// You register a transition with the manager here. This will start to run
        /// the transition as the manager's timer ticks.
        /// </summary>
        public void Register(Transition transition)
        {
            lock (Lock)
            {
                // We check to see if the properties of this transition
                // are already being animated by any existing transitions...
                RemoveDuplicates(transition);

                // We add the transition to the collection we manage, and 
                // observe it so that we know when it has completed...
                Transitions[transition] = true;
                transition.TransitionCompleted += OnTransitionCompleted;
            }
        }

        #endregion

        #region Private functions

        /// <summary>
        /// Checks if any existing transitions are acting on the same properties as the
        /// transition passed in. If so, we remove the duplicated properties from the 
        /// older transitions.
        /// </summary>
        private void RemoveDuplicates(Transition transition)
        {
            // We look through the set of transitions we're currently managing...
            foreach (KeyValuePair<Transition, bool> pair in Transitions)
            {
                RemoveDuplicates(transition, pair.Key);
            }
        }

        /// <summary>
        /// Finds any properties in the old-transition that are also in the new one,
        /// and removes them from the old one.
        /// </summary>
        private void RemoveDuplicates(Transition newTransition, Transition oldTransition)
        {
            // Note: This checking might be a bit more efficient if it did the checking
            //       with a set rather than looking through lists. That said, it is only done 
            //       when transitions are added (which isn't very often) rather than on the
            //       timer, so I don't think this matters too much.

            // We get the list of properties for the old and new transitions...
            IList<TransitionedMember> newProperties = newTransition.TransitionedProperties;
            IList<TransitionedMember> oldProperties = oldTransition.TransitionedProperties;

            // We loop through the old properties backwards (as we may be removing 
            // items from the list if we find a match)...
            for (int i = oldProperties.Count - 1; i >= 0; i--)
            {
                // We get one of the properties from the old transition...
                TransitionedMember oldProperty = oldProperties[i];

                // Is this property part of the new transition?
                foreach (TransitionedMember newProperty in newProperties)
                {
                    if (oldProperty.target == newProperty.target
                        &&
                        oldProperty.Member == newProperty.Member)
                    {
                        // The old transition contains the same property as the new one,
                        // so we remove it from the old transition...
                        oldTransition.RemoveProperty(oldProperty);
                    }
                }
            }
        }

        /// <summary>
        /// Private constructor (for singleton).
        /// </summary>
        private TransitionManager()
        {
            Timer = new Timer(15);
            Timer.Elapsed += OnTimerElapsed;
            Timer.Enabled = true;
        }

        /// <summary>
        /// Called when the timer ticks.
        /// </summary>
        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            // We turn the timer off while we process the tick, in case the
            // actions take longer than the tick itself...
            if (Timer == null)
            {
                return;
            }
            Timer.Enabled = false;

            IList<Transition> listTransitions;
            lock (Lock)
            {
                // We take a copy of the collection of transitions as elements 
                // might be removed as we iterate through it...
                listTransitions = new List<Transition>();
                foreach (KeyValuePair<Transition, bool> pair in Transitions)
                {
                    listTransitions.Add(pair.Key);
                }
            }

            // We tick the timer for each transition we're managing...
            foreach (Transition transition in listTransitions)
            {
                transition.OnTimer();
            }

            // We restart the timer...
            Timer.Enabled = true;
        }

        /// <summary>
        /// Called when a transition has completed. 
        /// </summary>
        private void OnTransitionCompleted(object sender, System.EventArgs e)
        {
            // We stop observing the transition...
            Transition transition = (Transition)sender;
            transition.TransitionCompleted -= OnTransitionCompleted;

            // We remove the transition from the collection we're managing...
            lock (Lock)
            {
                Transitions.Remove(transition);
            }
        }

        #endregion

        #region Private data

        // The singleton instance...
        private static TransitionManager Instance = null;

        // The collection of transitions we're managing. (This should really be a set.)
        private IDictionary<Transition, bool> Transitions = new Dictionary<Transition, bool>();

        // The timer that controls the transition animation...
        private Timer Timer = null;

        // An object to lock on. This class can be accessed by multiple threads: the 
        // user thread can add new transitions; and the timerr thread can be animating 
        // them. As they access the same collections, the methods need to be protected 
        // by a lock...
        private object Lock = new object();

        #endregion
    }
}


