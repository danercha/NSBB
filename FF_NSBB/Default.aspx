<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FF_NSBB._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {

            (function ($) {

                $('#filter').keyup(function () {

                    var rex = new RegExp($(this).val(), 'i');
                    $('.searchable tr').hide();
                    $('.searchable tr').filter(function () {
                        return rex.test($(this).text());
                    }).show();

                })

            }(jQuery));

        });
    </script>
    <div class="container-fluid">
        <div class="row">
            <p class="glyphicon glyphicon-road" style="margin-top: 5px;">
                <asp:Label runat="server" ID="Label34" CssClass="h5" Font-Bold="true">Number of Players Taken</asp:Label>&nbsp;&nbsp;&nbsp;
            <asp:Label runat="server" ID="Label32" CssClass="">QB: </asp:Label><asp:Label runat="server" ID="lblQBCount" CssClass=""></asp:Label>&nbsp;&nbsp;&nbsp;
                <asp:Label runat="server" ID="Label33" CssClass="">RB: </asp:Label><asp:Label runat="server" ID="lblRBCount" CssClass=""></asp:Label>&nbsp;&nbsp;&nbsp;
                <asp:Label runat="server" ID="Label35" CssClass="">WR: </asp:Label><asp:Label runat="server" ID="lblWRCount" CssClass=""></asp:Label>&nbsp;&nbsp;&nbsp;
                <asp:Label runat="server" ID="Label37" CssClass="">TE: </asp:Label><asp:Label runat="server" ID="lblTECount" CssClass=""></asp:Label>&nbsp;&nbsp;&nbsp;
                <asp:Label runat="server" ID="Label39" CssClass="">K: </asp:Label><asp:Label runat="server" ID="lblKCount" CssClass=""></asp:Label>&nbsp;&nbsp;&nbsp;
                <asp:Label runat="server" ID="Label41" CssClass="">DEF: </asp:Label><asp:Label runat="server" ID="lblDEFCount" CssClass=""></asp:Label>&nbsp;&nbsp;&nbsp;
            <asp:Label runat="server" ID="Label36" CssClass="">Total: </asp:Label><asp:Label runat="server" ID="lblTotalCount" CssClass=""></asp:Label>
            </p>
        </div>
        <div class="row">
            <div class="col-xs-12 col-sm-6 col-md-8">
                <div class="jumbotron" style="overflow: auto;">
                    <div class="input-group">
                        <span class="input-group-addon">Filter</span>

                        <input id="filter" type="text" class="form-control" placeholder="Type here...">
                    </div>
                    <h3>Players</h3>
                    <table class="table table-responsive">
                        <thead>
                            <tr>
                                <td>ID</td>
                                <td>Name</td>
                                <td>Team</td>
                                <td>Position</td>
                                <td>Pos Rank</td>
                                <td>Drafted</td>
                                <td>My Team</td>
                            </tr>
                        </thead>
                        <tbody class="searchable">
                            <asp:Repeater runat="server" ID="rptPlayers">
                                <ItemTemplate>
                                    <tr>
                                        <td><asp:Label runat="server" ID="lblID" Text=' <%# Eval("ID") %>'></asp:Label></td>
                                        <td><a href="http://subscribers.footballguys.com/players/player-all-info.php?id=<%# Eval("SID") %>" target="_blank">
                                            <%# Eval("First") + " " + Eval("Last") %></a></td>
                                        <td><%# Eval("Team") %></td>
                                        <td><%# Eval("Pos") %></td>
                                        <td><%# Eval("VDB") %></td>
                                        <td>
                                            <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("Drafted") %>' Enabled="true" OnCheckedChanged="gv_Drafted_CheckChanged"
                                                AutoPostBack="true" /></td>
                                        <td>
                                            <asp:CheckBox ID="CheckBox2" runat="server" Checked='<%# Bind("MyTeam") %>' Enabled="true"
                                              OnCheckedChanged="gv_MyTeam_CheckChanged" AutoPostBack="true" /></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                            <tr>
                                <td></td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
            <div class="col-xs-6 col-md-4">
                <br />
                <br />
                <asp:Repeater runat="server" ID="rptMyTeam">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblQBl" Font-Bold="true">QB:</asp:Label>&nbsp;&nbsp;<asp:Label runat="server" ID="lblQB"><%# Eval("QB") %></asp:Label><br />
                        <asp:Label runat="server" ID="Label2" Font-Bold="true">RB1:</asp:Label>&nbsp;&nbsp;<asp:Label runat="server" ID="Label3"><%# Eval("RB1") %></asp:Label><br />
                        <asp:Label runat="server" ID="Label4" Font-Bold="true">RB2:</asp:Label>&nbsp;&nbsp;<asp:Label runat="server" ID="Label5"><%# Eval("RB2") %></asp:Label><br />
                        <asp:Label runat="server" ID="Label6" Font-Bold="true">WR1:</asp:Label>&nbsp;&nbsp;<asp:Label runat="server" ID="Label7"><%# Eval("WR1") %></asp:Label><br />
                        <asp:Label runat="server" ID="Label8" Font-Bold="true">WR2:</asp:Label>&nbsp;&nbsp;<asp:Label runat="server" ID="Label9"><%# Eval("WR2") %></asp:Label><br />
                        <asp:Label runat="server" ID="Label10" Font-Bold="true">WR3:</asp:Label>&nbsp;&nbsp;<asp:Label runat="server" ID="Label11"><%# Eval("WR3") %></asp:Label><br />
                        <asp:Label runat="server" ID="Label12" Font-Bold="true">TE:</asp:Label>&nbsp;&nbsp;<asp:Label runat="server" ID="Label13"><%# Eval("TE") %></asp:Label><br />
                        <asp:Label runat="server" ID="Label14" Font-Bold="true">FLEX:</asp:Label>&nbsp;&nbsp;<asp:Label runat="server" ID="Label15"><%# Eval("FLEX") %></asp:Label><br />
                        <asp:Label runat="server" ID="Label28" Font-Bold="true">K:</asp:Label>&nbsp;&nbsp;<asp:Label runat="server" ID="Label29"><%# Eval("K") %></asp:Label><br />
                        <asp:Label runat="server" ID="Label30" Font-Bold="true">Def:</asp:Label>&nbsp;&nbsp;<asp:Label runat="server" ID="Label31"><%# Eval("DEF") %></asp:Label><br />
                        <asp:Label runat="server" ID="Label16" Font-Bold="true">Bench:</asp:Label>&nbsp;&nbsp;<asp:Label runat="server" ID="Label17"><%# Eval("BENCH1") %></asp:Label><br />
                        <asp:Label runat="server" ID="Label18" Font-Bold="true">Bench:</asp:Label>&nbsp;&nbsp;<asp:Label runat="server" ID="Label19"><%# Eval("BENCH2") %></asp:Label><br />
                        <asp:Label runat="server" ID="Label20" Font-Bold="true">Bench:</asp:Label>&nbsp;&nbsp;<asp:Label runat="server" ID="Label21"><%# Eval("BENCH3") %></asp:Label><br />
                        <asp:Label runat="server" ID="Label22" Font-Bold="true">Bench:</asp:Label>&nbsp;&nbsp;<asp:Label runat="server" ID="Label23"><%# Eval("BENCH4") %></asp:Label><br />
                        <asp:Label runat="server" ID="Label24" Font-Bold="true">Bench:</asp:Label>&nbsp;&nbsp;<asp:Label runat="server" ID="Label25"><%# Eval("BENCH5") %></asp:Label><br />
                        <asp:Label runat="server" ID="Label26" Font-Bold="true">Bench:</asp:Label>&nbsp;&nbsp;<asp:Label runat="server" ID="Label27"><%# Eval("BENCH6") %></asp:Label><br />

                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Getting started</h2>
            <p>
                ASP.NET Web Forms lets you build dynamic websites using a familiar drag-and-drop, event-driven model.
            A design surface and hundreds of controls and components let you rapidly build sophisticated, powerful UI-driven sites with data access.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Get more libraries</h2>
            <p>
                NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Web Hosting</h2>
            <p>
                You can easily find a web hosting company that offers the right mix of features and price for your applications.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
            </p>
        </div>
    </div>


</asp:Content>
