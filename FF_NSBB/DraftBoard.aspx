<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DraftBoard.aspx.cs" Inherits="FF_NSBB.DraftBoard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Draft Board</title>
    <script src="Scripts/jquery-2.2.4.min.js"></script>
    <script src="Scripts/bootstrap.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.11.4/jquery-ui.min.js"></script>

    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://ajax.googleapis.com/ajax/libs/jqueryui/1.11.4/themes/smoothness/jquery-ui.css">
    <link href="Content/Site.css" rel="stylesheet" />

     <script type="text/javascript">
                $(document).ready(function () {
                    $("#tags").autocomplete({
                        source: function (request, response) {
                            var param = { keyword: $('#tags').val() };
                            $.ajax({
                                url: "DraftBoard.aspx/GetPlayerList",
                                data: JSON.stringify(param),
                                dataType: "json",
                                type: "POST",
                                contentType: "application/json; charset=utf-8",
                                dataFilter: function (data) { return data; },
                                success: function (data) {
                                    response($.map(data.d, function (item) {
                                        return {
                                            value: item
                                        }
                                    }))
                                },
                                error: function (XMLHttpRequest, textStatus, errorThrown) {
                                    alert(textStatus);
                                }
                            });
                        },
                        select: function (event, ui) {
                            if (ui.item) {
                                // var Alloys = document.getElementById(FindControl("cgv_ROS").ClientId);
                                //UpdateAlloys(ui.item.value, Alloys);
                                //filter(0, ui.item.value)
                                //FilterForAlloy(ui.item.value);
                            }
                        },
                        minLength: 2
                    });

                    // Our countdown plugin takes a callback, a duration, and an optional message
                    $.fn.countdown = function (callback, duration, message) {
                        // If no message is provided, we use an empty string
                        message = message || "";
                        // Get reference to container, and set initial content
                        var container = $(this[0]).html(duration + message);
                        // Get reference to the interval doing the countdown
                        var countdown = setInterval(function () {
                            // If seconds remain
                            if (--duration) {
                                if (duration < 60) {
                                    $('#countdown').addClass('alert-warning');
                                }
                                if (duration < 30) {
                                    $('#countdown').addClass('alert-danger');
                                }
                                // Update our container's message
                                container.html(duration + message);
                                // Otherwise
                            } else {
                                // Clear the countdown interval
                                clearInterval(countdown);
                                // And fire the callback passing our container as `this`
                                callback.call(container);
                            }
                            // Run interval every 1000ms (1 second)
                        }, 1000);

                    };

                    // Use p.countdown as container, pass redirect, duration, and optional message
                    $(".countdown").countdown(redirect, 120, "s remaining");

                    // Function to be called after 5 seconds
                    function redirect() {
                        this.html("Loser your time is up!!!.");
                        // window.location = "http://msdn.microsoft.com";
                    }
                })


            </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div style="margin: 0 auto; width: 100%;">
                <div class="" style="text-align: center; margin-top: 4px;">
                    <asp:Repeater runat="server" ID="rptDrafters">
                        <ItemTemplate>
                            <asp:Image runat="server" BorderColor='<%# ((int)Eval("DraftOrder") == drafting) ? System.Drawing.Color.YellowGreen : System.Drawing.Color.White   %>' BorderWidth="6" ImageUrl='<%# Eval("Picture") %>' AlternateText='<%# Eval("TeamName") %>' />
                        </ItemTemplate>
                    </asp:Repeater>
                    <br />
                    <p>
                        <label for="lblDrafting" class="h2" style="color: wheat;">Now Drafting</label>
                        <br />
                        <asp:Label runat="server" ID="lblNowDrafting" CssClass="h3" ForeColor="Wheat"></asp:Label>&nbsp;&nbsp;
                    </p>
                    <div style="text-align: center; width: 100%;">
                        <p class="countdown alert-info" id="countdown" style="font-weight: bolder; font-size: large; width: 220px; margin-left: 45%"></p>
                    </div>
                </div>
                <p style="text-align: center;">
                    <label for="tags">Players:&nbsp; </label>
                    <asp:TextBox runat="server" ID="tags" Width="250px"></asp:TextBox>
                    <asp:Button runat="server" ID="btnSubmit" Text="Draft" OnClick="btnSubmit_Click" />
                </p>
                <div class="jumbotron" style="padding-left: 5%;">
                    <asp:DataList runat="server" ID="dlTeams" RepeatDirection="Horizontal" CellPadding="2">
                        <ItemTemplate>
                            <div class="body-content" style="width: 100%; padding: 15px; text-align: center;">
                                <asp:Label runat="server" ID="Label32" CssClass="h4" Font-Underline="true"><%# Eval("TeamName") %></asp:Label><br />
                                <asp:Label runat="server" ID="lblQBl" CssClass="h5">QB:</asp:Label>&nbsp;&nbsp;<asp:Label runat="server" ID="lblQB" CssClass="text-primary"><%# Eval("QB") %></asp:Label><br />
                                <asp:Label runat="server" ID="Label2" CssClass="h5">RB1:</asp:Label>&nbsp;&nbsp;<asp:Label runat="server" ID="Label3" CssClass="text-primary"><%# Eval("RB1") %></asp:Label><br />
                                <asp:Label runat="server" ID="Label4" CssClass="h5">RB2:</asp:Label>&nbsp;&nbsp;<asp:Label runat="server" ID="Label5" CssClass="text-primary"><%# Eval("RB2") %></asp:Label><br />
                                <asp:Label runat="server" ID="Label6" CssClass="h5">WR1:</asp:Label>&nbsp;&nbsp;<asp:Label runat="server" ID="Label7" CssClass="text-primary"><%# Eval("WR1") %></asp:Label><br />
                                <asp:Label runat="server" ID="Label8" CssClass="h5">WR2:</asp:Label>&nbsp;&nbsp;<asp:Label runat="server" ID="Label9" CssClass="text-primary"><%# Eval("WR2") %></asp:Label><br />
                                <asp:Label runat="server" ID="Label10" CssClass="h5">WR3:</asp:Label>&nbsp;&nbsp;<asp:Label runat="server" ID="Label11" CssClass="text-primary"><%# Eval("WR3") %></asp:Label><br />
                                <asp:Label runat="server" ID="Label12" CssClass="h5">TE:</asp:Label>&nbsp;&nbsp;<asp:Label runat="server" ID="Label13" CssClass="text-primary"><%# Eval("TE") %></asp:Label><br />
                                <asp:Label runat="server" ID="Label14" CssClass="h5">FLEX:</asp:Label>&nbsp;&nbsp;<asp:Label runat="server" ID="Label15" CssClass="text-primary"><%# Eval("FLEX") %></asp:Label><br />
                                <asp:Label runat="server" ID="Label28" CssClass="h5">K:</asp:Label>&nbsp;&nbsp;<asp:Label runat="server" ID="Label29" CssClass="text-primary"><%# Eval("K") %></asp:Label><br />
                                <asp:Label runat="server" ID="Label30" CssClass="h5">Def:</asp:Label>&nbsp;&nbsp;<asp:Label runat="server" ID="Label31" CssClass="text-primary"><%# Eval("DEF") %></asp:Label><br />
                                <asp:Label runat="server" ID="Label16" CssClass="h5">Bench:</asp:Label>&nbsp;&nbsp;<asp:Label runat="server" ID="Label17" CssClass="text-primary"><%# Eval("BENCH1") %></asp:Label><br />
                                <asp:Label runat="server" ID="Label18" CssClass="h5">Bench:</asp:Label>&nbsp;&nbsp;<asp:Label runat="server" ID="Label19" CssClass="text-primary"><%# Eval("BENCH2") %></asp:Label><br />
                                <asp:Label runat="server" ID="Label20" CssClass="h5">Bench:</asp:Label>&nbsp;&nbsp;<asp:Label runat="server" ID="Label21" CssClass="text-primary"><%# Eval("BENCH3") %></asp:Label><br />
                                <asp:Label runat="server" ID="Label22" CssClass="h5">Bench:</asp:Label>&nbsp;&nbsp;<asp:Label runat="server" ID="Label23" CssClass="text-primary"><%# Eval("BENCH4") %></asp:Label><br />
                                <asp:Label runat="server" ID="Label24" CssClass="h5">Bench:</asp:Label>&nbsp;&nbsp;<asp:Label runat="server" ID="Label25" CssClass="text-primary"><%# Eval("BENCH5") %></asp:Label><br />
                                <asp:Label runat="server" ID="Label26" CssClass="h5">Bench:</asp:Label>&nbsp;&nbsp;<asp:Label runat="server" ID="Label27" CssClass="text-primary"><%# Eval("BENCH6") %></asp:Label><br />
                            </div>
                        </ItemTemplate>
                    </asp:DataList>

                </div>
                <div class="panel-footer" style="text-align: center;">
                    <asp:LinkButton runat="server" ID="lbEmail" Text="Send to Commish" OnClick="lbEmail_Click"></asp:LinkButton>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
