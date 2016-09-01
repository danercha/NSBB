using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FF_NSBB.DAL;
using FF_NSBB.STATIC;
using System.Web.Services;

namespace FF_NSBB
{
    public partial class DraftBoard : System.Web.UI.Page
    {
        #region Global Vars
        List<localTeam> _teams = new List<localTeam>();
        public int drafting;
        private int _countDown = 30; // Seconds
        private Timer _timer;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                drafting = getTurn();
                SetupPage();
                updateTeam();
            }
        }

        private int getTurn()
        {
            int t = 0;
            using (FF2014Entities gtx = new FF2014Entities())
            {
                var _t = from x in gtx.Turns
                         where x.ID == 1
                         select x.DRAFTSPOT;
                foreach (var u in _t)
                {
                    t = u;
                }
            }
            return t;
        }

        private void SetupPage()
        {
            string curname = string.Empty;

            using (FF2014Entities itx = new FF2014Entities())
            {
                var im = (from x in itx.Teams
                          from d
                          in itx.DRAFTs.Where(o => x.ID == o.TEAMID).DefaultIfEmpty()
                          group new { x.ID, d.DRAFT1, x.TeamName, x.TeamManager, x.Picture } by new { x.ID, d.DRAFT1, x.TeamName, x.TeamManager, x.Picture } into g
                          orderby g.Key.DRAFT1
                          select new { ID = g.Key.ID, TeamName = g.Key.TeamName, TeamManager = g.Key.TeamManager, Picture = g.Key.Picture });

                foreach (var a in im)
                {
                    int? draftnum;

                    using (FF2014Entities dtx = new FF2014Entities())
                    {
                        var did = (from i in dtx.DRAFTs
                                   where i.TEAMID == a.ID
                                   select i.DRAFT1).FirstOrDefault();

                        draftnum = int.Parse(did.ToString());
                    }


                    _teams.Add(new localTeam { TeamName = a.TeamName, TeamManager = a.TeamManager, Picture = "IMG/" + a.Picture, DraftOrder = draftnum, ID = a.ID });
                }
                var cur = (from i in itx.Teams
                           where i.ID == drafting
                           select i).First();
                curname = cur.TeamName;

                itx.Dispose();
            }

            rptDrafters.DataSource = _teams;
            rptDrafters.DataBind();
            lblNowDrafting.Text = curname;
        }

        private void updateTeam()
        {
            List<FFTeam> _teams = new List<FFTeam>();
            List<int> teamIDs = new List<int>();
            using (FF2014Entities itx = new FF2014Entities())
            {
                var _tids = (from x in itx.Teams
                             from d
                             in itx.DRAFTs.Where(o => x.ID == o.TEAMID).DefaultIfEmpty()
                             group new { x.ID, d.DRAFT1, x.TeamName, x.TeamManager, x.Picture } by new { x.ID, d.DRAFT1, x.TeamName, x.TeamManager, x.Picture } into g
                             orderby g.Key.DRAFT1
                             select new { ID = g.Key.ID, TeamName = g.Key.TeamName, TeamManager = g.Key.TeamManager, Picture = g.Key.Picture });

                foreach (var u in _tids)
                {
                    _teams.Add(new FFTeam { TeamID = u.ID, TeamName = u.TeamName });
                }

                foreach (FFTeam f in _teams)
                {
                    var _pids = from l in itx.Leagues
                                where l.TEAMID == f.TeamID
                                select l.PLAYERID;

                    foreach (int l in _pids)
                    {
                        var _player = from p in itx.Players
                                      where p.ID == l
                                      select p;

                        foreach (var t in _player)
                        {
                            #region switch position
                            switch (t.POS.Trim())
                            {
                                case "QB":
                                    if (string.IsNullOrEmpty(f.QB))
                                    { f.QB = t.FIRST + " " + t.LAST; }
                                    else if (string.IsNullOrEmpty(f.BENCH1))
                                    { f.BENCH1 = t.FIRST + " " + t.LAST; }
                                    else if (string.IsNullOrEmpty(f.BENCH2))
                                    { f.BENCH2 = t.FIRST + " " + t.LAST; }
                                    else if (string.IsNullOrEmpty(f.BENCH3))
                                    { f.BENCH3 = t.FIRST + " " + t.LAST; }
                                    else if (string.IsNullOrEmpty(f.BENCH4))
                                    { f.BENCH4 = t.FIRST + " " + t.LAST; }
                                    else if (string.IsNullOrEmpty(f.BENCH5))
                                    { f.BENCH5 = t.FIRST + " " + t.LAST; }
                                    else if (string.IsNullOrEmpty(f.BENCH6))
                                    { f.BENCH6 = t.FIRST + " " + t.LAST; }
                                    break;
                                case "RB":
                                    if (string.IsNullOrEmpty(f.RB1))
                                    { f.RB1 = t.FIRST + " " + t.LAST; }
                                    else if (string.IsNullOrEmpty(f.RB2))
                                    { f.RB2 = t.FIRST + " " + t.LAST; }
                                    else if (string.IsNullOrEmpty(f.FLEX))
                                    { f.FLEX = t.FIRST + " " + t.LAST; }
                                    else if (string.IsNullOrEmpty(f.BENCH1))
                                    { f.BENCH1 = t.FIRST + " " + t.LAST; }
                                    else if (string.IsNullOrEmpty(f.BENCH2))
                                    { f.BENCH2 = t.FIRST + " " + t.LAST; }
                                    else if (string.IsNullOrEmpty(f.BENCH3))
                                    { f.BENCH3 = t.FIRST + " " + t.LAST; }
                                    else if (string.IsNullOrEmpty(f.BENCH4))
                                    { f.BENCH4 = t.FIRST + " " + t.LAST; }
                                    else if (string.IsNullOrEmpty(f.BENCH5))
                                    { f.BENCH5 = t.FIRST + " " + t.LAST; }
                                    else if (string.IsNullOrEmpty(f.BENCH6))
                                    { f.BENCH6 = t.FIRST + " " + t.LAST; }
                                    break;
                                case "WR":
                                    if (string.IsNullOrEmpty(f.WR1))
                                    { f.WR1 = t.FIRST + " " + t.LAST; }
                                    else if (string.IsNullOrEmpty(f.WR2))
                                    { f.WR2 = t.FIRST + " " + t.LAST; }
                                    else if (string.IsNullOrEmpty(f.WR3))
                                    { f.WR3 = t.FIRST + " " + t.LAST; }
                                    else if (string.IsNullOrEmpty(f.FLEX))
                                    { f.FLEX = t.FIRST + " " + t.LAST; }
                                    else if (string.IsNullOrEmpty(f.BENCH1))
                                    { f.BENCH1 = t.FIRST + " " + t.LAST; }
                                    else if (string.IsNullOrEmpty(f.BENCH2))
                                    { f.BENCH2 = t.FIRST + " " + t.LAST; }
                                    else if (string.IsNullOrEmpty(f.BENCH3))
                                    { f.BENCH3 = t.FIRST + " " + t.LAST; }
                                    else if (string.IsNullOrEmpty(f.BENCH4))
                                    { f.BENCH4 = t.FIRST + " " + t.LAST; }
                                    else if (string.IsNullOrEmpty(f.BENCH5))
                                    { f.BENCH5 = t.FIRST + " " + t.LAST; }
                                    else if (string.IsNullOrEmpty(f.BENCH6))
                                    { f.BENCH6 = t.FIRST + " " + t.LAST; }
                                    break;
                                case "TE":
                                    if (string.IsNullOrEmpty(f.TE))
                                    { f.TE = t.FIRST + " " + t.LAST; }
                                    else if (string.IsNullOrEmpty(f.FLEX))
                                    { f.FLEX = t.FIRST + " " + t.LAST; }
                                    else if (string.IsNullOrEmpty(f.BENCH1))
                                    { f.BENCH1 = t.FIRST + " " + t.LAST; }
                                    else if (string.IsNullOrEmpty(f.BENCH2))
                                    { f.BENCH2 = t.FIRST + " " + t.LAST; }
                                    else if (string.IsNullOrEmpty(f.BENCH3))
                                    { f.BENCH3 = t.FIRST + " " + t.LAST; }
                                    else if (string.IsNullOrEmpty(f.BENCH4))
                                    { f.BENCH4 = t.FIRST + " " + t.LAST; }
                                    else if (string.IsNullOrEmpty(f.BENCH5))
                                    { f.BENCH5 = t.FIRST + " " + t.LAST; }
                                    else if (string.IsNullOrEmpty(f.BENCH6))
                                    { f.BENCH6 = t.FIRST + " " + t.LAST; }
                                    break;
                                case "K":
                                    if (string.IsNullOrEmpty(f.K))
                                    { f.K = t.FIRST + " " + t.LAST; }
                                    else if (string.IsNullOrEmpty(f.BENCH1))
                                    { f.BENCH1 = t.FIRST + " " + t.LAST; }
                                    else if (string.IsNullOrEmpty(f.BENCH2))
                                    { f.BENCH2 = t.FIRST + " " + t.LAST; }
                                    else if (string.IsNullOrEmpty(f.BENCH3))
                                    { f.BENCH3 = t.FIRST + " " + t.LAST; }
                                    else if (string.IsNullOrEmpty(f.BENCH4))
                                    { f.BENCH4 = t.FIRST + " " + t.LAST; }
                                    else if (string.IsNullOrEmpty(f.BENCH5))
                                    { f.BENCH5 = t.FIRST + " " + t.LAST; }
                                    else if (string.IsNullOrEmpty(f.BENCH6))
                                    { f.BENCH6 = t.FIRST + " " + t.LAST; }
                                    break;
                                case "DEF":
                                    if (string.IsNullOrEmpty(f.DEF))
                                    { f.DEF = t.FIRST + " " + t.LAST; }
                                    else if (string.IsNullOrEmpty(f.BENCH1))
                                    { f.BENCH1 = t.FIRST + " " + t.LAST; }
                                    else if (string.IsNullOrEmpty(f.BENCH2))
                                    { f.BENCH2 = t.FIRST + " " + t.LAST; }
                                    else if (string.IsNullOrEmpty(f.BENCH3))
                                    { f.BENCH3 = t.FIRST + " " + t.LAST; }
                                    else if (string.IsNullOrEmpty(f.BENCH4))
                                    { f.BENCH4 = t.FIRST + " " + t.LAST; }
                                    else if (string.IsNullOrEmpty(f.BENCH5))
                                    { f.BENCH5 = t.FIRST + " " + t.LAST; }
                                    else if (string.IsNullOrEmpty(f.BENCH6))
                                    { f.BENCH6 = t.FIRST + " " + t.LAST; }
                                    break;
                            }
                            #endregion
                        }
                    }
                }
                itx.Dispose();
            }

            dlTeams.DataSource = _teams;
            dlTeams.DataBind();
        }

        private void updateCount(int pid, bool updown)
        {
            using (FF2014Entities ttt = new FF2014Entities())
            {
                var p = (from y in ttt.Players
                         where y.ID == pid
                         select y).First();

                string _pos = p.POS.Trim();

                var c = (from x in ttt.TAKENs
                         where x.POS == _pos
                         select x).First();

                if (updown)
                    c.COUNT++;
                else
                    c.COUNT--;

                ttt.SaveChanges();
            }

        }

        #region Button Clicks
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            drafting = getTurn();
            string boxvalue = tags.Text;
            string[] parts = boxvalue.Split('|');

            if (parts.Length > 1)
            {
                int pid = int.Parse(parts[1].ToString().Trim());

                using (FF2014Entities ptx = new FF2014Entities())
                {
                    var tid = (from i in ptx.DRAFTs
                               where i.DRAFT1 == drafting
                               select i.TEAMID).First();

                    League l = new League { PLAYERID = pid, TEAMID = (int)tid };
                    ptx.Leagues.Add(l);

                    ptx.SaveChanges();

                    var p = from layer in ptx.Players
                            where layer.ID == pid
                            select layer;

                    foreach (var y in p)
                    {
                        y.DRAFTED = true;
                        if(tid == 1)
                        {
                            y.MYTEAM = true;
                        }

                    }

                    ptx.SaveChanges();
                    ptx.Dispose();
                }

                using (FF2014Entities stx = new FF2014Entities())
                {
                    var s = from x in stx.Turns
                            where x.ID == 1
                            select x;

                    foreach (var a in s)
                    {
                        int incr = a.DRAFTSPOT;
                        if (!a.UPDOWN)
                        {
                            if (a.DRAFTSPOT != a.MAXCOUNT)
                                incr++;
                            else
                                a.UPDOWN = true;
                        }
                        else
                        {
                            if (a.DRAFTSPOT != 1)
                                incr--;
                            else
                                a.UPDOWN = false;
                        }



                        a.DRAFTSPOT = incr;

                    }
                    stx.SaveChanges();
                    stx.Dispose();

                    //Update counters
                    updateCount(pid, true);
                }

                tags.Text = "";
                drafting = getTurn();
                SetupPage();
                updateTeam();
                tags.Focus();
            }
            else { tags.Text = ""; }
        }

        protected void lbEmail_Click(object sender, EventArgs e)
        {
            string messagebody = string.Empty;
            messagebody += "<table>";

            using (FF2014Entities ltx = new FF2014Entities())
            {
                var row = from l in ltx.Leagues
                          from t
                          in ltx.Teams.Where(o => l.TEAMID == o.ID).DefaultIfEmpty()
                          from p
                          in ltx.Players.Where(z => l.PLAYERID == z.ID).DefaultIfEmpty()
                          select new
                          {
                              Teamname = t.TeamName,
                              PlayerName = p.FIRST + " " + p.LAST
                          };
                foreach (var r in row)
                {
                    messagebody += "<tr><td>" + r.Teamname + "</td><td>" + r.PlayerName + "</td></tr>";
                }
            }

            System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
            message.To.Add("dan_ercha@hitchiner.com");
            message.Subject = "North Shore Booze Bags 10 Draft Results";
            message.From = new System.Net.Mail.MailAddress("dan_ercha@hitchiner.com");
            message.Body = messagebody;
            message.IsBodyHtml = true;
            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
            smtp.Host = "smtp.hitchiner.com";
            //smtp.Port = 587;
            //smtp.EnableSsl = true;
            smtp.Send(message);
        }
        #endregion

        #region Web Methods

        [WebMethod]
        public static string[] GetPlayerList(string keyword)
        {
            List<string> _players = new List<string>();

            using (FF2014Entities atx = new FF2014Entities())
            {
                var _a = from d in atx.Players
                         let fullname = d.FIRST + " " + d.LAST
                         where fullname.Contains(keyword) && d.DRAFTED == false
                         select d;
                foreach (var a in _a)
                {
                    _players.Add(a.FIRST.Trim() + " " + a.LAST.Trim() + " (" + a.POS.Trim() + ")" + " - " + a.TEAM + " |" + a.ID);
                }

                atx.Dispose();
            }

            return _players.ToArray();
        }
        #endregion
    }
}