using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantsRecommendation.Models
{
    public class value
    {
        public List<List<string>> Values { get; set; }

    }
    public class Output1
    {
        public value value { get; set; }

    }
    public class Root
    {
        public Results Results { get; set; }
    }
    public class Results
    {
        public Output1 output1 { get; set; }
    }
}