﻿using System;

namespace Project.AVIew.OtherAPI.Model.Tomorrow
{
    public class ResponsTomorrowAPI
    {
        public Data Data { get; set; }
    }
    public class Data
    {
        public Timelines[] Timelines { get; set; }
    }

    public class Timelines
    {
        public string Timestep { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime StartTime { get; set; }
        public IntervalsByDate[] Intervals { get; set; }
    }

    public class IntervalsByDate
    {
        public DateTime StartTime { get; set; }
        public Values Values { get; set; }
    }
}