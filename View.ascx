<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="View.ascx.cs" Inherits="Christoc.Modules.RightmoveProperties.View" %>

<asp:Button ID="btnSyncProperties" runat="server" Text="Sync Properties" OnClick="btnSyncProperties_Click" />

<br />

<asp:Label ID="lblPropertyOutput" runat="server" Text="Label"></asp:Label>

<asp:GridView ID="PropertyGrid" runat="server" AutoGenerateColumns="true"></asp:GridView>
