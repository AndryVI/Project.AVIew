using System;

namespace Project.AVIew.Model
{
    public class ResponsTomorrowAPI
    {
        public Data data { get; set; }
    }
    public class Data
    {
        public Timelines[] timelines { get; set; }
    }

    public class Timelines
    {
        public string timestep { get; set; }
        public DateTime endTime { get; set; }
        public DateTime startTime { get; set; }
        public IntervalsByOueth[] intervals { get; set; }
    }

    public class IntervalsByOueth
    {
        public DateTime startTime { get; set; }
        public Values values { get; set; }
    }

    public class Values
    {
        public double temperature { get; set; }
    }
}