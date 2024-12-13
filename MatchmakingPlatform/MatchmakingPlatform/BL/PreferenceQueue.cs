using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchmakingPlatform.BL
{
    public class PreferenceQueue
    {
        private List<Preference> queue;

        public PreferenceQueue()
        {
            queue = new List<Preference>();
        }

        public void Enqueue(Preference preference)
        {
            queue.Add(preference);
        }

        public Preference Dequeue()
        {
            if (queue.Count == 0)
            {
                return null;
            }
            Preference preference = queue[0];
            queue.RemoveAt(0); // Remove the first item
            return preference;

        }

        public Preference Peek()
        {
            if (queue.Count == 0)
            {
                return null;
            }
            return queue[0];
        }


        public bool IsEmpty()
        {
            return queue.Count == 0;
        }

        public int Size()
        {
            return queue.Count;
        }

        public void Clear()
        {
            queue.Clear();
        }



    }
}

