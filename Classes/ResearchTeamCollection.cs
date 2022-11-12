﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4_Ch
{
    public class ResearchTeamCollection<TKey>
    {
        private Dictionary<TKey, ResearchTeam> dictionary;
        private KeySelector<TKey> keyGenerator;

        public ResearchTeamCollection(KeySelector<TKey> method)
        {
            keyGenerator = method;
            dictionary = new Dictionary<TKey, ResearchTeam>();
        }
        public void AddDefaults(int count)
        {
            for (int i = 0; i < count; i++)
            {
                ResearchTeam rt = Inputs.inputRT();
                dictionary.Add(keyGenerator(rt), rt);
            }
        }

        public DateTime MaxDateTimeElement
        {
            get
            {
                if (dictionary == null) return new DateTime();
                else
                {
                    return dictionary.Values.Max(obj => obj.data);
                }
            }
        }
        public IEnumerable<IGrouping <TimeFrame, KeyValuePair <TKey, ResearchTeam> > > grouping
        {
            get
            {
                return dictionary.GroupBy(obj => obj.Value.GetTime());
            }
        }
        public IEnumerable<KeyValuePair<TKey, ResearchTeam>> TimeFrameGroup(TimeFrame value)
        {
            return dictionary.Where(obj => obj.Value.GetTime() == value);
        }
        override public string ToString()
        {
            string ans = "";
            foreach (KeyValuePair<TKey, ResearchTeam> item in dictionary)
            {
                ans += "=============================\nKey:\n" + item.Key.ToString() + "\t\t\tTeam:\n" 
                    + item.Value.ToString() + "=============================";
            }
            return ans;
        }
        public string ToShortString()
        {
            string ans = "";
            foreach (KeyValuePair<TKey, ResearchTeam> item in dictionary)
            {
                ans += "=============================\nKey:\n" + item.Key.ToString() + "\t\t\tTeam:\n"
                    + item.Value.ToShortString() + "=============================";
            }
            return ans;
        }
    }
}
