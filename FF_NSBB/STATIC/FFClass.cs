using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FF_NSBB.STATIC
{
    public class FFClass
    {
    }

    public class localPlayer
    {
        public int ID { get; set; }
        public string FIRST { get; set; }
        public string LAST { get; set; }
        public string FullName { get; set; }
        public double? ADP { get; set; }
        public string Team { get; set; }
        public int? Bye { get; set; }
        public string Pos { get; set; }
        public int? VDB { get; set; }
        public int? Pts { get; set; }
        public int? OVERALL { get; set; }
        public bool? Drafted { get; set; }
        public bool? MyTeam { get; set; }
        public string SID { get; set; }

    }

    public class MyTeam
    {
        public string QB { get; set; }
        public string RB1 { get; set; }
        public string RB2 { get; set; }
        public string WR1 { get; set; }
        public string WR2 { get; set; }
        public string WR3 { get; set; }
        public string TE { get; set; }
        public string FLEX { get; set; }
        public string K { get; set; }
        public string DEF { get; set; }
        public string BENCH1 { get; set; }
        public string BENCH2 { get; set; }
        public string BENCH3 { get; set; }
        public string BENCH4 { get; set; }
        public string BENCH5 { get; set; }
        public string BENCH6 { get; set; }
    }

    public class FFTeam
    {
        public int TeamID { get; set; }
        public string TeamName { get; set; }
        public string QB { get; set; }
        public string RB1 { get; set; }
        public string RB2 { get; set; }
        public string WR1 { get; set; }
        public string WR2 { get; set; }
        public string WR3 { get; set; }
        public string TE { get; set; }
        public string FLEX { get; set; }
        public string K { get; set; }
        public string DEF { get; set; }
        public string BENCH1 { get; set; }
        public string BENCH2 { get; set; }
        public string BENCH3 { get; set; }
        public string BENCH4 { get; set; }
        public string BENCH5 { get; set; }
        public string BENCH6 { get; set; }
    }

    public class localTeam
    {
        public int ID { get; set; }
        public string TeamName { get; set; }
        public string TeamManager { get; set; }
        public string Picture { get; set; }
        public int? DraftOrder { get; set; }
    }
}