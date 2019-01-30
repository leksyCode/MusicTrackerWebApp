<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="MusicTrackerWebApp.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width";/>  
    <title>Music Tracker</title>
</head>
    <body>
        <form id="form1" runat="server">
         <div style="height: 360px">
             <asp:Label ID="Lyrics" runat="server">Press button to start</asp:Label>
             <asp:Label ID="User1" runat="server">user - score:</asp:Label>
             <asp:TextBox ID="AnswerBox" runat="server" Width="250px" Font-Names="Verdana" Font-Size="12"/>    
             <asp:Button ID="AnswerButton" runat="server" Text="Answer" OnClick="AnswerButton_Click" Type="submit"/>            
             <asp:Button ID="ReloadData" runat="server" Text="New game" OnClick="ReloadData_Click" Type="submit"/>

             <asp:TextBox ID="LoginBox" runat="server" placeholder="login" Width="170px" Font-Names="Verdana" Font-Size="12"/>    
             <asp:TextBox ID="PasswordBox" runat="server" placeholder="password" type="password" Width="170px" Font-Names="Verdana" Font-Size="12"/>    
             <asp:Button ID="ConnectButton" runat="server" Text="Connect" OnClick="ConnectButton_Click" Type="submit"/>
             <asp:Button ID="Disconnect" runat="server" Text="Disconnect" OnClick="Disconnect_Click" Type="submit"/>

         </div>
    </form>
</body>
    <style type="text/css">
        #Lyrics {
            position:absolute; 
            font-size: 24px;
            background-color:lightsalmon;
            height:280px;width:600px;
            left:360px;top:20px;
            white-space: pre;
        }
        #AnswerButton {
            position:absolute;
            left:620px;top:320px;
            height: 26px;            
        }
        #AnswerBox {
            position:absolute;
            left:360px;top:320px;
        }
         #ReloadData {
            position:absolute;
            left:875px;
            top:320px;
            height: 26px;            
        }
         #Disconnect {
            position:absolute;
            left:780px;
            top:320px;
            height: 26px;            
        }

        #ConnectButton {
            position:absolute;
            left:540px;top:320px;
            height: 26px;            
        }
        #LoginBox {
            position:absolute;
            left:360px;top:320px;
        }
        #PasswordBox {
            position:absolute;
            left:360px;top:360px;
        }
        
         #User1 {
             position:absolute;
             top:20px;
             left: 240px;             
         }

        @media screen and (max-width: 800px) {
            #Lyrics {
                position: absolute;
                font-size: 18px;
                background-color: lightsalmon;
                height: 360px;
                width: 340px;
                left: 20px;
                top: 60px;
                white-space: pre;
            }

            #AnswerButton {
                position: absolute;
                left: 300px;
                top: 430px;
                height: 26px;
            }

            #ReloadData {
                position: absolute;
                top: 20px;
                left: 140px;
                height: 26px;
            }
            #Disconnect {
                position: absolute;
                top: 20px;
                left: 240px;
                height: 26px;
            }

            #AnswerBox {
                position: absolute;
                left: 20px;
                top: 430px;
            }

            #User1 {
                position: absolute;
                top: 20px;
                left: 20px;
            }
            #ConnectButton {
            position:absolute;
            left:210px;top:450px;
            height: 26px;            
            }
            #LoginBox {
            position: absolute;
                left: 20px;
                top: 450px;
            }
            #PasswordBox {
            position:absolute;
            left: 20px;
            top: 490px;
            }
        }
    </style>
</html>
