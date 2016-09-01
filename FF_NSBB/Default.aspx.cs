using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FF_NSBB.DAL;
using FF_NSBB.STATIC;

namespace FF_NSBB
{
    public partial class _Default : Page
    {
        public MyTeam team = new MyTeam();

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                BuildData();
            }

        }

        private void cleanSpace()
        {
            using (FF2014Entities stx = new FF2014Entities())
            {
                var _players = from p in stx.FF_Player
                               where p.DRAFTED == false
                               select p;

                foreach(var p in _players)
                {
                    p.FIRST = p.FIRST.Trim();
                }
                stx.SaveChanges();
            }
        }

        private void BuildData()
        {
            List<MyTeam> teamList = new List<MyTeam>();
            List<localPlayer> playerList = new List<localPlayer>();

            using (FF2014Entities ptx = new FF2014Entities())
            {
                var _players = from p in ptx.FF_Player
                               where p.DRAFTED == false
                               select p;
                foreach (var p in _players)
                {
                    localPlayer l = new localPlayer();
                    l.ID = p.ID;
                    l.FIRST = p.FIRST;
                    l.LAST = p.LAST;
                    l.FullName = p.FIRST.Trim() + " " + p.LAST.Trim();
                    l.OVERALL = p.OVERALL;
                    l.ADP = p.ADP;
                    l.Team = p.TEAM;
                    l.Bye = p.BYE;
                    l.Pos = p.POS;
                    l.VDB = p.VBD;
                    l.Pts = p.PTS;
                    l.Drafted = p.DRAFTED;
                    l.MyTeam = p.MYTEAM;
                    l.SID = p.SID;
                    playerList.Add(l);
                }

                getCounters(ptx);
            }

            rptPlayers.DataSource = playerList.OrderBy(x=>x.OVERALL);
            rptPlayers.DataBind();

            updateTeam();
            teamList.Add(team);

            rptMyTeam.DataSource = teamList;
            rptMyTeam.DataBind();

            

        }


        

        #region Stuff
        private void updateCount(int pid, FF2014Entities itx, bool updown)
        {
            var p = (from y in itx.FF_Player
                     where y.ID == pid
                     select y).First();

            string _pos = p.POS.Trim();

            var c = (from x in itx.FF_TAKEN
                     where x.POS == _pos
                     select x).First();

            if (updown)
                c.COUNT++;
            else
                c.COUNT--;

            itx.SaveChanges();

        }

        private void updateTeam()
        {
            // if(Session["_team"] != null) {team = (MyTeam)Session["_team"];}
            using (FF2014Entities itx = new FF2014Entities())
            {
                var _player = from p in itx.FF_Player
                              where p.MYTEAM == true
                              select p;

                foreach (var t in _player)
                {

                    switch (t.POS.Trim())
                    {
                        case "QB":
                            if (string.IsNullOrEmpty(team.QB))
                            { team.QB = t.FIRST + " " + t.LAST; }
                            else if (string.IsNullOrEmpty(team.BENCH1))
                            { team.BENCH1 = t.FIRST + " " + t.LAST; }
                            else if (string.IsNullOrEmpty(team.BENCH2))
                            { team.BENCH2 = t.FIRST + " " + t.LAST; }
                            else if (string.IsNullOrEmpty(team.BENCH3))
                            { team.BENCH3 = t.FIRST + " " + t.LAST; }
                            else if (string.IsNullOrEmpty(team.BENCH4))
                            { team.BENCH4 = t.FIRST + " " + t.LAST; }
                            else if (string.IsNullOrEmpty(team.BENCH5))
                            { team.BENCH5 = t.FIRST + " " + t.LAST; }
                            else if (string.IsNullOrEmpty(team.BENCH6))
                            { team.BENCH6 = t.FIRST + " " + t.LAST; }
                            break;
                        case "RB":
                            if (string.IsNullOrEmpty(team.RB1))
                            { team.RB1 = t.FIRST + " " + t.LAST; }
                            else if (string.IsNullOrEmpty(team.RB2))
                            { team.RB2 = t.FIRST + " " + t.LAST; }
                            else if (string.IsNullOrEmpty(team.FLEX))
                            { team.FLEX = t.FIRST + " " + t.LAST; }
                            else if (string.IsNullOrEmpty(team.BENCH1))
                            { team.BENCH1 = t.FIRST + " " + t.LAST; }
                            else if (string.IsNullOrEmpty(team.BENCH2))
                            { team.BENCH2 = t.FIRST + " " + t.LAST; }
                            else if (string.IsNullOrEmpty(team.BENCH3))
                            { team.BENCH3 = t.FIRST + " " + t.LAST; }
                            else if (string.IsNullOrEmpty(team.BENCH4))
                            { team.BENCH4 = t.FIRST + " " + t.LAST; }
                            else if (string.IsNullOrEmpty(team.BENCH5))
                            { team.BENCH5 = t.FIRST + " " + t.LAST; }
                            else if (string.IsNullOrEmpty(team.BENCH6))
                            { team.BENCH6 = t.FIRST + " " + t.LAST; }
                            break;
                        case "WR":
                            if (string.IsNullOrEmpty(team.WR1))
                            { team.WR1 = t.FIRST + " " + t.LAST; }
                            else if (string.IsNullOrEmpty(team.WR2))
                            { team.WR2 = t.FIRST + " " + t.LAST; }
                            else if (string.IsNullOrEmpty(team.WR3))
                            { team.WR3 = t.FIRST + " " + t.LAST; }
                            else if (string.IsNullOrEmpty(team.FLEX))
                            { team.FLEX = t.FIRST + " " + t.LAST; }
                            else if (string.IsNullOrEmpty(team.BENCH1))
                            { team.BENCH1 = t.FIRST + " " + t.LAST; }
                            else if (string.IsNullOrEmpty(team.BENCH2))
                            { team.BENCH2 = t.FIRST + " " + t.LAST; }
                            else if (string.IsNullOrEmpty(team.BENCH3))
                            { team.BENCH3 = t.FIRST + " " + t.LAST; }
                            else if (string.IsNullOrEmpty(team.BENCH4))
                            { team.BENCH4 = t.FIRST + " " + t.LAST; }
                            else if (string.IsNullOrEmpty(team.BENCH5))
                            { team.BENCH5 = t.FIRST + " " + t.LAST; }
                            else if (string.IsNullOrEmpty(team.BENCH6))
                            { team.BENCH6 = t.FIRST + " " + t.LAST; }
                            break;
                        case "TE":
                            if (string.IsNullOrEmpty(team.TE))
                            { team.TE = t.FIRST + " " + t.LAST; }
                            else if (string.IsNullOrEmpty(team.FLEX))
                            { team.FLEX = t.FIRST + " " + t.LAST; }
                            else if (string.IsNullOrEmpty(team.BENCH1))
                            { team.BENCH1 = t.FIRST + " " + t.LAST; }
                            else if (string.IsNullOrEmpty(team.BENCH2))
                            { team.BENCH2 = t.FIRST + " " + t.LAST; }
                            else if (string.IsNullOrEmpty(team.BENCH3))
                            { team.BENCH3 = t.FIRST + " " + t.LAST; }
                            else if (string.IsNullOrEmpty(team.BENCH4))
                            { team.BENCH4 = t.FIRST + " " + t.LAST; }
                            else if (string.IsNullOrEmpty(team.BENCH5))
                            { team.BENCH5 = t.FIRST + " " + t.LAST; }
                            else if (string.IsNullOrEmpty(team.BENCH6))
                            { team.BENCH6 = t.FIRST + " " + t.LAST; }
                            break;
                        case "K":
                            if (string.IsNullOrEmpty(team.K))
                            { team.K = t.FIRST + " " + t.LAST; }
                            else if (string.IsNullOrEmpty(team.BENCH1))
                            { team.BENCH1 = t.FIRST + " " + t.LAST; }
                            else if (string.IsNullOrEmpty(team.BENCH2))
                            { team.BENCH2 = t.FIRST + " " + t.LAST; }
                            else if (string.IsNullOrEmpty(team.BENCH3))
                            { team.BENCH3 = t.FIRST + " " + t.LAST; }
                            else if (string.IsNullOrEmpty(team.BENCH4))
                            { team.BENCH4 = t.FIRST + " " + t.LAST; }
                            else if (string.IsNullOrEmpty(team.BENCH5))
                            { team.BENCH5 = t.FIRST + " " + t.LAST; }
                            else if (string.IsNullOrEmpty(team.BENCH6))
                            { team.BENCH6 = t.FIRST + " " + t.LAST; }
                            break;
                        case "DEF":
                            if (string.IsNullOrEmpty(team.DEF))
                            { team.DEF = t.FIRST + " " + t.LAST; }
                            else if (string.IsNullOrEmpty(team.BENCH1))
                            { team.BENCH1 = t.FIRST + " " + t.LAST; }
                            else if (string.IsNullOrEmpty(team.BENCH2))
                            { team.BENCH2 = t.FIRST + " " + t.LAST; }
                            else if (string.IsNullOrEmpty(team.BENCH3))
                            { team.BENCH3 = t.FIRST + " " + t.LAST; }
                            else if (string.IsNullOrEmpty(team.BENCH4))
                            { team.BENCH4 = t.FIRST + " " + t.LAST; }
                            else if (string.IsNullOrEmpty(team.BENCH5))
                            { team.BENCH5 = t.FIRST + " " + t.LAST; }
                            else if (string.IsNullOrEmpty(team.BENCH6))
                            { team.BENCH6 = t.FIRST + " " + t.LAST; }
                            break;
                    }
                }
            }

        }

        private void getCounters(FF2014Entities ptx)
        {
            var counters = from x in ptx.FF_TAKEN
                           select x;
            int totalcount = 0;

            foreach (var a in counters)
            {
                if (a.POS.Trim().ToUpper() == "QB")
                {
                    lblQBCount.Text = a.COUNT.ToString();
                    totalcount += int.Parse(a.COUNT.ToString());
                }
                if (a.POS.Trim().ToUpper() == "RB")
                {
                    lblRBCount.Text = a.COUNT.ToString();
                    totalcount += int.Parse(a.COUNT.ToString());
                }
                if (a.POS.Trim().ToUpper() == "WR")
                {
                    lblWRCount.Text = a.COUNT.ToString();
                    totalcount += int.Parse(a.COUNT.ToString());
                }
                if (a.POS.Trim().ToUpper() == "TE")
                {
                    lblTECount.Text = a.COUNT.ToString();
                    totalcount += int.Parse(a.COUNT.ToString());
                }
                if (a.POS.Trim().ToUpper() == "K")
                {
                    lblKCount.Text = a.COUNT.ToString();
                    totalcount += int.Parse(a.COUNT.ToString());
                }
                if (a.POS.Trim().ToUpper() == "DEF")
                {
                    lblDEFCount.Text = a.COUNT.ToString();
                    totalcount += int.Parse(a.COUNT.ToString());
                }
            }

            lblTotalCount.Text = totalcount.ToString();
        }
        #endregion

        #region Checkboxes
        protected void gv_Drafted_CheckChanged(object sender, EventArgs e)
        {
            string danrules = "yes";
            int _id = 0;
            RepeaterItem row = (sender as CheckBox).Parent as RepeaterItem;
            CheckBox cb = row.FindControl("CheckBox1") as CheckBox;
            RepeaterItem item = (RepeaterItem)cb.NamingContainer;

            Label lblid = (Label)item.FindControl("lblID");

            _id = int.Parse(lblid.Text);
            //_id = int.Parse(row.Cells[0].Text);
            if (cb.Checked)
            {
                using (FF2014Entities itx = new FF2014Entities())
                {
                    var _i = from i in itx.FF_Player
                             where i.ID == _id
                             select i;
                    foreach (var t in _i)
                    {
                        t.DRAFTED = true;
                    }
                    itx.SaveChanges();
                    updateCount(_id, itx, true);

                    itx.Dispose();
                }
                BuildData();

            }
            else
            {
                using (FF2014Entities itx = new FF2014Entities())
                {
                    var _i = from i in itx.FF_Player
                             where i.ID == _id
                             select i;
                    foreach (var t in _i)
                    {
                        t.DRAFTED = false;
                    }
                    itx.SaveChanges();
                    updateCount(_id, itx, false);

                    itx.Dispose();
                }
                BuildData();
            }
            

        }
        protected void gv_MyTeam_CheckChanged(object sender, EventArgs e)
        {
            string danrules = "yes";
            int _id = 0;

            RepeaterItem row = (sender as CheckBox).Parent as RepeaterItem;
            CheckBox cb = row.FindControl("CheckBox2") as CheckBox;
            RepeaterItem item = (RepeaterItem)cb.NamingContainer;

            Label lblid = (Label)item.FindControl("lblID");

            _id = int.Parse(lblid.Text);

            if (cb.Checked)
            {
                using (FF2014Entities itx = new FF2014Entities())
                {
                    var _i = from i in itx.FF_Player
                             where i.ID == _id
                             select i;
                    foreach (var t in _i)
                    {
                        t.DRAFTED = true;
                        t.MYTEAM = true;
                    }
                    itx.SaveChanges();
                    updateCount(_id, itx, true);

                    itx.Dispose();
                }
                BuildData();

            }
            else
            {
                using (FF2014Entities itx = new FF2014Entities())
                {
                    var _i = from i in itx.FF_Player
                             where i.ID == _id
                             select i;
                    foreach (var t in _i)
                    {
                        t.DRAFTED = false;
                        t.MYTEAM = false;
                    }
                    itx.SaveChanges();
                    updateCount(_id, itx, false);

                    itx.Dispose();

                }
                BuildData();
            }
            

        }
        #endregion
    }
}