using ExerciseCode.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExerciseCode.LeetCode
{
    class GroupAnagrams : IFunction
    {
        public void solve1()
        {
            Dictionary<string, List<string>> dic = new Dictionary<string, List<string>>();

            List<PairWord> pairs = new List<PairWord>();
            var words = new string[] { "eat", "tea", "tan", "ate", "nat", "bat" };

            for(var i = 0; i < words.Length; i++)
            {
                var word = words[i];
                pairs.Add(new PairWord { ori = word, sort = sortWord(word) });
            
            }
            pairs.Sort((x, y) => x.sort.CompareTo(y.sort));

            foreach (var item in pairs)
            {
                if (!dic.ContainsKey(item.sort))
                {
                    dic.Add(item.sort, new List<string>() { item.ori });
                }
                else
                {
                    dic[item.sort].Add(item.ori);
                }
            }

            foreach (var item in dic)
            {
                Console.WriteLine($"[{string.Join(", ", item.Value)}]");
            }
        }

        private class PairWord
        {
            public string ori;
            public string sort;
        }

        private string sortWord(string word)
        {
            var strs = word.ToCharArray();
            for (int k = 0; k + 1 < strs.Length; k++)
            {
                for (int j = k + 1; j < strs.Length; j++)
                {
                    if (strs[k] > strs[j])
                    {
                        var tmp = strs[k];
                        strs[k] = strs[j];
                        strs[j] = tmp;
                    }
                }
            }
            return  string.Join("", strs);
        }

        public void solve2()
        {
            throw new NotImplementedException();
        }

        public void test()
        {
            Console.WriteLine("LeetCode Group Anagrams:");
            solve1();

            Console.WriteLine("");
        }
    }
}
