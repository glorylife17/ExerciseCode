using ExerciseCode.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ExerciseCode.Course2
{
    /// <summary>
    /// 有 n 件工作。各工作分別由時間 Si 開始，並於時間 Ti 結束。
    /// 你一定要選擇是參加各項工作。
    /// 如果參加了就一定要全程，另外參加之工作時間不能重疊。
    /// </summary>
    class Function6 : IFunction
    {
        private List<Job> jobs;
        private Dictionary<int, int> jobsMaxNumber;
        private Dictionary<int, string> jobsMaxWorks;

        private void setData()
        {
            this.jobs = new List<Job>
            {
                new Job{ id=1, es=1, ef=3 },
                new Job{ id=2, es=2, ef=5 },
                new Job{ id=3, es=4, ef=7 },
                new Job{ id=4, es=6, ef=9 },
                new Job{ id=5, es=8, ef=10 },
            };

            jobsMaxNumber = new Dictionary<int, int>();
            foreach (var job in this.jobs)
            {
                jobsMaxNumber.Add(job.id, 0);
            }

            jobsMaxWorks = new Dictionary<int, string>();
            foreach (var job in this.jobs)
            {
                jobsMaxWorks.Add(job.id, "");
            }
        }

        public void solve1()
        {
            Console.Write("solve1 :");

            var sw = new Stopwatch();
            sw.Start();

            foreach (var job in jobs)
            {
               findCanWork(job, 0, job.id, job.id.ToString());
            }

            var maxId = jobsMaxNumber.OrderByDescending(x => x.Value).First().Key;
            sw.Stop();

            Console.WriteLine($"最大工作量: {jobsMaxNumber[maxId]}, 依序做:{jobsMaxWorks[maxId]} \t time:{sw.ElapsedMilliseconds}");
        }

        private int findCanWork(Job job, int order, int id, string workIds)
        {
            order++;

            var works = this.jobs.Where(x => x.es > job.ef).ToList();
            var step = new int[works.Count];

            for (int i = 0; i < works.Count; i++)
            {
                var item = works[i];
                workIds += $", {item.id}";
                step[i] = findCanWork(item, order, id, workIds);
            }

            if (jobsMaxNumber[id] < order)
            {
                jobsMaxNumber[id] = Math.Max(jobsMaxNumber[id], order);
                jobsMaxWorks[id] = workIds;
            }
            return jobsMaxNumber[id];
        }

        public void solve2()
        {
            Console.Write("solve2 :");

            var sw = new Stopwatch();
            sw.Start();

            var tmpJobs = this.jobs.OrderBy(x => x.ef).ThenByDescending(x => x.es).ToList();

            var tmpES = 0;
            var jobsMax = 0;
            var jobsWork = new List<int>();

            foreach (var item in tmpJobs)
            {
                if(tmpES < item.es)
                {
                    jobsMax++;
                    jobsWork.Add(item.id);
                    tmpES = item.ef;
                }
            }

            sw.Stop();

            Console.WriteLine($"最大工作量: {jobsMax}, 依序做:{string.Join(", ",jobsWork)} \t time:{sw.ElapsedMilliseconds}");
        }


        public void test()
        {
            setData();
            solve1();
            solve2();
        }
    }

    internal class Job
    {
        public int id { get; set; }

        /// <summary>
        /// Earliest Start
        /// </summary>
        public int es { get; set; }

        /// <summary>
        /// Earliest Finish
        /// </summary>
        public int ef { get; set; }
    }
}
